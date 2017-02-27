using System;
using System.Linq;
using Tesseract.DA;
using Tesseract.DA.Article.Contract;
using Tesseract.DA.Repositories;

namespace Tesseract.Services.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public ArticleService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public void UpdateArticle(ArticleContract article)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                if (article.Id == Guid.Empty)
                {
                    article.Id = Guid.NewGuid();
                    unitOfWork.ArticleRepository.Create(article, article.Authors.Select(x => x.Key).ToArray());
                }
                else
                {
                    unitOfWork.ArticleRepository.Update(article, article.Authors.Select(x => x.Key).ToArray());
                }
                unitOfWork.Save();
            }
        }
        

        public ArticleContract GetArticleById(Guid id)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.ArticleRepository.GetById(id);
            }
        }

        public void DeleteArticleById(Guid id)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                unitOfWork.ArticleRepository.DeleteById(id);
                unitOfWork.Save();
            }
        }
    }
}
