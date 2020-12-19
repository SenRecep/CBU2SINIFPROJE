using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CBU2SINIFPROJE.Core.Entities.Interfaces;

namespace CBU2SINIFPROJE.BLL.Interfaces
{
    public interface IGenericService<TEntity>
        where TEntity : class, IEntityBase, new()
    {
        List<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
    }
}
