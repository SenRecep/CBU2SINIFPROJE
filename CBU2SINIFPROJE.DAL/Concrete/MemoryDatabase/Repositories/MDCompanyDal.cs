using System.Linq;

using CBU2SINIFPROJE.DAL.Interfaces;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.DAL.Concrete.MemoryDatabase.Repositories
{
    public class MDCompanyDal : ICompanyDal
    {
        private readonly IGenericRepository<Project> genericProjectRepository;
        private readonly IGenericRepository<Company> genericCompanyRepository;

        public MDCompanyDal(IGenericRepository<Project> genericProjectRepository, IGenericRepository<Company> genericCompanyRepository)
        {
            this.genericProjectRepository = genericProjectRepository;
            this.genericCompanyRepository = genericCompanyRepository;
        }
        public void Delete(Company company)
        {
            if (company.Projects.Any())
                foreach (Project project in company.Projects)
                {
                    foreach (Employee employee in project.Employees)
                    {
                        if (employee is Actor actor)
                            actor.Projects.Remove(project);
                        if (employee is OfficeWorker officeWorker)
                            officeWorker.Projects.Remove(project);
                    }
                    genericProjectRepository.Delete(project);
                }
            genericCompanyRepository.Delete(company);
        }
    }
}
