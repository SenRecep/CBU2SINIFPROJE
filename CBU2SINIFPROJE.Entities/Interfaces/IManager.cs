using CBU2SINIFPROJE.Entities.Concrete;
using CBU2SINIFPROJE.Entities.Enums;

namespace CBU2SINIFPROJE.Entities.Interfaces
{
    public interface IManager
    {
        Role Role { get; set; }
         Credential Credential { get; set; }
    }
}