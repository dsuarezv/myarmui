using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArmClient
{
    /// <summary>
    /// Taken from http://www.sanity-free.com/146/crc8_implementation_in_csharp.html
    /// </summary>
    public static class Crc8
    {
        static byte[] table = new byte[256];
        // x8 + x7 + x6 + x4 + x2 + 1
        const byte poly = 0xd5;

        public static byte ComputeChecksum(params byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return 0;

            byte crc = 0;

            foreach (byte b in bytes)
            {
                crc = table[crc ^ b];
            }

            return crc;
        }

        static Crc8()
        {
            for (int i = 0; i < 256; ++i)
            {
                int temp = i;
                for (int j = 0; j < 8; ++j)
                {
                    if ((temp & 0x80) != 0)
                    {
                        temp = (temp << 1) ^ poly;
                    }
                    else
                    {
                        temp <<= 1;
                    }
                }
                table[i] = (byte)temp;
            }
        }
    }
}
