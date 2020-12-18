using System.Collections.Generic;

using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.Entities.Interfaces
{
    public interface IEmployee
    {
        decimal Salary { get; set; }
        List<Vacation> Vacations { get; set; }
    }
}