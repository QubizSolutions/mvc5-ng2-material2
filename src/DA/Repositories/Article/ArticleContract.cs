using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesseract.DA.Article.Contract
{
    public class ArticleContract
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public int Year { get; set; }

        public string Link { get; set; }

        public Dictionary<Guid, string> Authors { get; set; }
    }
}