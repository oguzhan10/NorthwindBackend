using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static IServiceCollection Create(IServiceCollection services) //.net core un kendi servicelerine erişilebiliyor
        {
            ServiceProvider = services.BuildServiceProvider();

            return services;
        }
    }
}
