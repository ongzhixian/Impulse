namespace Impulse.NetFrmWrk.Cryptography
{
    using System.Security.Cryptography;

    public interface ICryptographyService
    {
        byte[] GetRandomBytes(int numberOfBytes);
    } // public interface ICryptographyService

    public class CryptographyService : ICryptographyService
    {
        public byte[] GetRandomBytes(int numberOfBytes)
        {
            using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
            {
                byte[] result = new byte[numberOfBytes];
                
                rngCsp.GetBytes(result);

                return result;
            }
        }
    } // public class CryptographyService : ICryptographyService
} // namespace Impulse.NetFrmWrk.Cryptography
