using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract.DA.Entities;

namespace Tesseract.DA.Repositories
{
    public interface IArticleRepository: IBaseRepository<Article>
    {
        IEnumerable<Article> ListArticles();
        void Update(Article article, Author[] authors);
        void DeleteById(Guid id);
    }
}
