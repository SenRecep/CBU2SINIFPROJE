using CBU2SINIFPROJE.Entities.Interfaces;

namespace CBU2SINIFPROJE.Entities.Concrete
{
    public class Vacation : IVacation
    {
        public Manager Manager { get; set; }
        public Duration Duration { get; set; }
    }
}
