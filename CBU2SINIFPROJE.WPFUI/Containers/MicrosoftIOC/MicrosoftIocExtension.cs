using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

using Microsoft.Extensions.DependencyInjection;

namespace CBU2SINIFPROJE.WPFUI.Containers.MicrosoftIOC
{
    public static class MicrosoftIocExtension
    {
        public static void TypeLoader(this IServiceCollection serviceCollection, Type destType)
        {
            Assembly assambly = Assembly.GetExecutingAssembly();
            List<Type> types = assambly.GetTypes().Where(x => x.BaseType.Equals(destType)).ToList();
            types.ForEach(type => serviceCollection.AddTransient(type));
        }
        public static void WindowsDILoader(this IServiceCollection serviceCollection)
        {
            serviceCollection.TypeLoader(typeof(Window));
        }
        public static void PagesDILoader(this IServiceCollection serviceCollection)
        {
            serviceCollection.TypeLoader(typeof(Page));
        }
    }
}
