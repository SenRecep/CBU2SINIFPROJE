using System.Collections.Generic;
using System.Linq;
using CBU2SINIFPROJE.Core.Entities.Interfaces;
using CBU2SINIFPROJE.Core.ExtensionMethods;
using CBU2SINIFPROJE.DAL.Concrete.MemoryDatabase.Contexts;
using CBU2SINIFPROJE.DAL.Interfaces;

namespace CBU2SINIFPROJE.DAL.Concrete.MemoryDatabase.Repositories
{
    public class MDGenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IEntityBase, new()
    {
        private readonly List<TEntity> data;
        public MDGenericRepository()
        {
            data = GeneralContext.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            var maxId = data.Max(x=>x.Id);
            entity.Id = maxId + 1;
            data.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            data.Remove(entity);
        }

        public List<TEntity> GetAll()
        {
            return data;
        }

        public void Update(TEntity entity)
        {
            var found = data.FirstOrDefault(x=>x.Id==entity.Id);
            found?.DataTransfer(entity);
        }
    }
}
