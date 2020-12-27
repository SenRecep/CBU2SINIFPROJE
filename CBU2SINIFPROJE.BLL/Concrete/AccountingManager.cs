using System.Collections.Generic;
using System.Linq;

using CBU2SINIFPROJE.BLL.ExtensionMethods;
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.BLL.Concrete
{
    public class AccountingManager : IAccountingService
    {
        private readonly IProjectService projectService;
        private readonly IActorService actorService;
        private readonly IOfficeWorkerService officeWorkerService;
        private readonly IGenericService<Manager> managerService;

        public AccountingManager(IProjectService projectService, IActorService actorService, IOfficeWorkerService officeWorkerService, IGenericService<Manager> managerService)
        {
            this.projectService = projectService;
            this.actorService = actorService;
            this.officeWorkerService = officeWorkerService;
            this.managerService = managerService;
        }
        public double TotalCost()
        {
            return projectService.GetMonthlyProjects().Sum(x => x.Cost);
        }
        public int TotalWages()
        {
            int total = 0;
            List<Project> projects = projectService.GetMonthlyProjects();
            List<Manager> managers = managerService.GetAll();
            List<Employee> employees = new List<Employee>();
            employees.AddRange(actorService.GetMonthlyActors(projects));
            employees.AddRange(officeWorkerService.GetMonthlyOfficeWorkers(projects));
            foreach (Employee employee in employees)
            {
                int totalDay = 0;
                List<Project> employeeProjects = null;
                if (employee is Actor actor)
                    employeeProjects = actor.Projects;
                if (employee is OfficeWorker officeWorker)
                    employeeProjects = officeWorker.Projects;
                foreach (Project project in employeeProjects)
                    totalDay += project.Duration.DurationCalc();
                int totalSalary = (employee.Salary / 30) * totalDay;
                total += totalSalary;
            }
            foreach (Manager manager in managers)
                total += manager.Salary;
            return total;

        }
    }
}
