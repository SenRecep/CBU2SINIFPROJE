using System;

using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.BLL.ExtensionMethods
{
    public static class EntityExtensionMethods
    {
        public static int DurationCalc(this Duration duration)
        {
            var total = (duration.EndDate - duration.StartDate).TotalDays;
            return Convert.ToInt32(total);
        }
    }
}
