using CBU2SINIFPROJE.Core.Entities.Interfaces;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.Entities.Interfaces
{
    public interface ICredential : IEntityBase
    {
        Manager Manager { get; set; }
        string Password { get; set; }
        string UserName { get; set; }
    }
}