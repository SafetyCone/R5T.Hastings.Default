using System;

using Microsoft.Extensions.Options;

using R5T.Brighton;
using R5T.Delos;


namespace R5T.Hastings.Default.Configuration
{
    public class MachineConfigurationConfigureOptions : IConfigureOptions<MachineConfiguration>
    {
        private IOptions<Raw.MachineConfiguration> RawMachineConfiguration { get; }


        public MachineConfigurationConfigureOptions(IOptions<Raw.MachineConfiguration> rawMachineConfiguration)
        {
            this.RawMachineConfiguration = rawMachineConfiguration;
        }

        public void Configure(MachineConfiguration options)
        {
            var rawMachineConfiguration = this.RawMachineConfiguration.Value;

            MachineLocation machineLocation;
            switch (rawMachineConfiguration.MachineLocation)
            {
                case Local.Name:
                    machineLocation = new Local();
                    break;

                case Remote.Name:
                    machineLocation = new Remote();
                    break;

                default:
                    throw new Exception($"Unknown machine location: '{rawMachineConfiguration.MachineLocation}'.");
            }

            options.MachineLocation = machineLocation;
        }
    }
}
