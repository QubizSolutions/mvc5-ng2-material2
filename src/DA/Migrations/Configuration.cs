namespace Tesseract.DA.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Tesseract.DA.AuthorsDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Tesseract.DA.AuthorsDBContext context)
        {
            Guid authorID1 = new Guid("1ac38fe2-8231-43d9-a96f-1ab7b293864a");
            Guid authorID2 = new Guid("1ac38fe2-8231-43d9-a96f-1ab7b293864b");
            Guid authorID3 = new Guid("1ac38fe2-8231-43d9-a96f-1ab7b293864c");

            Guid articleID1 = new Guid("1ac38fe2-8231-43d9-a96f-1ab7b293864d");
            Guid articleID2 = new Guid("1ac38fe2-8231-43d9-a96f-1ab7b293864e");
            Guid articleID3 = new Guid("1ac38fe2-8231-43d9-a96f-1ab7b293864f");
            Guid articleID4 = new Guid("1ac38fe2-8231-43d9-a96f-1ab7b2938641");
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            context.Authors.AddOrUpdate( p => p.Id,
                new Author
                {
                    Id = authorID1,
                    FirstName = "Tony",
                    LastName = "Stark",
                    BirthDate = new DateTime(1970, 10, 10),
                    Country = "US",
                },
                new Author
                {
                    Id = authorID2,
                    FirstName = "Peter",
                    LastName = "Parker",
                    BirthDate = new DateTime(1993, 10, 10),
                    Country = "US",
                },
                new Author
                {
                    Id = authorID3,
                    FirstName = "Steve",
                    LastName = "Rogers",
                    BirthDate = new DateTime(1920, 10, 10),
                    Country = "US",
                });

            context.SaveChanges();

            Author author1 = GetAuthorByID(context, authorID1);
            Author author2 = GetAuthorByID(context, authorID2);
            Author author3 = GetAuthorByID(context, authorID3);

            context.Articles.AddOrUpdate(p => p.Id,
                new Article
                {
                    Id = articleID1,
                    Title = "The avengers",
                    ShortDescription = "The story of the avengers",
                    Link = "http://marvel.wikia.com/wiki/Avengers",
                    Year = 1995,
                    Authors = new List<Author> { author1, author2, author3 }
                },
                new Article
                {
                    Id = articleID2,
                    Title = "I am Iron Man",
                    ShortDescription = "About Iron man",
                    Link = "http://marvel.wikia.com/wiki/Iron_Man",
                    Year = 2017,
                    Authors = new List<Author> { author1 }
                },
                new Article
                {
                    Id = articleID3,
                    Title = "I am SpiderMan",
                    ShortDescription = "About Spider Man",
                    Link = "http://marvel.wikia.com/wiki/Spider-Man",
                    Year = 2017,
                    Authors = new List<Author> { author2 }
                },
                new Article
                {
                    Id = articleID4,
                    Title = "I am Captain America",
                    ShortDescription = "About Spider Man",
                    Link = "http://marvel.wikia.com/wiki/Captain_America",
                    Year = 2017,
                    Authors = new List<Author> { author3 }
                });
            context.SaveChanges();
        }

        private Author GetAuthorByID(Tesseract.DA.AuthorsDBContext context, Guid id)
        {
            return context.Authors.SingleOrDefault(x => x.Id == id);
        }
    }
}
