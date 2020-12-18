using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.Entities.Interfaces
{
    public interface IVacation
    {
        Duration Duration { get; set; }
        Manager Manager { get; set; }
    }
}