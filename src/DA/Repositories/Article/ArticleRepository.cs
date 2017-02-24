using System;
using System.Collections.Generic;
using System.Linq;
using Tesseract.DA.Entities;

namespace Tesseract.DA.Repositories
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(AuthorsDBContext context, UnitOfWork unitOfWork)
            : base(context, unitOfWork)
        { }

        public IEnumerable<Article> ListArticles()
        {
            return dbContext.Set<Article>().Include("Authors").ToList();
        }

        public void Update(Article article, Author[] authors)
        {
            Article dbArticle = dbSet.FirstOrDefault(x => x.Id == article.Id);
            dbSet.Attach(dbArticle);

            List<Author> authorsToRemove = dbArticle.Authors.Where(x => authors.FirstOrDefault(y => y.Id == x.Id) == null).ToList();

            Guid[] newAuthorIDs = authors.Where(x => dbArticle.Authors.FirstOrDefault(y => y.Id == x.Id) == null).Select(x => x.Id).ToArray();
            List<Author> authorsToAdd = authors.Where(x => newAuthorIDs.Contains(x.Id)).ToList();

            dbArticle.Title = article.Title;
            dbArticle.ShortDescription = article.ShortDescription;
            dbArticle.Year = article.Year;
            dbArticle.Link = article.Link;

            authorsToRemove.ForEach(x => dbArticle.Authors.Remove(x));
            authorsToAdd.ForEach(x => dbArticle.Authors.Add(x));
        }

        public void DeleteById(Guid id)
        {
            Article article = dbSet.SingleOrDefault(x => x.Id == id);
            dbSet.Remove(article);
        }
    }
}
