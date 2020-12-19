using System.Collections.Generic;

using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.Core.Entities.Interfaces;
using CBU2SINIFPROJE.DAL.Interfaces;

namespace CBU2SINIFPROJE.BLL.Concrete
{
    public class GenericManager<TEntity> : IGenericService<TEntity>
          where TEntity : class, IEntityBase, new()
    {
        private readonly IGenericRepository<TEntity> repository;

        public GenericManager(IGenericRepository<TEntity> repository)
        {
            this.repository = repository;
        }
        public void Add(TEntity entity)
        {
            repository.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            repository.Delete(entity);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
        public void Update(TEntity entity)
        {
            repository.Update(entity);
        }
        public List<TEntity> GetAll()
        {
            return repository.GetAll();
        }
    }
}
