namespace Impulse.Common.Extensions
{
    using System.Collections.Generic;
    using System;

    public static class StringArrayExtensions
    {
        public static Dictionary<string, string> ToDictionary(this string[] args, char separator)
        {
            Dictionary<string, string> parsedArgs = new Dictionary<string, string>();
        
            foreach (string arg in args)
            {
                var entries = arg.Split(new char[] { separator }, 2, StringSplitOptions.RemoveEmptyEntries);

                if (entries.Length > 1)
                {
                    parsedArgs.Add(entries[0], entries[1]);
                }
            }

            return parsedArgs;
        } // public static Dictionary<string, string> ToDictionary(this string[] args, char separator)
    } // public static class IConfigurationRootExtensions
} // namespace Impulse.Common.Extensions