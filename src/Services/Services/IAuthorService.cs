using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract.Services.Models;

namespace Tesseract.Services.Services
{
    public interface IAuthorService
    {
        void UpdateAuthor(Author author);
        IEnumerable<Author> GetAuthors();
        Author GetAuthorById(Guid id);
    }
}
