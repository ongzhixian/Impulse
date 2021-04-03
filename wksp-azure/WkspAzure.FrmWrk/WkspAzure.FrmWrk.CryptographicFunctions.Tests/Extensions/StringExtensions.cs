using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WkspAzure.FrmWrk.CryptographicFunctions.Tests
{
    public static class StringExtensions
    {
        public static byte[] ToBytesAsBase64String(this string str)
        {
            try
            {
                return Convert.FromBase64String(str);
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
