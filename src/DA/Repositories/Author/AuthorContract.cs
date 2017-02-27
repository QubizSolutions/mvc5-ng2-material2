using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesseract.DA.Article.Contract;
using Tesseract.DA.Author;

namespace Tesseract.DA.Author.Contract
{
    public class AuthorContract
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Country { get; set; }

        public ArticleContract[] Articles { get; set; }
    }
}