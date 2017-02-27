using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract.DA.Article.Contract;

namespace Tesseract.DA.Article
{
    public static class ArticleMapper
    {
        public static ArticleContract ToContract(this Entity.Article article, bool convertAuthors = true)
        {
            return new ArticleContract()
            {
                Id = article.Id,
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                Year = article.Year,
                Link = article.Link,
                Authors = article.Authors != null ? article.Authors.Select(x => new KeyValuePair<Guid, string>(x.Id, x.FirstName + " " + x.LastName)).ToDictionary(x => x.Key, x => x.Value) : null,
            };
        }

        public static Entity.Article ToEntity(this ArticleContract article)
        {
            return new Entity.Article()
            {
                Id = article.Id,
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                Year = article.Year,
                Link = article.Link,
                Authors = article.Authors != null ? article.Authors.Select(x => new Author.Entity.Author { Id = x.Key }).ToArray() : null
            };
        }
    }
}
