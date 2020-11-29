namespace Impulse.Common
{
    using Impulse.Common.Models;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class DependencyInjector
    {
        private readonly ILogger logger;
        
        private readonly IDictionary<string, Assembly> assemblyDictionary;

        public DependencyInjector(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            logger.LogInformation("Building assembly dictionary.");

            assemblyDictionary = new Dictionary<string, Assembly>();

            foreach (var item in assemblyDictionary)
            {
                logger.LogDebug("Initial assembly dictionary {Assembly}", item.Value.FullName);
            }

            AddAssemblyDictionary(assemblyDictionary, AppDomain.CurrentDomain.GetAssemblies().Select(r => r.GetName()));

            logger.LogInformation("Assembly dictionary set.");
        } // public DependencyInjector(...)

        public void InjectServices(IServiceCollection services, DependencyInjectionConfiguration dependencyInjectionConfiguration)
        {
            if (dependencyInjectionConfiguration == null) throw new ArgumentNullException(nameof(dependencyInjectionConfiguration));

            InjectServices(services, dependencyInjectionConfiguration.TransientServices, ServiceLifetime.Transient);

            InjectServices(services, dependencyInjectionConfiguration.ScopedServices, ServiceLifetime.Scoped);

            InjectServices(services, dependencyInjectionConfiguration.SingletonServices, ServiceLifetime.Singleton);
        } // public void InjectServices(IServiceCollection services, DependencyInjectionConfiguration dependencyInjectionConfiguration)

        private void InjectServices(IServiceCollection services, IList<ServiceConfiguration> serviceConfigurationList, ServiceLifetime serviceLifetime)
        {
            string serviceTypeAssemblyName;
            string serviceTypeName;
            string implementationTypeAssemblyName;
            string implementationTypeName;
            string[] typeAssemblyNameParts;

            // TODO: To refactor
            foreach (var serviceConfiguration in serviceConfigurationList)
            {
                typeAssemblyNameParts = serviceConfiguration.Service.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (typeAssemblyNameParts.Length > 1)
                {
                    serviceTypeAssemblyName = typeAssemblyNameParts[1].Trim();
                    serviceTypeName = typeAssemblyNameParts[0].Trim();
                }
                else
                {
                    try
                    {
                        serviceTypeAssemblyName = serviceConfiguration.Service.Substring(0, serviceConfiguration.Service.LastIndexOf('.'));
                        serviceTypeName = serviceConfiguration.Service.Trim();
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "Invalid service {Service} name defined in configuration for service lifetime {ServiceLifetime}.",
                            serviceConfiguration.Service, serviceLifetime);
                        continue;
                    }
                }

                Type serviceType = assemblyDictionary[serviceTypeAssemblyName]?.ExportedTypes.FirstOrDefault(r => r.FullName == serviceTypeName);
                if (serviceType == null)
                {
                    Console.Error.WriteLine("ERR serviceType");
                    logger.LogError("{Service} {ServiceLifetime} not found.", serviceConfiguration.Service, serviceLifetime);
                    continue;
                }

                typeAssemblyNameParts = serviceConfiguration.Implementation.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (typeAssemblyNameParts.Length > 1)
                {
                    implementationTypeAssemblyName = typeAssemblyNameParts[1].Trim();
                    implementationTypeName = typeAssemblyNameParts[0].Trim();
                }
                else
                {
                    try
                    {
                        implementationTypeAssemblyName = serviceConfiguration.Implementation.Substring(0, serviceConfiguration.Implementation.LastIndexOf('.'));
                        //implementationTypeAssemblyName = serviceConfiguration.Implementation.Substring(0, serviceConfiguration.Implementation.LastIndexOf('.'));
                        implementationTypeName = serviceConfiguration.Implementation.Trim();
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "Invalid implementation {Implementation} name defined in configuration for service lifetime {ServiceLifetime}.",
                            serviceConfiguration.Implementation, serviceLifetime);
                        continue;
                    }
                }

                try
                {
                    if (!assemblyDictionary.ContainsKey(implementationTypeAssemblyName))
                    {
                        foreach (string key in assemblyDictionary.Keys)
                        {
                            Console.WriteLine(key);
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }

                Type implementationType = assemblyDictionary[implementationTypeAssemblyName]?.ExportedTypes.FirstOrDefault(r => r.FullName == implementationTypeName);
                if (implementationType == null)
                {
                    Console.Error.WriteLine("ERR implementationType");
                    logger.LogError("{Implementation} {ServiceLifetime} not found.", serviceConfiguration.Implementation, serviceLifetime);
                    continue;
                }

                ServiceDescriptor serviceDescriptor = new ServiceDescriptor(
                    serviceType,
                    implementationType,
                    serviceLifetime);
                services.Add(serviceDescriptor);

                logger.LogInformation("{Service} {ServiceLifetime} added.", serviceConfiguration.Service, serviceLifetime);
            }
        } // private void InjectServices(...)

        private void AddAssemblyDictionary(IDictionary<string, Assembly> assemblyDictionary, IEnumerable<AssemblyName> referencedAssembyNames)
        {
            foreach (AssemblyName assemblyName in referencedAssembyNames)
            {
                if (assemblyDictionary.ContainsKey(assemblyName.Name))
                    continue;

                Assembly assembly = Assembly.Load(assemblyName);
                if (assembly == null)
                {
                    logger.LogError("Cannot load assembly {assemblyName}");
                    throw new InvalidOperationException("Cannot load assembly {assemblyName}");
                }

                assemblyDictionary.Add(assemblyName.Name, assembly);

                AddAssemblyDictionary(assemblyDictionary, referencedAssembyNames: assembly.GetReferencedAssemblies());
            }
        } // private void AddAssemblyDictionary(...)
    } // public class DependencyInjector
} // namespace Impulse.Common
