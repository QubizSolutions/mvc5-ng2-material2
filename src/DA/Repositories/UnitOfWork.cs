using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract.Infrastructure;

namespace Tesseract.DA.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AuthorsDBContext dbContext;

        private IArticleRepository articleRepository;
        private IAuthorRepository authorRepository;

        public UnitOfWork(IConfig config)
        {
            dbContext = new AuthorsDBContext(config.ConnectionString);
        }

        
        public IArticleRepository ArticleRepository
        {
            get
            {
                if (articleRepository == null)
                {
                    articleRepository = new ArticleRepository(dbContext, this);
                }

                return articleRepository;
            }
        }

        public IAuthorRepository AuthorRepository
        {
            get
            {
                if (authorRepository == null)
                {
                    authorRepository = new AuthorRepository(dbContext, this);
                }

                return authorRepository;
            }
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
