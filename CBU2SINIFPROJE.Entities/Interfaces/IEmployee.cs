using System.Collections.Generic;

using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.Entities.Interfaces
{
    public interface IEmployee
    {
        int Salary { get; set; }
        List<Vacation> Vacations { get; set; }
    }
}