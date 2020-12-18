using CBU2SINIFPROJE.Entities.Interfaces;

namespace CBU2SINIFPROJE.Entities.Concrete
{
    public class Person :IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Adress Adress { get; set; }
    }
}
