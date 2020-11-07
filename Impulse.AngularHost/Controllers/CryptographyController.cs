using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;

namespace Impulse.AngularHost.Controllers
{
    [Route("api/[controller]")]
    public class CryptographyController : Controller
    {       
        [HttpGet("HMACSHA256")]
        public ActionResult GetHMACSHA256()
        {
            HMACSHA256 hmac = new HMACSHA256();

            return Ok(new {
               HashAlgorithm = hmac.HashName,
               Key = Convert.ToBase64String(hmac.Key)
            });
        }

        [HttpGet("RandomBytes")]
        public ActionResult GetRandomBytes(int byteCount)
        {
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] dataBytes = new byte[byteCount];
                rng.GetBytes(dataBytes);

                return Ok(new {
                    ByteCount = byteCount,
                    Base64 = Convert.ToBase64String(dataBytes)
                });
            }
        }
    }
}
