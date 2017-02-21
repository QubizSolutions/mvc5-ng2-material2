using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesseract.Api.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public int Year { get; set; }

        public string Link { get; set; }

        public Dictionary<int, string> Authors { get; set; }
    }
}