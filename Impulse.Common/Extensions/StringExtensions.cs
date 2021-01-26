namespace Impulse.Common.Extensions
{
    using System.Collections.Generic;
    using System;

    public static class StringExtensions
    {
        public static System.Net.IPAddress ToIPAddress(this string arg)
        {
            System.Net.IPAddress result = null;

            if (arg == null)
                return null;

            
                System.Net.IPAddress.TryParse(arg, out result);

            return result;
        }
    } // public static class StringExtensions
} // namespace Impulse.Common.Extensions