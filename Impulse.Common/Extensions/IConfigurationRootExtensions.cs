namespace Impulse.Common.Extensions
{
    using Microsoft.Extensions.Configuration;
    public static class IConfigurationRootExtensions
    {
        public static bool IsTrue(this IConfigurationRoot configuration, string key)
        {
            if (configuration[key] == null)
                return false;

            bool.TryParse(configuration[key], out bool result);

            return result;
        } // public static bool GetBool(this IConfigurationRoot configuration, string key)
    } // public static class IConfigurationRootExtensions
} // namespace Impulse.Common.Extensions