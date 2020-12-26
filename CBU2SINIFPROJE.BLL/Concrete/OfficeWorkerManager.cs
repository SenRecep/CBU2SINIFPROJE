using System;

using CBU2SINIFPROJE.Core.Enums;
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.Entities.Concrete;
using CBU2SINIFPROJE.BLL.ExtensionMethods;
using System.Collections.Generic;
using CBU2SINIFPROJE.DAL.Interfaces;
using System.Linq;

namespace CBU2SINIFPROJE.BLL.Concrete
{
    public class OfficeWorkerManager : IOfficeWorkerService
    {
        private readonly IGenericRepository<OfficeWorker> genericRepository;

        public OfficeWorkerManager(IGenericRepository<OfficeWorker> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public IEnumerable<OfficeWorker> GetAllFreeOfficeWorker(Duration duration)
        {
            var all = genericRepository.GetAll();
            foreach (var item in all)
                if (IsFree(item, duration) == EmployeeState.Bosta)
                    yield return item;
        }

        public IEnumerable<OfficeWorker> GetAllFreeOfficeWorker()
        {
            var all = genericRepository.GetAll();
            foreach (var item in all)
                if (IsFree(item) == EmployeeState.Bosta)
                    yield return item;
        }

        public List<OfficeWorker> GetMonthlyOfficeWorkers(List<Project> projects)
        {
            List<OfficeWorker> result = new List<OfficeWorker>();
            var officeWorkers = genericRepository.GetAll();
            foreach (var officeWorker in officeWorkers)
                if (!officeWorker.Projects.IsNull())
                    foreach (var project in officeWorker.Projects)
                    if (projects.Contains(project))
                    {
                        result.Add(officeWorker);
                        break;
                    }
            return result.Distinct().ToList();
        }

        public EmployeeState IsFree(OfficeWorker officeWorker)
        {
            if (!officeWorker.Vacations.IsNull())
                foreach (var item in officeWorker.Vacations)
                    if (item.Duration.StartDate < DateTime.Now && item.Duration.EndDate > DateTime.Now)
                        return EmployeeState.Izinde;
            if (!officeWorker.Projects.IsNull())
                foreach (var item in officeWorker.Projects)
                    if (item.Duration.StartDate < DateTime.Now && item.Duration.EndDate > DateTime.Now)
                        return EmployeeState.Calisiyor;
            return EmployeeState.Bosta;
        }

        public EmployeeState IsFree(OfficeWorker officeWorker, Duration duration)
        {
            if (!officeWorker.Vacations.IsNull())
                foreach (var item in officeWorker.Vacations)
                    if (item.Duration.StartDate <= duration.StartDate && item.Duration.EndDate >= duration.EndDate)
                        return EmployeeState.Izinde;
            if (!officeWorker.Projects.IsNull())
                foreach (var item in officeWorker.Projects)
                    if (item.Duration.StartDate <= duration.StartDate && item.Duration.EndDate >= duration.EndDate)
                        return EmployeeState.Calisiyor;
            return EmployeeState.Bosta;
        }
    }
}
