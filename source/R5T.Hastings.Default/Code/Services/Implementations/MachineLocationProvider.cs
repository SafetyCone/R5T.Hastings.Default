using System;

using Microsoft.Extensions.Options;

using R5T.Delos;

using R5T.Hastings.Default.Configuration;


namespace R5T.Hastings.Default
{
    public class MachineLocationProvider : IMachineLocationProvider
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
