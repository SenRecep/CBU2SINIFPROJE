using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CBU2SINIFPROJE.Core.Enums;
using CBU2SINIFPROJE.BLL.ExtensionMethods;
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.DAL.Interfaces;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.BLL.Concrete
{
    public class ActorManager : IActorService
    {
        private readonly IGenericRepository<Actor> genericRepository;
        private readonly IGenericRepository<Project> projectRepository;

        public ActorManager(IGenericRepository<Actor> genericRepository, IGenericRepository<Project> projectRepository)
        {
            this.genericRepository = genericRepository;
            this.projectRepository = projectRepository;
        }

        public void DeleteActor(Actor actor)
        {
            genericRepository.Delete(actor);
            //var projects = projectRepository.GetAll();
            //projects.ForEach(project =>
            //    project.Employees.RemoveAll(x => x is Actor && x.Id == actor.Id)
            //);
        }

        public EmployeeState IsFree(Actor actor)
        {
            if (!actor.Vacations.IsNull())
                foreach (var item in actor.Vacations)
                    if (item.Duration.StartDate < DateTime.Now && item.Duration.EndDate > DateTime.Now)
                        return EmployeeState.Izinde;
            if (!actor.Projects.IsNull())
                foreach (var item in actor.Projects)
                    if (item.Duration.StartDate < DateTime.Now && item.Duration.EndDate > DateTime.Now)
                        return EmployeeState.Calisiyor;
            return EmployeeState.Bosta;
        }
    }
}
