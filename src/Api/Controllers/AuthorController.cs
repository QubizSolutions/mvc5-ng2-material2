using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Tesseract.Api.Models;

namespace Tesseract.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AuthorController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAuthors()
        {
            Author[] authors = Authors().ToArray();
            return Ok(authors);
        }

        [HttpGet]
        public IHttpActionResult GetAuthorById(int id)
        {
            Author author = Authors().FirstOrDefault(x=>x.Id == id);
            return Ok(author);
        }
        
        private List<Author> Authors()
        {
            return new List<Author>
            {
                new Author
                {
                    Id = 1,
                    FirstName = "Tony", LastName ="Stark",
                    BirthDate = new DateTime(1970,10,10), Country="US",
                    Articles = new Article[]
                    {
                        new Article { Id = 1, Title ="I am Iron Man", ShortDescription="About Iron man", Link = "http://marvel.wikia.com/wiki/Iron_Man", Year = 2017, AuthorIds = new int[] { 1 } },
                        new Article { Id = 1, Title ="The avengers", ShortDescription="The story of the avengers", Link = "http://marvel.wikia.com/wiki/Avengers", Year = 1995, AuthorIds = new int[] { 1, 2, 3 } }
                    }
                },
                new Author
                {
                    Id = 2,
                    FirstName = "Peter", LastName ="Parker",
                    BirthDate = new DateTime(1993,10,10), Country="US",
                    Articles = new Article[]
                    {
                        new Article { Id = 1, Title ="I am SpiderMan", ShortDescription="About Spider Man", Link = "http://marvel.wikia.com/wiki/Spider-Man", Year = 2017, AuthorIds = new int[] { 2 } },
                        new Article { Id = 1, Title ="The avengers", ShortDescription="The story of the avengers", Link = "http://marvel.wikia.com/wiki/Avengers", Year = 1995, AuthorIds = new int[] { 1, 2, 3 } }
                    }
                },
                new Author
                {
                    Id = 3,
                    FirstName = "Steve", LastName ="Rogers",
                    BirthDate = new DateTime(1993,10,10), Country="US",
                    Articles = new Article[]
                    {
                        new Article { Id = 1, Title ="I am Captain America", ShortDescription="About Spider Man", Link = "http://marvel.wikia.com/wiki/Captain_America", Year = 2017, AuthorIds = new int[] { 3 } },
                        new Article { Id = 1, Title ="The avengers", ShortDescription="The story of the avengers", Link = "http://marvel.wikia.com/wiki/Avengers", Year = 1995, AuthorIds = new int[] { 1, 2, 3 } }
                    }
                }
            };
        }
    }
}
