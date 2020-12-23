using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CBU2SINIFPROJE.Core.Enums;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.BLL.Interfaces
{
   public interface IOfficeWorkerService
    {
        EmployeeState IsFree(OfficeWorker officeWorker);
    }
}
