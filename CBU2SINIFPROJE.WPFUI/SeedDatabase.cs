using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.Entities.Concrete;
using CBU2SINIFPROJE.Entities.Enums;

namespace CBU2SINIFPROJE.WPFUI
{
    public  class SeedDatabase
    {
        private readonly IGenericService<Manager> managerService;
        private readonly IGenericService<Credential> credentialService;

        public SeedDatabase(IGenericService<Manager> managerService, IGenericService<Credential> credentialService)
        {
            this.managerService = managerService;
            this.credentialService = credentialService;
        }
        public void Seed()
        {
            SeedManagers();
        }

        private void SeedCredential(Manager mudur,Manager muduryardimcisi1, Manager muduryardimcisi2)
        {
            Credential mudurcredential = new()
            {
                UserName="fazlikilic",
                Password="admin",
                Manager= mudur
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

        private void SeedManagers()
        {
            Manager mudur = new() {
                FirstName = "Fazlı",
                LastName = "Kılıç",
                Adress = new("Istanbul","Kağıthane","Cumhuriyet Sokak No:3 D:4"),
                Role=Role.Mudur,
                Salary=10000,
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
            SeedCredential(mudur, yardimci1, yardimci2);

        }
    }
}
