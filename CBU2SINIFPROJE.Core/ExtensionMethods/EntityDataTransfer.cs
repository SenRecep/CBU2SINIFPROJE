using System.Linq;
using System.Reflection;

using CBU2SINIFPROJE.Core.Entities.Concrete;
using CBU2SINIFPROJE.Core.Entities.Interfaces;

namespace CBU2SINIFPROJE.Core.ExtensionMethods
{
    public static class EntityDataTransfer
    {
        public static void DataTransfer(this IEntityBase left, IEntityBase right)
        {
            PropertyInfo[] rightProperties = right.GetType().GetProperties();
            PropertyInfo[] leftProperties = left.GetType().GetProperties();
            rightProperties.ToList().ForEach((r) =>
            {
                if (!r.Name.Equals(nameof(EntityBase.Id)))
                {
                    PropertyInfo l = leftProperties.FirstOrDefault(x => x.Name.Equals(r.Name));
                    if (l != null)
                        if (l.GetType().Equals(r.GetType()))
                            l.SetValue(left, r.GetValue(right));
                }
            });
        }
    }
}
