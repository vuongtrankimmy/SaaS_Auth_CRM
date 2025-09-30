using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace Shared.Helpers.Encrypts.CRC32
{
    public class CRC32Helper : HashAlgorithm
    {
        public const uint DefaultPolynomial = 0xedb88320u;
        public const uint DefaultSeed = 0xffffffffu;

        static uint[]? defaultTable;

        readonly uint seed;
        readonly uint[] table;
        uint hash;

        /// <summary>
        /// Initializes a new instance of the <see cref="Crc32"/> class.
        /// </summary>
        public CRC32Helper()
            : this(DefaultPolynomial, DefaultSeed)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Crc32"/> class.
        /// </summary>
        /// <param name="polynomial">The polynomial.</param>
        /// <param name="seed">The seed.</param>
        public CRC32Helper(uint polynomial, uint seed)
        {
            table = InitializeTable(polynomial);
            this.seed = hash = seed;
        }

        public override void Initialize()
        {
            hash = seed;
        }

        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            hash = CalculateHash(table, hash, array, ibStart, cbSize);
        }

        protected override byte[] HashFinal()
        {
            var hashBuffer = UInt32ToBigEndianBytes(~hash);
            HashValue = hashBuffer;
            return hashBuffer;
        }

        public override int HashSize { get { return 32; } }

        public static uint Compute(byte[] buffer)
        {
            return Compute(DefaultSeed, buffer);
        }

        public static uint Compute(uint seed, byte[] buffer)
        {
            return Compute(DefaultPolynomial, seed, buffer);
        }

        public static uint Compute(uint polynomial, uint seed, byte[] buffer)
        {
            return ~CalculateHash(InitializeTable(polynomial), seed, buffer, 0, buffer.Length);
        }

        static uint[] InitializeTable(uint polynomial)
        {
            if (polynomial == DefaultPolynomial && defaultTable != null)
                return defaultTable;

            var createTable = new uint[256];
            for (var i = 0; i < 256; i++)
            {
                var entry = (uint)i;
                for (var j = 0; j < 8; j++)
                    if ((entry & 1) == 1)
                        entry = entry >> 1 ^ polynomial;
                    else
                        entry >>= 1;
                createTable[i] = entry;
            }

            if (polynomial == DefaultPolynomial)
                defaultTable = createTable;

            return createTable;
        }

        static uint CalculateHash(uint[] table, uint seed, IList<byte> buffer, int start, int size)
        {
            var crc = seed;
            for (var i = start; i < size - start; i++)
                crc = crc >> 8 ^ table[buffer[i] ^ crc & 0xff];
            return crc;
        }

        static byte[] UInt32ToBigEndianBytes(uint uint32)
        {
            var result = BitConverter.GetBytes(uint32);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(result);

            return result;
        }
    }

    public static class Encrypt
    {
        //protected readonly string encKeySource = "*aB//8K[KuoYB,q\\O!vBvwYeB0IL\\c!";
        readonly static string _key = "*[KuoYB,q\\O!vBvwYeB0IL$";
        public static string MethodFull(this string textPlain)
        {
            var result = "";
            byte[] baseHash = SHA1.HashData(Encoding.ASCII.GetBytes(textPlain));
            byte[] array = new byte[baseHash.Length];
            for (int i = 0; i < baseHash.Length; i++)
            {
                array[i] = (byte)((uint)baseHash[i] ^ 170);
            }
            uint num = CRC32Helper.Compute(Encoding.ASCII.GetBytes(textPlain));
            byte[] bytes = Encoding.ASCII.GetBytes(_key);
            byte[] numArray = new byte[4]
            {
                (byte) (num &  byte.MaxValue),
                (byte) (num >> 8 &  byte.MaxValue),
                (byte) (num >> 16 &  byte.MaxValue),
                (byte) (num >> 24 &  byte.MaxValue)
            };
            int length = numArray.Length;
            for (int index = 0; index < bytes.Length; ++index)
                bytes[index] = (byte)(bytes[index] ^ (uint)numArray[index % length]);
            return result;
        }
        public static string BitConvert(this string textPlain)
        {
            byte[] baseHash = SHA1.HashData(Encoding.ASCII.GetBytes(textPlain));
            byte[] array = new byte[baseHash.Length];
            for (int i = 0; i < baseHash.Length; i++)
            {
                array[i] = (byte)((uint)baseHash[i] ^ 170);
            }
            var result = BitConverter.ToString(array).Replace("-", "");
            return result;
        }
        public static string CRC32(this string textPlain)
        {
            uint num = CRC32Helper.Compute(Encoding.ASCII.GetBytes(textPlain));
            _ = new byte[4]
            {
                (byte) (num &  byte.MaxValue),
                (byte) (num >> 8 &  byte.MaxValue),
                (byte) (num >> 16 &  byte.MaxValue),
                (byte) (num >> 24 &  byte.MaxValue)
            };
            var result = num.ToString("x");
            return result;
        }
        public static string Key(string textPlain)
        {
            uint num = CRC32Helper.Compute(Encoding.ASCII.GetBytes(textPlain));
            byte[] bytes = Encoding.ASCII.GetBytes(_key);
            byte[] numArray = new byte[4]
            {
                (byte) (num &  byte.MaxValue),
                (byte) (num >> 8 &  byte.MaxValue),
                (byte) (num >> 16 &  byte.MaxValue),
                (byte) (num >> 24 &  byte.MaxValue)
            };
            int length = numArray.Length;
            for (int index = 0; index < bytes.Length; ++index)
                bytes[index] = (byte)(bytes[index] ^ (uint)numArray[index % length]);
            var result = BitConverter.ToString(bytes).Replace("-", "");
            return result;
        }
    }
}
