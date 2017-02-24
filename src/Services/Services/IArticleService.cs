using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract.Services.Models;

namespace Tesseract.Services.Services
{
    public interface IArticleService
    {
        void UpdateArticle(Article article);
        Article GetArticleById(Guid id);
        void DeleteArticleById(Guid id);
    }
}
