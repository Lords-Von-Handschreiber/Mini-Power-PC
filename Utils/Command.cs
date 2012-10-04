using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class Command
    {
        private static readonly IDictionary<string, short> Commands = new Dictionary<string, short>();

        static Command()
        {
            InitCommands();
        }


        public static void Execute()
        {
        }

        public static short Find(string key)
        {
            return Commands[key];
        }

        public static short ToShort(byte byte1, byte byte2)
        {
            return (short)((byte2 << 8) | (byte1 << 0));
        }

        public static void FromShort(short number, out byte byte1, out byte byte2)
        {
            byte2 = (byte)(number >> 8);
            byte1 = (byte)(number & 255);
        }

        private static void InitCommands()
        {
            Commands.Add("CLR", 640);
            Commands.Add("ADD", 896);
            Commands.Add("ADDD", -32768);
            Commands.Add("INC", 256);
            Commands.Add("DEC", 1024);

            Commands.Add("LWDD", 16384);
            Commands.Add("SWDD", 24576);

            Commands.Add("SRA", 1280);
            Commands.Add("SLA", 2048);
            Commands.Add("SRL", 2304);
            Commands.Add("SLL", 3072);

            Commands.Add("AND", 512);
            Commands.Add("OR", 768);
            Commands.Add("NOT", 128);

            Commands.Add("BZ", 4608);
            Commands.Add("BNZ", 4352);
            Commands.Add("BC", 4864);
            Commands.Add("B", 4096);
            Commands.Add("BZD", 12288);
            Commands.Add("BNZD", 10240);
            Commands.Add("BCD", 14336);
            Commands.Add("BD", 8192);

            Commands.Add("END", 0);
        }
    }
}
