using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesseract.DA.Entities
{
    public interface IEntity
    {
        [Key]
        Guid Id { get; set; }
    }
}
