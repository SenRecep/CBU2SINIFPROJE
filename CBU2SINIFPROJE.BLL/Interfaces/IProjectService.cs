using System.Collections.Generic;

using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.BLL.Interfaces
{
    public interface IProjectService
    {
         void AddProject(List<Actor> actors,List<OfficeWorker> officeWorkers,Company company,Project project);
         void UpdateProject(List<Actor> actors,List<OfficeWorker> officeWorkers,Company company,Project project);
         List<Project> GetMonthlyProjects();
    }
}
