using CBU2SINIFPROJE.Entities.Interfaces;

using System;

namespace CBU2SINIFPROJE.Entities.Concrete
{
    public class Duration : IDuration
    {
        public Duration(DateTime start,DateTime end)
        {
            StartDate = start;
            EndDate = end;
        }
        public override string ToString()
        {
            return $"{StartDate.ToShortDateString()} - {EndDate.ToShortDateString()}";
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
