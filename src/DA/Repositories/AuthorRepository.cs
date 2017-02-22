using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract.DA.Entities;

namespace Tesseract.DA.Repositories
{
    public class AuthorRepository
    {
        private AuthorsDBContext dbContext;

        public AuthorRepository()
        {
            dbContext = new AuthorsDBContext();
        }

        public IEnumerable<Author> GetAuthors()
        {
            return dbContext.Authors.ToList();
        }

        public IEnumerable<Author> GetAuthorsWithArticles()
        {
            return dbContext.Set<Author>().Include("Articles").ToList();
        }

        public Author GetAuthorById(Guid id)
        {
            return dbContext.Authors.Include("Articles").FirstOrDefault(x => x.Id == id);
        }

        public void Update(Author author)
        {
            if (author.Id == Guid.Empty)
            {
                author.Id = Guid.NewGuid();
                dbContext.Authors.Add(author);
            }
            else
            {
                Author dbAuthor = dbContext.Authors.FirstOrDefault(x => x.Id == author.Id);
                dbContext.Authors.Attach(dbAuthor);

                dbAuthor.FirstName = author.FirstName;
                dbAuthor.LastName = author.LastName;
                dbAuthor.BirthDate = author.BirthDate;
                dbAuthor.Country = author.Country;
            }
            dbContext.SaveChanges();
        }
    }
}
