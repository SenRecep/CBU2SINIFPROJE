using CBU2SINIFPROJE.Core.Enums;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.Entities.Interfaces
{
    public interface IManager
    {
        Role Role { get; set; }
         Credential Credential { get; set; }
    }
}