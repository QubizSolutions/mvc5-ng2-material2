using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract.DA.Author;
using Tesseract.DA.Author.Contract;

namespace Tesseract.DA.Repositories
{
    public class AuthorRepository : BaseRepository<Author.Entity.Author>, IAuthorRepository
    {
        public AuthorRepository(AuthorsDBContext context, UnitOfWork unitOfWork)
            : base(context, unitOfWork)
        { }

        public void Create(AuthorContract author)
        {
            dbSet.Add(author.ToEntity());
        }

        public void Update(AuthorContract author)
        {
            Author.Entity.Author authorEntity = dbSet.FirstOrDefault(x => x.Id == author.Id);

            dbSet.Attach(authorEntity);

            authorEntity.FirstName = author.FirstName;
            authorEntity.LastName = author.LastName;
            authorEntity.BirthDate = author.BirthDate;
            authorEntity.Country = author.Country;

            dbContext.Entry(authorEntity).State = System.Data.Entity.EntityState.Modified;
        }

        public AuthorContract GetById(Guid id)
        {
            return dbSet.FirstOrDefault().ToContract(true);
        }

        public AuthorContract[] ListAuthors()
        {
            Author.Entity.Author[] authors = dbSet.ToArray();
            return authors.Select(x => x.ToContract(false)).ToArray();
        }

        public AuthorContract[] ListByIds(Guid[] ids)
        {
            return dbSet.Where(x => ids.Contains(x.Id)).Select(x => x.ToContract(false)).ToArray();
        }
    }
}
