using CBU2SINIFPROJE.Entities.Interfaces;
namespace CBU2SINIFPROJE.Entities.Concrete
{
    public class Adress : IAdress
    {
        public string City { get; set; }
        public string Town { get; set; }
        public string AdressDetail { get; set; }
    }
}
