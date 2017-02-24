using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesseract.Services.Models
{
    public class Author
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Country { get; set; }

        public Article[] Articles { get; set; }
    }
}