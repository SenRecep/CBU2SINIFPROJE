using CBU2SINIFPROJE.Core.Entities.Interfaces;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.Entities.Interfaces
{
    public interface IPerson: IEntityBase
    {
        Adress Adress { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}