using System.Security.Cryptography;
namespace Shared.Helpers.Encrypts.MD5Helper
{
    public class Md5Managed : MD5
    {
        private byte[] _data;
        private AbcdStruct _abcd;
        private long _totalLength;
        private int _dataSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="Md5Managed"/> class.
        /// </summary>
        public Md5Managed()
        {
            HashSizeValue = 0x80;
            Initialize();
        }

        public override sealed void Initialize()
        {
            _data = new byte[64];
            _dataSize = 0;
            _totalLength = 0;
            _abcd = new AbcdStruct { A = 0x67452301, B = 0xefcdab89, C = 0x98badcfe, D = 0x10325476 };
            //Intitial values as defined in RFC 1321
        }

        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            int startIndex = ibStart;
            int totalArrayLength = _dataSize + cbSize;
            if (totalArrayLength >= 64)
            {
                Array.Copy(array, startIndex, _data, _dataSize, 64 - _dataSize);
                // Process message of 64 bytes (512 bits)
                Md5Core.GetHashBlock(_data, ref _abcd, 0);
                startIndex += 64 - _dataSize;
                totalArrayLength -= 64;
                while (totalArrayLength >= 64)
                {
                    Array.Copy(array, startIndex, _data, 0, 64);
                    Md5Core.GetHashBlock(array, ref _abcd, startIndex);
                    totalArrayLength -= 64;
                    startIndex += 64;
                }
                _dataSize = totalArrayLength;
                Array.Copy(array, startIndex, _data, 0, totalArrayLength);
            }
            else
            {
                Array.Copy(array, startIndex, _data, _dataSize, cbSize);
                _dataSize = totalArrayLength;
            }
            _totalLength += cbSize;
        }

        protected override byte[] HashFinal()
        {
            HashValue = Md5Core.GetHashFinalBlock(_data, 0, _dataSize, _abcd, _totalLength * 8);
            return HashValue;
        }
    }
}