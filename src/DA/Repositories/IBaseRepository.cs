using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesseract.DA.Repositories
{
    public interface IBaseRepository<TModel> where TModel : class
    {
        IEnumerable<TModel> GetAll();
        TModel GetByID(Guid id);

        void Create(TModel model);
        void Update(TModel model);
        void Delete(TModel model);
    }
}
