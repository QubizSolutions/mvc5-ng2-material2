using System;
using Tesseract.DA.Article.Contract;

namespace Tesseract.Services.Services
{
    public interface IArticleService
    {
        void UpdateArticle(ArticleContract article);
        ArticleContract GetArticleById(Guid id);
        void DeleteArticleById(Guid id);
    }
}
