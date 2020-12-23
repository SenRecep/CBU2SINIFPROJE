using System;

using CBU2SINIFPROJE.Core.Enums;
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.BLL.Concrete
{
    public class OfficeWorkerManager : IOfficeWorkerService
    {
        public EmployeeState IsFree(OfficeWorker officeWorker)
        {
            foreach (Vacation item in officeWorker.Vacations)
                if (item.Duration.StartDate < DateTime.Now && item.Duration.EndDate > DateTime.Now)
                    return EmployeeState.Izinde;

            foreach (Project item in officeWorker.Projects)
                if (item.Duration.StartDate < DateTime.Now && item.Duration.EndDate > DateTime.Now)
                    return EmployeeState.Calisiyor;
            return EmployeeState.Bosta;
        }
    }
}
