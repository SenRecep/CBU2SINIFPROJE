using System.Collections.Generic;

using CBU2SINIFPROJE.Core.Enums;
using CBU2SINIFPROJE.Entities.Interfaces;


namespace CBU2SINIFPROJE.Entities.Concrete
{
    public class OfficeWorker : Employee, IOfficeWorker
    {
        public List<Project> Projects { get; set; }
        public Position Position { get; set; }
    }
}
