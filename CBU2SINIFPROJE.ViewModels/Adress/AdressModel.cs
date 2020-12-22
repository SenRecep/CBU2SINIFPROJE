using CBU2SINIFPROJE.Core.ViewModels;

namespace CBU2SINIFPROJE.ViewModels.Adress
{
    public class AdressModel:IViewModel
    {
        public AdressModel()
        {

        }
        public AdressModel(string city, string town, string detail)
        {
            City = city;
            Town = town;
            AdressDetail = detail;
        }
        public string City { get; set; }
        public string Town { get; set; }
        public string AdressDetail { get; set; }
    }
}
