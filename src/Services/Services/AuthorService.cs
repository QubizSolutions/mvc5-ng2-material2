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
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public AuthorService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public void UpdateAuthor(Author author)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                if(author.Id == Guid.Empty)
                {
                    author.Id = Guid.NewGuid();
                    unitOfWork.AuthorRepository.Create(Mapper.DeepCopyTo<DA.Entities.Author>(author));
                }
                else
                {
                    unitOfWork.AuthorRepository.Update(Mapper.DeepCopyTo<DA.Entities.Author>(author));
                }
                unitOfWork.Save();
            }
        }

        public IEnumerable<Author> GetAuthors()
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
               return unitOfWork.AuthorRepository.ListAuthors().Select(x=> Mapper.DeepCopyTo<Author>(x));
            }
        }

        public Author GetAuthorById(Guid id)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return Mapper.DeepCopyTo<Author>(unitOfWork.AuthorRepository.GetByID(id));
            }
        }
    }
}
