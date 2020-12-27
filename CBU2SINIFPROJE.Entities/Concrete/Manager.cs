using CBU2SINIFPROJE.Core.Enums;
using CBU2SINIFPROJE.Entities.Interfaces;

namespace CBU2SINIFPROJE.Entities.Concrete
{
    public class Manager : Employee, IManager
    {
        public Role Role { get; set; }
        public Credential Credential { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
