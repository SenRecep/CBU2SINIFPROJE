using System.Collections.Generic;
using System.Linq;

using CBU2SINIFPROJE.BLL.ExtensionMethods;
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.Core.Enums;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.WPFUI
{
    public class SeedDatabase
    {
        private readonly IGenericService<Manager> managerService;
        private readonly IGenericService<Credential> credentialService;
        private readonly IGenericService<Actor> actorService;
        private readonly IGenericService<Company> companyService;
        private readonly IGenericService<OfficeWorker> officeWorkerService;
        private readonly IProjectService projectService;

        public SeedDatabase(
            IGenericService<Manager> managerService,
            IGenericService<Credential> credentialService,
            IGenericService<Actor> actorService,
            IGenericService<Company> companyService,
            IGenericService<OfficeWorker> officeWorkerService,
            IProjectService projectService
            )
        {
            this.managerService = managerService;
            this.credentialService = credentialService;
            this.actorService = actorService;
            this.companyService = companyService;
            this.officeWorkerService = officeWorkerService;
            this.projectService = projectService;
        }
        public void Seed()
        {
            SeedManagers();
            SeedActors();
            SeedOfficeWorker();
            SeedCompany();
            SeedProject();
            var mudur = managerService.GetById(1);
            SeedVocations(mudur);
        }

        private void SeedProject()
        {
            List<Company> companies = companyService.GetAll();
            List<Actor> actors = actorService.GetAll();
            List<OfficeWorker> officeworker = officeWorkerService.GetAll();
            foreach (Company company in companies)
            {
                Bogus.Faker faker = new Bogus.Faker();
                var projectCount = faker.Random.Byte(1, 2);
                for (int i = 0; i < projectCount; i++)
                {
                    List<OfficeWorker> _officeworkers = officeworker.Where(x => x.Projects == null).OrderBy(x => faker.Random.Int(0, officeworker.Count * 2)).Take(faker.Random.Int(1, 2)).ToList();
                    List<Actor> _actors = actors.Where(x => x.Projects == null).OrderBy(x => faker.Random.Int(0, actors.Count * 2)).Take(faker.Random.Int(1, 2)).ToList();
                    var totalEmployee = _officeworkers.Count() + _actors.Count();
                    var duration = new Duration(faker.Date.Recent(faker.Random.Byte(3, 10)), faker.Date.Soon(faker.Random.Byte(3, 10)));

                    Project project = new()
                    {
                        Name = faker.Commerce.ProductName(),
                        Company = company,
                        Cost = faker.Random.Double(5000, 7000) * totalEmployee,
                        Duration = duration,
                        Employees = new List<Employee>()
                    };

                    projectService.AddProject(_actors, _officeworkers, company, project);
                }
            }
        }

        private void SeedOfficeWorker()
        {
            for (int i = 0; i < 30; i++)
            {
                Bogus.Person person = new Bogus.Person();
                OfficeWorker officeWorker = new()
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Adress = new(person.Address.State, person.Address.City, person.Address.Street),
                    Salary = person.Random.Int(2500, 4000),
                    Position = (Position)person.Random.Byte(0, 1),
                };
                officeWorkerService.Add(officeWorker);
            }
        }
        private void SeedCompany()
        {
            for (int i = 0; i < 4; i++)
            {
                Bogus.Faker faker = new Bogus.Faker();
                Company company = new()
                {
                    Name = faker.Company.CompanyName(),
                    Adress = new(faker.Address.State(), faker.Address.City(), faker.Address.StreetAddress()),
                    Projects = new List<Project>()
                };
                companyService.Add(company);
            }
        }
        private void SeedActors()
        {
            for (int i = 0; i < 30; i++)
            {
                Bogus.Person person = new Bogus.Person();
                Actor actor = new()
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Adress = new(person.Address.State, person.Address.City, person.Address.Street),
                    Salary = person.Random.Int(2500, 5000),
                    Field = (Field)person.Random.Byte(0, 2),
                };
                actorService.Add(actor);
            }

        }
        private void SeedManagers()
        {
            Manager mudur = new()
            {
                FirstName = "Fazlı",
                LastName = "Kılıç",
                Adress = new("Istanbul", "Kağıthane", "Cumhuriyet Sokak No:3 D:4"),
                Role = Role.Mudur,
                Salary = 10000,
            };
            Manager yardimci1 = new()
            {
                FirstName = "Mehmet",
                LastName = "Yılmaz",
                Adress = new("Istanbul", "Şişli", "Atatürk Sokak No:32 D:5"),
                Role = Role.MudurYardimcisi,
                Salary = 5000,
            };
            Manager yardimci2 = new()
            {
                FirstName = "Ayşe",
                LastName = "Boz",
                Adress = new("Istanbul", "Karaköy", "Mühteha Sokak No:24 D:6"),
                Role = Role.MudurYardimcisi,
                Salary = 5500,
            };

            managerService.Add(mudur);
            managerService.Add(yardimci1);
            managerService.Add(yardimci2);
            SeedCredentials(mudur, yardimci1, yardimci2);
        }
        private void SeedVocations(Manager manager)
        {
            var freeActors = actorService.GetAll().Where(x => x.Projects.IsNull()).Take(3).ToList();
            var freeOfficeWorkers = officeWorkerService.GetAll().Where(x => x.Projects.IsNull()).Take(4).ToList();
            freeActors.ForEach(x=>VocationEmployee(x,manager));
            freeOfficeWorkers.ForEach(x=>VocationEmployee(x,manager));
        }
        private void VocationEmployee(Employee employee,Manager manager)
        {
            Bogus.Faker faker = new Bogus.Faker();
            var duration = new Duration(faker.Date.Recent(faker.Random.Byte(3, 10)), faker.Date.Soon(faker.Random.Byte(3, 10)));
            Vacation vacation = new()
            {
                Manager= manager,
                Duration=duration
            };
            employee.Vacations = new();
            employee.Vacations.Add(vacation);
            if (employee is Actor actor)
                actorService.Update(actor);
            if (employee is OfficeWorker officeWorker)
                officeWorkerService.Update(officeWorker);
        }
        private void SeedCredentials(Manager mudur, Manager muduryardimcisi1, Manager muduryardimcisi2)
        {
            Credential mudurcredential = new()
            {
                UserName = "fazlikilic",
                Password = "admin",
                Manager = mudur
            };
            mudur.Credential = mudurcredential;
            credentialService.Add(mudurcredential);


            Credential yardimci1credential = new()
            {
                UserName = "mehmetyilmaz",
                Password = "admin",
                Manager = muduryardimcisi1
            };
            muduryardimcisi1.Credential = yardimci1credential;
            credentialService.Add(yardimci1credential);

            Credential yardimci2credential = new()
            {
                UserName = "ayseboz",
                Password = "admin",
                Manager = muduryardimcisi2
            };
            muduryardimcisi2.Credential = yardimci2credential;
            credentialService.Add(yardimci2credential);
        }
    }
}
