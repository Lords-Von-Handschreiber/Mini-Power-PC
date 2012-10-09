using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulator.Util
{
    public partial class Cpu
    {
        public enum Cmds : short
        {
            ADDD = -32768,
            END = 0,
            NOT = 128,
            INC = 256,
            AND = 512,
            CLR = 640,
            OR = 768,
            ADD = 896,
            DEC = 1024,
            SRA = 1280,
            SLA = 2048,
            SRL = 2304,
            SLL = 3072,
            B = 4096,
            BNZ = 4352,
            BZ = 4608,
            BC = 4864,
            BD = 8192,
            BNZD = 10240,
            BZD = 12288,
            BCD = 14336,
            LWDD = 16384,
            SWDD = 24576
        }

        public static Cmds Find(short command)
        {
            Cmds retCmd = 0;
            foreach (short cmd in Enum.GetValues(typeof(Cmds)))
            {
                if ((command & cmd) == cmd)
                    retCmd = (Cmds)cmd;
            }
            return retCmd;
        }

        public static short ToShort(byte[] bytes)
        {
            return (short)((bytes[1] << 8) | (bytes[0] << 0));
        }

        public static byte[] FromShort(short number)
        {
            return new[] { (byte)(number & 255), (byte)(number >> 8) }; //TODO: or other way round...
        }

        public static void Execute()
        {
        }
    }
}
