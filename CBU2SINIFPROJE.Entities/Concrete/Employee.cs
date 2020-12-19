using CBU2SINIFPROJE.Entities.Interfaces;

using System.Collections.Generic;

namespace CBU2SINIFPROJE.Entities.Concrete
{
    public class Employee : Person, IEmployee
    {
        public int Salary { get; set; }
        public List<Vacation> Vacations { get; set; }
    }
}
