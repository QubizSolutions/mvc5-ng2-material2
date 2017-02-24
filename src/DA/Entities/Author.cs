using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesseract.DA.Entities
{
    public class Author : IEntity
    {
        public Author()
        {
            this.Articles = new HashSet<Article>();
        }

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Country { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}