using System.Collections.Generic;

using CBU2SINIFPROJE.Core.Entities.Interfaces;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.Entities.Interfaces
{
    public interface ICompany:IEntityBase
    {
        Adress Adress { get; set; }
        string Name { get; set; }
        List<Project> Projects { get; set; }
    }
}