using System;
using Tesseract.DA;
using Tesseract.DA.Author.Contract;
using Tesseract.DA.Repositories;

namespace Tesseract.Services.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public AuthorService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public void UpdateAuthor(AuthorContract author)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                if(author.Id == Guid.Empty)
                {
                    author.Id = Guid.NewGuid();
                    unitOfWork.AuthorRepository.Create(author);
                }
                else
                {
                    unitOfWork.AuthorRepository.Update(author);
                }
                unitOfWork.Save();
            }
        }

        public AuthorContract[] GetAuthors()
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.AuthorRepository.ListAuthors();
            }
        }

        public AuthorContract GetAuthorById(Guid id)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.AuthorRepository.GetById(id);
            }
        }
    }
}
