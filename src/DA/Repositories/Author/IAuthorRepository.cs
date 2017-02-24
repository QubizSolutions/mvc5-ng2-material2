using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract.DA.Entities;

namespace Tesseract.DA.Repositories
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        IEnumerable<Author> ListAuthors();
        IEnumerable<Author> ListByIds(Guid[] ids);
    }
}
