using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.DAL.Interfaces;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.BLL.Concrete
{
    public class ActorManager : IActorService
    {
        private readonly IActorDal actorRepo;
        private readonly IGenericRepository<Actor> genericRepository;

        public ActorManager(IActorDal actorRepo,IGenericRepository<Actor> genericRepository)
        {
            this.actorRepo = actorRepo;
            this.genericRepository = genericRepository;
        }
    }
}
