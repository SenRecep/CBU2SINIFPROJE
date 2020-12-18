using System.Collections.Generic;

using CBU2SINIFPROJE.Entities.Interfaces;

namespace CBU2SINIFPROJE.Entities.Concrete
{
    public class Project : IProject
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public List<Employee> Employees { get; set; }
        public Company Company { get; set; }
        public Duration Duration { get; set; }
    }
}
