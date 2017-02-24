using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Tesseract.DA.Repositories;
using Tesseract.Web.Mappers;
using Tesseract.Web.Models;

namespace Tesseract.Web.Controllers.Api
{
    public class AuthorController : ApiController
    {
        private AuthorRepository authorReposotiry;
        private ArticleRepository articleReposotiry;

        public AuthorController()
        {
            authorReposotiry = new AuthorRepository();
            articleReposotiry = new ArticleRepository();
        }

        [HttpGet]
        public IHttpActionResult GetAuthors()
        {
            Author[] authors = authorReposotiry.GetAuthorsWithArticles().Select(x => x.ToModel()).ToArray();
            
            return Ok(authors);
        }

        [HttpGet]
        public IHttpActionResult GetAuthorNames()
        {
            Author[] authors = authorReposotiry.GetAuthorsWithArticles().Select(x => x.ToModel()).ToArray();

            return Ok(authors.Select(x => new KeyValuePair<Guid, string>(x.Id, x.FirstName + " " + x.LastName)).ToDictionary(x => x.Key, x => x.Value));
        }

        [HttpGet]
        public IHttpActionResult GetAuthorById(Guid id)
        {
            Author author = authorReposotiry.GetAuthorById(id).ToModel();
            return Ok(author);
        }

        [HttpPost]
        public IHttpActionResult UpdateAuthor(Author author)
        {
            authorReposotiry.Update(author.ToEntity());
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetArticleById(Guid id)
        {
            Article article = articleReposotiry.GetArticleById(id).ToModel();
            return Ok(article);
        }

        [HttpPost]
        public IHttpActionResult UpdateArticle(Article article)
        {
            articleReposotiry.Update(article.ToEntity());
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteArticleById(Guid id)
        {
            articleReposotiry.DeleteArticleById(id);
            return Ok();
        }
    }
}
