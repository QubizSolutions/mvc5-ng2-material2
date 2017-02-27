using System.Data.Entity;

namespace Tesseract.DA.Repositories
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : class
    {
        protected DbContext dbContext;
        protected DbSet<TModel> dbSet;

        protected UnitOfWork unitOfWork;

        public BaseRepository(DbContext context, UnitOfWork unitOfWork)
        {
            this.dbContext = context;
            this.dbSet = dbContext.Set<TModel>();
            this.unitOfWork = unitOfWork;
        }
    }
}
