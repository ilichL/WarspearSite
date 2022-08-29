using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarspesrSite.Data.Entity;

namespace WarspearSite.Core.Interfaces.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
    }
}
