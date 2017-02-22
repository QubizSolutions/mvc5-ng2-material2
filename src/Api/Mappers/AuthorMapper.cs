using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesseract.Api.Models;

namespace Tesseract.Api.Mappers
{
    public static class AuthorMapper
    {
        public static Author ToModel(this DA.Entities.Author author, bool convertArticles = true)
        {
            return new Author()
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                BirthDate = author.BirthDate,
                Country = author.Country,
                Articles = convertArticles && author.Articles != null ? author.Articles.Select(x => x.ToModel(false)).ToArray() : null
            };
        }

        public static DA.Entities.Author ToEntity(this Author author)
        {
            return new DA.Entities.Author()
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