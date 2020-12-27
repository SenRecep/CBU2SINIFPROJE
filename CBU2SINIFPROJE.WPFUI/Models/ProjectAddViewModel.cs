using System.Collections.Generic;

using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.WPFUI.Models
{
    public class ProjectAddViewModel
    {
        public Company Company { get; set; }
        public Project Project { get; set; }
        public List<Company> Companies { get; set; }
        public List<Actor> Actors { get; set; }
        public List<OfficeWorker> OfficeWorkers { get; set; }
    }
}
