using System;

using CBU2SINIFPROJE.Core.Enums;
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.Entities.Concrete;
using CBU2SINIFPROJE.BLL.ExtensionMethods;

namespace CBU2SINIFPROJE.BLL.Concrete
{
    public class OfficeWorkerManager : IOfficeWorkerService
    {
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
    }
}
