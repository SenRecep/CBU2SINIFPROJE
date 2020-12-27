
using CBU2SINIFPROJE.Core.Entities.Concrete;
using CBU2SINIFPROJE.Entities.Interfaces;

namespace CBU2SINIFPROJE.Entities.Concrete
{
    public class Credential : EntityBase, ICredential
    {
        public Manager Manager { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
