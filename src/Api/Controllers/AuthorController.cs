using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Tesseract.Services.Models;
using Tesseract.Services.Services;

namespace Tesseract.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AuthorController : ApiController
    {
        private IAuthorService authorService;
        private IArticleService articleService;

        public AuthorController(IAuthorService authorService, IArticleService articleService)
        {
            this.authorService = authorService;
            this.articleService = articleService;
        }

        [HttpGet]
        public IHttpActionResult GetAuthors()
        {
            Author[] authors = authorService.GetAuthors().ToArray();
            
            return Ok(authors);
        }

        [HttpGet]
        public IHttpActionResult GetAuthorNames()
        {
            Author[] authors = authorService.GetAuthors().ToArray();

            return Ok(authors.Select(x => new KeyValuePair<Guid, string>(x.Id, x.FirstName + " " + x.LastName)).ToDictionary(x => x.Key, x => x.Value));
        }

        [HttpGet]
        public IHttpActionResult GetAuthorById(Guid id)
        {
            Author author = authorService.GetAuthorById(id);
            return Ok(author);
        }

        [HttpPost]
        public IHttpActionResult UpdateAuthor(Author author)
        {
            authorService.UpdateAuthor(author);
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetArticleById(Guid id)
        {
            Article article = articleService.GetArticleById(id);
            return Ok(article);
        }

        [HttpPost]
        public IHttpActionResult UpdateArticle(Article article)
        {
            articleService.UpdateArticle(article);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteArticleById(Guid id)
        {
            articleService.DeleteArticleById(id);
            return Ok();
        }
    }
}
