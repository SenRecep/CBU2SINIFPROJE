using CBU2SINIFPROJE.Entities.Interfaces;

using System;

namespace CBU2SINIFPROJE.Entities.Concrete
{
    public class Duration : IDuration
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
