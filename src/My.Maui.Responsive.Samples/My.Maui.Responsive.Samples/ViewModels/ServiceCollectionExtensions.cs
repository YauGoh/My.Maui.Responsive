using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace My.Maui.Responsive.Samples.ViewModels
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            var types = typeof(ViewModel).Assembly
                .GetTypes()
                .Where(_ => _.IsAssignableTo(typeof(ViewModel)) && !_.IsAbstract);

            foreach(var type in types)
            {
                services.AddTransient(type);
            }

            return services;
        }
    }
}
