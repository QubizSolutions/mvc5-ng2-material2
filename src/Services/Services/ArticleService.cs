using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract.DA;
using Tesseract.DA.Repositories;
using Tesseract.Infrastructure;
using Tesseract.Services.Models;

namespace Tesseract.Services.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public ArticleService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public void UpdateArticle(Article article)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                DA.Entities.Author[] authors = unitOfWork.AuthorRepository.ListByIds(article.Authors.Select(x => x.Key).ToArray()).ToArray();

                if (article.Id == Guid.Empty)
                {
                    article.Id = Guid.NewGuid();
                    DA.Entities.Article entity = Mapper.DeepCopyTo<DA.Entities.Article>(article);
                    entity.Authors = authors;
                    unitOfWork.ArticleRepository.Create(entity);
                }
                else
                {
                    unitOfWork.ArticleRepository.Update(Mapper.DeepCopyTo<DA.Entities.Article>(article), authors);
                }
                unitOfWork.Save();
            }
        }
        

        public Article GetArticleById(Guid id)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return Mapper.DeepCopyTo<Article>(unitOfWork.ArticleRepository.GetByID(id));
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
