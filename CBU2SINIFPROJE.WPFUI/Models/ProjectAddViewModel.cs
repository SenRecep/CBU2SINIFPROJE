using CBU2SINIFPROJE.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
