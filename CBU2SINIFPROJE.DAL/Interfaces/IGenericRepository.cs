using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CBU2SINIFPROJE.Core.Entities.Interfaces;

namespace CBU2SINIFPROJE.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> 
        where TEntity: class ,IEntityBase,new() 
    {

    }
}
