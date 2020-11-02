namespace Impulse.Common.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System.Linq;

    public static class ILoggerExtensions
    {
        public static void Info(this ILogger logger, IServiceCollection services)
        {
            System.Collections.Generic.List<ServiceDescriptor> serviceList = services.ToList();
            foreach (ServiceDescriptor service in serviceList)
            {
                logger.LogInformation("{0} {1} {2} {3} {4}",
                    service.Lifetime,
                    service.ServiceType,
                    service.ImplementationFactory,
                    service.ImplementationType,
                    service.ImplementationInstance);
            }

            //using (System.IO.StreamWriter sw = new System.IO.StreamWriter("services.txt"))
            //{
            //    sw.AutoFlush = true;
            //    foreach (var item in serviceList)
            //    {
            //        sw.WriteLine("{0} {1} {2} {3} {4}",
            //            item.Lifetime,
            //            item.ServiceType,
            //            item.ImplementationFactory,
            //            item.ImplementationType,
            //            item.ImplementationInstance
            //            );
            //    }
            //}

            //if (configuration[key] == null)
            //    return false;
            //bool.TryParse(configuration[key], out bool result);
            //return result;
            //return true;
        } // public static bool GetBool(this IConfigurationRoot configuration, string key)
    } // public static class IConfigurationRootExtensions
} // namespace Impulse.Common.Extensions