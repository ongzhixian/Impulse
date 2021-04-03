namespace WkspAzure.FrmWrk.CryptographicFunctions
{
    using System;
    public static class ByteArrayExtensions
    {
        public static string AsBase64String(this byte[] byteArray)
        {
            try
            {
                return Convert.ToBase64String(byteArray);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
