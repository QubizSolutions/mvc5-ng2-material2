using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract.DA.Author.Entity;

namespace Tesseract.DA
{
    public class AuthorsDBContext : DbContext
    {
        public AuthorsDBContext(string connectionString) : base(connectionString)
        {
        }

        public AuthorsDBContext() : base("AuthorContext")
        {
        }


        public DbSet<Author.Entity.Author> Authors { get; set; }

        public DbSet<Article.Entity.Article> Articles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
