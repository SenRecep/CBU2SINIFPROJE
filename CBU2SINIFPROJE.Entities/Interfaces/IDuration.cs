using System;

namespace CBU2SINIFPROJE.Entities.Interfaces
{
    public interface IDuration
    {
        DateTime EndDate { get; set; }
        DateTime StartDate { get; set; }
    }
}