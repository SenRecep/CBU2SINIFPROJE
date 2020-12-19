using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.BLL.Interfaces
{
   public interface IProjectService
    {
        public void AddProject(List<Actor> actors,List<OfficeWorker> officeWorkers,Company company,Project project);
    }
}
