using System.Linq;

using CBU2SINIFPROJE.DAL.Concrete.MemoryDatabase.Contexts;
using CBU2SINIFPROJE.DAL.Interfaces;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.DAL.Concrete.MemoryDatabase.Repositories
{
    public class MDProjectDal : IProjectDal
    {
        public Project Add(Project project)
        {
            int maxId = 0;
            if (GeneralContext.Projects.Any())
                maxId = GeneralContext.Projects.Max(x => x.Id);
            project.Id = maxId + 1;
            GeneralContext.Projects.Add(project);
            return project;
        }
    }
}
