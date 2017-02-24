using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract.DA.Repositories;
using Tesseract.Infrastructure;

namespace Tesseract.DA
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IConfig config;

        public UnitOfWorkFactory(IConfig config)
        {
            this.config = config;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(config);
        }
    }
}
