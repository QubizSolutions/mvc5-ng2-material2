using System;
using Tesseract.DA.Author.Contract;

namespace Tesseract.Services.Services
{
    public interface IAuthorService
    {
        void UpdateAuthor(AuthorContract author);
        AuthorContract[] GetAuthors();
        AuthorContract GetAuthorById(Guid id);
    }
}
