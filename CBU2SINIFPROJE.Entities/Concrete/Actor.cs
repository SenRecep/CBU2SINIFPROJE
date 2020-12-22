using CBU2SINIFPROJE.Core.Enums;
using CBU2SINIFPROJE.Entities.Interfaces;
using System.Collections.Generic;


namespace CBU2SINIFPROJE.Entities.Concrete
{
    public class Actor : Employee, IActor
    {
        public List<Project> Projects { get; set; }
        public Field Field { get; set; }
    }
}
