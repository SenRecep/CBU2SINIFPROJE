using CBU2SINIFPROJE.Entities.Interfaces;

using CBU2SINIFPROJE.Entities.Enums;

namespace CBU2SINIFPROJE.Entities.Concrete
{
    public class Manager : Employee, IManager
    {
        public Role Role { get; set; }
    }
}
