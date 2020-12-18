using CBU2SINIFPROJE.Entities.Interfaces;

using System.Collections.Generic;

namespace CBU2SINIFPROJE.Entities.Concrete
{
    public class Company : ICompany
    {
        public string Name { get; set; }
        public Adress Adress { get; set; }
        public List<Project> Projects { get; set; }
    }
}
