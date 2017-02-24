using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract.DA.Entities;

namespace Tesseract.DA
{
    public class AuthorsDBContext : DbContext
    {
        public AuthorsDBContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
