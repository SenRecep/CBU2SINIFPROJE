using System;
using System.Collections.Generic;
using System.Linq;

using CBU2SINIFPROJE.BLL.ExtensionMethods;
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.DAL.Interfaces;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.BLL.Concrete
{
    public class ProjectManager : IProjectService
    {
        private readonly IGenericRepository<Project> projectDal;

        public ProjectManager(IGenericRepository<Project> projectDal)
        {
            this.projectDal = projectDal;
        }

        public void AddProject(List<Actor> actors, List<OfficeWorker> officeWorkers, Company company, Project project)
        {
            projectDal.Add(project);
            officeWorkers.ToList().ForEach(item =>
            {
                if (item.Projects.IsNull())
                    item.Projects = new List<Project>();
                item.Projects.Add(project);
            });
            actors.ToList().ForEach(item =>
            {
                if (item.Projects.IsNull())
                    item.Projects = new List<Project>();
                item.Projects.Add(project);
            });
            if (project.Employees.IsNull())
                project.Employees = new();
            project.Employees.AddRange(officeWorkers);
            project.Employees.AddRange(actors);

            if (company.Projects.IsNull())
                company.Projects = new();
            project.Company = company;
            company.Projects.Add(project);
        }

        private void ClearProject(Project project)
        {
            project.Employees.ForEach(item=> {
                if (item is Actor actor)
                    actor.Projects.Remove(project);
                if (item is OfficeWorker ofw)
                    ofw.Projects.Remove(project);
            });
            project.Employees.Clear();
            project.Company.Projects.Remove(project);
        }
        public void UpdateProject(List<Actor> actors, List<OfficeWorker> officeWorkers, Company company, Project project)
        {
            ClearProject(project);

            officeWorkers.ToList().ForEach(item =>
            {
                if (item.Projects.IsNull())
                    item.Projects = new List<Project>();
                item.Projects.Add(project);
            });
            actors.ToList().ForEach(item =>
            {
                if (item.Projects.IsNull())
                    item.Projects = new List<Project>();
                item.Projects.Add(project);
            });
            if (project.Employees.IsNull())
                project.Employees = new();
            project.Employees.AddRange(officeWorkers);
            project.Employees.AddRange(actors);

            if (company.Projects.IsNull())
                company.Projects = new();
            company.Projects.Add(project);
            project.Company = company;
            projectDal.Update(project);
        }

        public List<Project> GetMonthlyProjects()
        {
           return projectDal.GetAll().Where(x=>x.Duration.StartDate.Month==DateTime.Now.Month).ToList();
        }
    }
}
