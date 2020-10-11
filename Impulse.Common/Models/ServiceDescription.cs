namespace Impulse.Common.Models
{
    using System.Collections.Generic;

    public class ServiceConfiguration
    {
        public string Service { get; set; }

        public string Implementation { get; set; }

    } // public class ServiceConfiguration

    public class DependencyInjectionConfiguration
    {
        // Ordered as per Microsoft.Extensions.DependencyInjection.ServiceLifetime
        public IList<ServiceConfiguration> SingletonServices { get; set; }

        public IList<ServiceConfiguration> ScopedServices { get; set; }

        public IList<ServiceConfiguration> TransientServices { get; set; }

        public DependencyInjectionConfiguration()
        {
            this.SingletonServices = new List<ServiceConfiguration>();
            this.ScopedServices = new List<ServiceConfiguration>();
            this.TransientServices = new List<ServiceConfiguration>();
        } // public DependencyInjectionConfiguration()
    } // public class DependencyInjectionConfiguration
} // namespace Impulse.Common.Models