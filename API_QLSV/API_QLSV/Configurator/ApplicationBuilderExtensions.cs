using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Linq;


namespace API_QLSV.Configurator
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureApp(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            var configurators = typeof(Startup).Assembly.ExportedTypes
                .Where(x => typeof(IAppConfigurator).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IAppConfigurator>()
                .ToList();

            configurators.ForEach(configurator => configurator.Configure(app, env));
        }
    }
}
