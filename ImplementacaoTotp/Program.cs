using OtpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementacaoTotp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var key = KeyGeneration.GenerateRandomKey(20);

            var base32Bytes = Base32Encoding.ToBytes("TESTANDOCHAVEBASE32KEY");
            //var base32String = Base32Encoding.ToString("TESTANDOCHAVEBASE32KEY");


            var hexString = ByteArrayToHexString(base32Bytes);
            var hexByteArray = HexStringToByteArray(hexString);

            var totp = new Totp(base32Bytes);
            string codigo = totp.ComputeTotp(DateTime.Now);

            Console.WriteLine(codigo);
            Console.ReadKey();
        }
        public static string ByteArrayToHexString(byte[] Bytes)
        {
            StringBuilder Result = new StringBuilder(Bytes.Length * 2);
            string HexAlphabet = "0123456789ABCDEF";

            foreach (byte B in Bytes)
            {
                Result.Append(HexAlphabet[(int)(B >> 4)]);
                Result.Append(HexAlphabet[(int)(B & 0xF)]);
            }

            return Result.ToString();
        }

        public static byte[] HexStringToByteArray(string Hex)
        {
            byte[] Bytes = new byte[Hex.Length / 2];
            int[] HexValue = new int[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05,
       0x06, 0x07, 0x08, 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
       0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

            for (int x = 0, i = 0; i < Hex.Length; i += 2, x += 1)
            {
                Bytes[x] = (byte)(HexValue[Char.ToUpper(Hex[i + 0]) - '0'] << 4 |
                                  HexValue[Char.ToUpper(Hex[i + 1]) - '0']);
            }

            return Bytes;
        }
    }

}
