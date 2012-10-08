using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class Command
    {
        public static readonly IDictionary<string, byte[]> Commands = new Dictionary<string, byte[]>();

        static Command()
        {
            InitCommands();
        }

        public static void Execute()
        {
        }

        public static string Find(short command)
        {
            foreach (var cmd in Commands.OrderByDescending(v => v.Value))
            {
                if ((command & ToShort(cmd.Value)) == ToShort(cmd.Value))
                    return cmd.Key;
            }
            return null;
        }

        public static short ToShort(byte[] bytes)
        {
            return (short)((bytes[1] << 8) | (bytes[0] << 0));
        }

        public static byte[] FromShort(short number)
        {
            return new[] { (byte)(number >> 8), (byte)(number & 255) }; //TODO: or other way round...
        }

        private static void InitCommands()
        {
            Commands.Add("CLR", FromShort(640));
            Commands.Add("ADD", FromShort(896));
            Commands.Add("ADDD", FromShort(-32768));
            Commands.Add("INC", FromShort(256));
            Commands.Add("DEC", FromShort(1024));

            Commands.Add("LWDD", FromShort(16384));
            Commands.Add("SWDD", FromShort(24576));

            Commands.Add("SRA", FromShort(1280));
            Commands.Add("SLA", FromShort(2048));
            Commands.Add("SRL", FromShort(2304));
            Commands.Add("SLL", FromShort(3072));

            Commands.Add("AND", FromShort(512));
            Commands.Add("OR", FromShort(768));
            Commands.Add("NOT", FromShort(128));

            Commands.Add("BZ", FromShort(4608));
            Commands.Add("BNZ", FromShort(4352));
            Commands.Add("BC", FromShort(4864));
            Commands.Add("B", FromShort(4096));
            Commands.Add("BZD", FromShort(12288));
            Commands.Add("BNZD", FromShort(10240));
            Commands.Add("BCD", FromShort(14336));
            Commands.Add("BD", FromShort(8192));

            Commands.Add("END", FromShort(0));
            Console.WriteLine(ToShort(FromShort(0)));
        }
    }
}
