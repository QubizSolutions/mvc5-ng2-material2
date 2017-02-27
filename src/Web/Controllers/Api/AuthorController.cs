using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Tesseract.DA.Article.Contract;
using Tesseract.DA.Author.Contract;
using Tesseract.Services.Services;

namespace Tesseract.Web.Controllers.Api
{
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
            AuthorContract[] authors = authorService.GetAuthors().ToArray();
            
            return Ok(authors);
        }

        [HttpGet]
        public IHttpActionResult GetAuthorNames()
        {
            AuthorContract[] authors = authorService.GetAuthors().ToArray();

            return Ok(authors.Select(x => new KeyValuePair<Guid, string>(x.Id, x.FirstName + " " + x.LastName)).ToDictionary(x => x.Key, x => x.Value));
        }

        [HttpGet]
        public IHttpActionResult GetAuthorById(Guid id)
        {
            AuthorContract author = authorService.GetAuthorById(id);
            return Ok(author);
        }

        [HttpPost]
        public IHttpActionResult UpdateAuthor(AuthorContract author)
        {
            authorService.UpdateAuthor(author);
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetArticleById(Guid id)
        {
            ArticleContract article = articleService.GetArticleById(id);
            return Ok(article);
        }

        [HttpPost]
        public IHttpActionResult UpdateArticle(ArticleContract article)
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
