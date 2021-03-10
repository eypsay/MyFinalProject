using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extentions
{
    public static class ServiceCollectionExtentions
    {//apimizin service bağımlılıklarımızı keledğimizz
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            //polimorfpihsm
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);// ekleyeceğimiz bütün injecionları toplayacağız ir yapı oldu
        }
    }
}
