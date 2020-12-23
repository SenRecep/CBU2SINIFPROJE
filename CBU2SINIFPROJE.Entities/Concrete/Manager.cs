using CBU2SINIFPROJE.Entities.Interfaces;

using CBU2SINIFPROJE.Core.Enums;

namespace CBU2SINIFPROJE.Entities.Concrete
{
    public class Manager : Employee, IManager
    {
        public Role Role { get; set; }
        public Credential Credential { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
}
