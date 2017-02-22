using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Tesseract.Api.Mappers;
using Tesseract.Api.Models;
using Tesseract.DA.Repositories;

namespace Tesseract.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AuthorController : ApiController
    {
        private AuthorRepository authorReposotiry;
        private ArticleRepository articleReposotiry;

        public AuthorController()
        {
            authorReposotiry = new AuthorRepository();
            articleReposotiry = new ArticleRepository();
        }

        Guid authorID1 = new Guid("1ac38fe2-8231-43d9-a96f-1ab7b293864a");
        Guid authorID2 = new Guid("1ac38fe2-8231-43d9-a96f-1ab7b293864b");
        Guid authorID3 = new Guid("1ac38fe2-8231-43d9-a96f-1ab7b293864c");

        Guid articleID1 = new Guid("1ac38fe2-8231-43d9-a96f-1ab7b293864d");
        Guid articleID2 = new Guid("1ac38fe2-8231-43d9-a96f-1ab7b293864e");
        Guid articleID3 = new Guid("1ac38fe2-8231-43d9-a96f-1ab7b293864f");
        Guid articleID4 = new Guid("1ac38fe2-8231-43d9-a96f-1ab7b2938641");

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
        

        private List<Author> Authors()
        {
            return new List<Author>
            {
                new Author
                {
                    Id = authorID1,
                    FirstName = "Tony", LastName ="Stark",
                    BirthDate = new DateTime(1970,10,10), Country="US",
                    Articles = new Article[]
                    {
                        new Article { Id = articleID1, Title ="The avengers", ShortDescription="The story of the avengers", Link = "http://marvel.wikia.com/wiki/Avengers", Year = 1995, Authors = new Dictionary<Guid, string> { { authorID1, "Tony Stark" }, { authorID2, "Peter Parker" }, { authorID3, "Steve Rogers" } } },
                        new Article { Id = articleID2, Title ="I am Iron Man", ShortDescription="About Iron man", Link = "http://marvel.wikia.com/wiki/Iron_Man", Year = 2017, Authors = new Dictionary<Guid, string> { { authorID1, "Tony Stark" } } },
                    }
                },
                new Author
                {
                    Id = authorID2,
                    FirstName = "Peter", LastName ="Parker",
                    BirthDate = new DateTime(1993,10,10), Country="US",
                    Articles = new Article[]
                    {
                        new Article { Id = articleID1, Title ="The avengers", ShortDescription="The story of the avengers", Link = "http://marvel.wikia.com/wiki/Avengers", Year = 1995, Authors = new Dictionary<Guid, string> { { authorID1, "Tony Stark" }, { authorID2, "Peter Parker" }, { authorID3, "Steve Rogers" } } },
                        new Article { Id = articleID3, Title ="I am SpiderMan", ShortDescription="About Spider Man", Link = "http://marvel.wikia.com/wiki/Spider-Man", Year = 2017, Authors = new Dictionary<Guid, string> { { authorID2, "Peter Parker" } } },
                    }
                },
                new Author
                {
                    Id = authorID3,
                    FirstName = "Steve", LastName ="Rogers",
                    BirthDate = new DateTime(1993,10,10), Country="US",
                    Articles = new Article[]
                    {
                        new Article { Id =  articleID1, Title ="The avengers", ShortDescription="The story of the avengers", Link = "http://marvel.wikia.com/wiki/Avengers", Year = 1995, Authors = new Dictionary<Guid, string> { { authorID1, "Tony Stark" }, { authorID2, "Peter Parker" }, { authorID3, "Steve Rogers" } } },
                        new Article { Id =  articleID4, Title ="I am Captain America", ShortDescription="About Spider Man", Link = "http://marvel.wikia.com/wiki/Captain_America", Year = 2017, Authors = new Dictionary<Guid, string> { { authorID3, "Steve Rogers"} } },
                    }
                }
            };
        }

        private List<Article> Articles()
        {
            return new List<Article>()
            {
                 new Article { Id = articleID1, Title ="The avengers", ShortDescription="The story of the avengers", Link = "http://marvel.wikia.com/wiki/Avengers", Year = 1995, Authors = new Dictionary<Guid, string> { { authorID1, "Tony Stark" }, { authorID2, "Peter Parker" }, { authorID3, "Steve Rogers" } } },
                 new Article { Id = articleID2, Title ="I am Iron Man", ShortDescription="About Iron man", Link = "http://marvel.wikia.com/wiki/Iron_Man", Year = 2017, Authors = new Dictionary<Guid, string> { { authorID1, "Tony Stark" } } },
                 new Article { Id = articleID3, Title ="I am SpiderMan", ShortDescription="About Spider Man", Link = "http://marvel.wikia.com/wiki/Spider-Man", Year = 2017, Authors = new Dictionary<Guid, string> { { authorID2, "Peter Parker" } } },
                 new Article { Id =  articleID4, Title ="I am Captain America", ShortDescription="About Spider Man", Link = "http://marvel.wikia.com/wiki/Captain_America", Year = 2017, Authors = new Dictionary<Guid, string> { { authorID3, "Steve Rogers"} } },
            };
        }
    }
}
