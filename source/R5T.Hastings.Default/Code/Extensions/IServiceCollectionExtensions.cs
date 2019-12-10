using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Sardinia;

using R5T.Hastings.Default.Configuration;

using RawMachineConfiguration = R5T.Hastings.Default.Configuration.Raw.MachineConfiguration;



namespace R5T.Hastings.Default
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection UseDefaultMachineLocationProvider(this IServiceCollection services)
        {
            var configuration = services.GetConfiguration();

            services
                .Configure<RawMachineConfiguration>()
                .ConfigureOptions<MachineConfiguration>()
                .AddSingleton<IMachineLocationProvider, MachineLocationProvider>()
                ;

            return services;
        }
    }
}
