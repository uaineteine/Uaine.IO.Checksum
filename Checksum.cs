using System.Security.Cryptography;
using Uaine.Objects.Primitives;

namespace Uaine.IO.Checksum
{
    public class Checksum : HashCode
    {
        public int Algorthim { get; }

        public Checksum(byte[] tocheck) : base(CalculateSHA256Checksum(tocheck).HashBytes)
        {
            Algorthim = ChecksumType.SHA256;
        }
        public Checksum(byte[] alreadychecksummed, int algorthimUsed) : base(alreadychecksummed)
        {
            Algorthim = algorthimUsed;
        }

        // Calculate checksum for a given file using MD5
        public static HashCode CalculateMD5Checksum(byte[] data)
        {
            using (var md5 = MD5.Create())
            {
                byte[] checksumBytes = md5.ComputeHash(data);
                return new HashCode(checksumBytes);
            }
        }

        // Calculate checksum for byte array using SHA256
        public static HashCode CalculateSHA256Checksum(byte[] data)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] checksumBytes = sha256.ComputeHash(data);
                return new HashCode(checksumBytes);
            }
        }
    }
}
