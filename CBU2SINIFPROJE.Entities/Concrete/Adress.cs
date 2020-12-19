using CBU2SINIFPROJE.Entities.Interfaces;
namespace CBU2SINIFPROJE.Entities.Concrete
{
    public class Adress : IAdress
    {
        public Adress()
        {

        }
        public Adress(string city,string town,string detail)
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
