using System.Collections.Generic;

using CBU2SINIFPROJE.Entities.Concrete;
using CBU2SINIFPROJE.Entities.Enums;

namespace CBU2SINIFPROJE.Entities.Interfaces
{
    public interface IActor
    {
        Field Field { get; set; }
        List<Project> Projects { get; set; }
    }
}