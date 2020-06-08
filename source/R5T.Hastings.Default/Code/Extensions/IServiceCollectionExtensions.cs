using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using R5T.Dacia;
using R5T.Sardinia;

using R5T.Hastings.Default.Configuration;

using RawMachineConfiguration = R5T.Hastings.Default.Configuration.Raw.MachineConfiguration;



namespace R5T.Hastings.Default
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Makes <see cref="MachineConfiguration"/> available via <see cref="IOptions{TOptions}"/>.
        /// </summary>
        public static IServiceCollection AddMachineConfigurationOptions(this IServiceCollection services)
        {
            services
                .Configure<RawMachineConfiguration>()
                .ConfigureOptions<MachineConfigurationConfigureOptions>()
                ;

            return services;
        }

        /// <summary>
        /// Makes <see cref="MachineConfiguration"/> available via <see cref="Microsoft.Extensions.Options.IOptions{TOptions}"/>.
        /// </summary>
        public static IServiceAction<IOptions<MachineConfiguration>> AddMachineConfigurationOptionsAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction<IOptions<MachineConfiguration>>.New(() => services.AddMachineConfigurationOptions());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="MachineLocationProvider"/> implementation of <see cref="IMachineLocationProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddMachineLocationProvider(this IServiceCollection services,
            IServiceAction<IOptions<MachineConfiguration>> machineConfigurationOptionsAction)
        {
            services
                .AddSingleton<IMachineLocationProvider, MachineLocationProvider>()
                .Run(machineConfigurationOptionsAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="MachineLocationProvider"/> implementation of <see cref="IMachineLocationProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IMachineLocationProvider> AddMachineLocationProviderAction(this IServiceCollection services,
            IServiceAction<IOptions<MachineConfiguration>> machineConfigurationOptionsAction)
        {
            var serviceAction = ServiceAction<IMachineLocationProvider>.New(() => services.AddMachineLocationProvider(
                machineConfigurationOptionsAction));

            return serviceAction;
        }


        public static IServiceCollection UseDefaultMachineLocationProvider(this IServiceCollection services)
        {
            var configuration = services.GetConfiguration();

            services
                .Configure<RawMachineConfiguration>()
                .ConfigureOptions<MachineConfigurationConfigureOptions>()
                .AddSingleton<IMachineLocationProvider, MachineLocationProvider>()
                ;

            return services;
        }
    }
}
