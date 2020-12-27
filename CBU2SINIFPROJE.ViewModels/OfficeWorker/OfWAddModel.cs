using CBU2SINIFPROJE.Core.Enums;
using CBU2SINIFPROJE.Core.ViewModels;
using CBU2SINIFPROJE.ViewModels.Adress;

namespace CBU2SINIFPROJE.ViewModels.OfficeWorker
{
    public class OfWAddModel:IViewModel
    {
        public OfWAddModel()
        {
            Adress = new AdressModel();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public AdressModel Adress { get; set; }
        public Position Position { get; set; }
    }
}
