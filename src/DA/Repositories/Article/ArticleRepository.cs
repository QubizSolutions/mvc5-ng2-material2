using System;
using System.Collections.Generic;
using System.Linq;
using Tesseract.DA.Article.Contract;
using Tesseract.DA.Author;
using Tesseract.DA.Article;

namespace Tesseract.DA.Repositories
{
    public class ArticleRepository : BaseRepository<Article.Entity.Article>, IArticleRepository
    {
        public ArticleRepository(AuthorsDBContext context, UnitOfWork unitOfWork)
            : base(context, unitOfWork)
        { }

        public void Create(ArticleContract article, Guid[] authorIDs)
        {
            List<Author.Entity.Author> authors = dbContext.Set<Author.Entity.Author>().Where(x => authorIDs.Contains(x.Id)).ToList();

            Article.Entity.Article entity = article.ToEntity();
            entity.Authors = authors;
            dbSet.Add(entity);
        }
        
        public void Update(ArticleContract article, Guid[] authorIDs)
        {
            Article.Entity.Article dbArticle = dbSet.FirstOrDefault(x => x.Id == article.Id);

            List<Author.Entity.Author> authorsToRemove = dbArticle.Authors.Where(x => !authorIDs.Contains(x.Id)).ToList();

            Guid[] authorsToAddIDs = authorIDs.Where(x => dbArticle.Authors.FirstOrDefault(y => y.Id == x) == null).ToArray();
            List<Author.Entity.Author> authorsToAdd = GetAuthorsByIDs(authorsToAddIDs);
            
            dbSet.Attach(dbArticle);
            
            dbArticle.Title = article.Title;
            dbArticle.ShortDescription = article.ShortDescription;
            dbArticle.Year = article.Year;
            dbArticle.Link = article.Link;

            authorsToRemove.ForEach(x => dbArticle.Authors.Remove(x));
            authorsToAdd.ForEach(x => dbArticle.Authors.Add(x));
        }
        
        public void DeleteById(Guid id)
        {
            Article.Entity.Article article = dbSet.SingleOrDefault(x => x.Id == id);
            dbSet.Remove(article);
        }

        public ArticleContract GetById(Guid id)
        {
            Article.Entity.Article article = dbSet.FirstOrDefault(x => x.Id == id);
            return article != null ? article.ToContract() : null;
        }

        public ArticleContract[] ListArticles()
        {
            Article.Entity.Article[] articles = dbSet.ToArray();
            return articles.Select(x => x.ToContract(false)).ToArray();
        }

        private List<Author.Entity.Author> GetAuthorsByIDs(Guid[] authorsToAddIDs)
        {
            return dbContext.Set<Author.Entity.Author>().Where(x => authorsToAddIDs.Contains(x.Id)).ToList();
        }
    }
}
