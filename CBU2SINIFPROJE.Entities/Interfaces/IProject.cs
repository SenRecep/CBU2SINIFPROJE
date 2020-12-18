using System.Collections.Generic;

using CBU2SINIFPROJE.Core.Entities.Interfaces;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.Entities.Interfaces
{
    public interface IProject:IEntityBase
    {
        Company Company { get; set; }
        decimal Cost { get; set; }
        Duration Duration { get; set; }
        List<Employee> Employees { get; set; }
        string Name { get; set; }
    }
}