using System;
using Tesseract.DA.Article.Contract;

namespace Tesseract.DA.Repositories
{
    public interface IArticleRepository: IBaseRepository<Article.Entity.Article>
    {
        void Create(ArticleContract article, Guid[] authorIDs);
        void Update(ArticleContract article, Guid[] authorIDs);
        void DeleteById(Guid id);
        ArticleContract GetById(Guid id);
        ArticleContract[] ListArticles();
    }
}
