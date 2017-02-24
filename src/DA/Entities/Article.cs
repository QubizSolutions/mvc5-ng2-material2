using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesseract.DA.Entities
{
    public class Article: IEntity
    {
        public Article()
        {
            this.Authors = new HashSet<Author>();
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public int Year { get; set; }

        public string Link { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}