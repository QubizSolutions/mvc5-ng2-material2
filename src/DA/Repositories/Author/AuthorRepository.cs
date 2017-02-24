using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract.DA.Entities;

namespace Tesseract.DA.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(AuthorsDBContext context, UnitOfWork unitOfWork)
            : base(context, unitOfWork)
        { }

        public IEnumerable<Author> ListAuthors()
        {
            return dbSet.Include("Articles").ToList();
        }

        public IEnumerable<Author> ListByIds(Guid[] ids)
        {
            return dbSet.Where(x => ids.Contains(x.Id));
        }
    }
}
