using System;
using System.Collections.Generic;
using System.Linq;

using CBU2SINIFPROJE.Core.Entities.Interfaces;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.DAL.Concrete.MemoryDatabase.Contexts
{
    public static class GeneralContext
    {
        public static List<OfficeWorker> OfficeWorkers { get; set; }
        public static List<Actor> Actors { get; set; }
        public static List<Company> Companies { get; set; }
        public static List<Manager> Managers { get; set; }
        public static List<T> Set<T>()
            where T : class, IEntityBase, new()
        {
            Type type = typeof(T);
            if (type== typeof(Actor))
                return (List<T>)Actors.Cast<T>();
            if (type == typeof(OfficeWorker))
                return (List<T>)OfficeWorkers.Cast<T>();
            if (type == typeof(Company))
                return (List<T>)Companies.Cast<T>();
            if (type == typeof(Manager))
                return (List<T>)Managers.Cast<T>();
            return null;
        }
    }
}
