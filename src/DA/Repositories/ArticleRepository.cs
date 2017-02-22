using System;
using System.Collections.Generic;
using System.Linq;
using Tesseract.DA.Entities;

namespace Tesseract.DA.Repositories
{
    public class ArticleRepository
    {
        private AuthorsDBContext dbContext;

        public ArticleRepository()
        {
            dbContext = new AuthorsDBContext();
        }

        public IEnumerable<Article> GetArticles()
        {
            return dbContext.Articles.ToList();
        }

        public IEnumerable<Article> GetArticlesWithAuthors()
        {
            return dbContext.Set<Article>().Include("Authors").ToList();
        }

        public Article GetArticleById(Guid id)
        {
            return dbContext.Articles.Include("Authors").FirstOrDefault(x => x.Id == id);
        }
        
        public void Update(Article article)
        {
            Guid[] authorIDs = article.Authors.Select(y => y.Id).ToArray();

            if (article.Id == Guid.Empty)
            {
                List<Author> authors = dbContext.Authors.Where(x => authorIDs.Contains(x.Id)).ToList();
                article.Id = Guid.NewGuid();
                article.Authors = authors;
                dbContext.Articles.Add(article);
            }
            else
            {
                Article dbArticle = dbContext.Articles.FirstOrDefault(x => x.Id == article.Id);
                dbContext.Articles.Attach(dbArticle);

                List<Author> authorsToRemove = dbArticle.Authors.Where(x => !authorIDs.Contains(x.Id)).ToList();

                Guid[] newAuthorIDs = authorIDs.Where(x => dbArticle.Authors.FirstOrDefault(y => y.Id == x) == null).ToArray();
                List<Author> authorsToAdd = dbContext.Authors.Where(x => newAuthorIDs.Contains(x.Id)).ToList();

                dbArticle.Title = article.Title;
                dbArticle.ShortDescription = article.ShortDescription;
                dbArticle.Year = article.Year;
                dbArticle.Link = article.Link;

                authorsToRemove.ForEach(x => dbArticle.Authors.Remove(x));
                authorsToAdd.ForEach(x => dbArticle.Authors.Add(x));
            }
            dbContext.SaveChanges();
        }

        public void DeleteArticleById(Guid id)
        {
            Article article = dbContext.Articles.SingleOrDefault(x => x.Id == id);
            dbContext.Articles.Remove(article);

            dbContext.SaveChanges();
        }
    }
}
