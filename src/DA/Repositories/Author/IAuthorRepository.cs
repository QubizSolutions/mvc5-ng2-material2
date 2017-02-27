using System;
using Tesseract.DA.Author.Contract;

namespace Tesseract.DA.Repositories
{
    public interface IAuthorRepository : IBaseRepository<Author.Entity.Author>
    {
        void Create(AuthorContract author);
        void Update(AuthorContract author);
        AuthorContract GetById(Guid id);
        AuthorContract[] ListAuthors();
        AuthorContract[] ListByIds(Guid[] ids);
    }
}
