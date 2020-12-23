using CBU2SINIFPROJE.Core.Enums;
using CBU2SINIFPROJE.Entities.Interfaces;

using System.Collections.Generic;

namespace CBU2SINIFPROJE.Entities.Concrete
{
    public class Employee : Person, IEmployee
    {
        public EmployeeState State { get; set; }
        public int Salary { get; set; }
        public List<Vacation> Vacations { get; set; }
    }
}
