using MarsRover.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;

namespace MarsRover
{
    internal static class ServiceConfiguration
    {
        private static IServiceProvider ServiceProvider { get; set; }

        static ServiceConfiguration()
        {
            var services = new ServiceCollection();

            var container = new Container();
            container.Configure(config =>
            {
                config.Scan(c =>
                {
                    c.AssembliesFromApplicationBaseDirectory();
                    c.WithDefaultConventions();
                });
                config.Populate(services);
            });

            ServiceProvider = container.GetInstance<IServiceProvider>();
        }

        public static IRoverController GetRoverController => ServiceProvider.GetService<IRoverController>();
    }
}
