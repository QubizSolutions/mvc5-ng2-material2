using System.Linq;
using Tesseract.DA.Article.Contract;
using Tesseract.DA.Article;
using Tesseract.DA.Author.Contract;

namespace Tesseract.DA.Author
{
    public static class AuthorMapper
    {
        public static AuthorContract ToContract(this Entity.Author author, bool convertArticles = true)
        {
            return new AuthorContract()
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                BirthDate = author.BirthDate,
                Country = author.Country,
                Articles = convertArticles && author.Articles != null ? author.Articles.Select(x => x.ToContract(false)).ToArray() : new ArticleContract[0]
            };
        }

        public static Entity.Author ToEntity(this AuthorContract author)
        {
            return new Entity.Author()
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                BirthDate = author.BirthDate,
                Country = author.Country,
                Articles = author.Articles != null ? author.Articles.Select(x => x.ToEntity()).ToArray() : null
            };
        }
    }
}
