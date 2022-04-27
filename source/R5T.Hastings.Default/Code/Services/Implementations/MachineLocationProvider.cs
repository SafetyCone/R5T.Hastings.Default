using System;

using Microsoft.Extensions.Options;

using R5T.Delos;

using R5T.Hastings.Default.Configuration;using R5T.T0064;


namespace R5T.Hastings.Default
{[ServiceImplementationMarker]
    public class MachineLocationProvider : IMachineLocationProvider,IServiceImplementation
    {
        private IOptions<MachineConfiguration> MachineConfiguration { get; }


        public MachineLocationProvider(IOptions<MachineConfiguration> machineConfiguration)
        {
            this.MachineConfiguration = machineConfiguration;
        }

        public MachineLocation GetMachineLocation()
        {
            var machineLocation = this.MachineConfiguration.Value.MachineLocation;
            return machineLocation;
        }
    }
}
