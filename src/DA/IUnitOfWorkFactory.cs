using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract.DA.Repositories;

namespace Tesseract.DA
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
