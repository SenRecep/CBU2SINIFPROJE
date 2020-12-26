
using CBU2SINIFPROJE.ViewModels.Adress;

namespace CBU2SINIFPROJE.ViewModels.Company
{
    public class CompanyAddModel
    {
        public CompanyAddModel()
        {
            Adress = new();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public AdressModel Adress { get; set; }
    }
}
