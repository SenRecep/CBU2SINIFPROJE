using CBU2SINIFPROJE.Entities.Interfaces;

using System.Collections.Generic;

namespace CBU2SINIFPROJE.Entities.Concrete
{
    public class Employee : Person, IEmployee
    {
        public decimal Salary { get; set; }
        public List<Vacation> Vacations { get; set; }
    }
}
