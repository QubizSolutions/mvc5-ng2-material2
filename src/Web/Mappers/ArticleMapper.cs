using System;
using System.Collections.Generic;
using System.Linq;
using Tesseract.Web.Models;

namespace Tesseract.Web.Mappers
{
    public static class ArticleMapper
    {
        public static Article ToModel(this DA.Entities.Article article, bool convertAuthors = true)
        {
            return new Article()
            {
                Id = article.Id,
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                Year = article.Year,
                Link = article.Link,
                Authors =  article.Authors != null ? article.Authors.Select(x => new KeyValuePair<Guid, string>(x.Id, x.FirstName + " " + x.LastName)).ToDictionary(x=>x.Key, x=>x.Value) : null,
            };
        }

        public static DA.Entities.Article ToEntity(this Article article)
        {
            return new DA.Entities.Article()
            {
                Id = article.Id,
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                Year = article.Year,
                Link = article.Link,
                Authors = article.Authors != null ? article.Authors.Select(x => new DA.Entities.Author { Id = x.Key }).ToArray() : null
            };
        }
    }
}