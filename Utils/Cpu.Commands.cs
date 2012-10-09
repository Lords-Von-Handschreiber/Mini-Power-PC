using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
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

        private Cmds find()
        {
            var currentCommand = ToShort(CommandRegister);
            if (currentCommand == 0)
                return Cmds.END;

            if (currentCommand < 0)
                return Cmds.ADDD;
            // 62336 = 11110011 10000000
            if ((currentCommand & 62336) == (short)Cmds.CLR)
                return Cmds.CLR;
            if ((currentCommand & 62336) == (short)Cmds.ADD)
                return Cmds.ADD;
            if ((currentCommand & 62336) == (short)Cmds.AND)
                return Cmds.AND;
            if ((currentCommand & 62336) == (short)Cmds.OR)
                return Cmds.OR;

            // 65280 = 11111111 00000000
            if ((currentCommand & 65280) == (short)Cmds.INC)
                return Cmds.INC;
            if ((currentCommand & 65280) == (short)Cmds.DEC)
                return Cmds.DEC;
            if ((currentCommand & 65280) == (short)Cmds.SRA)
                return Cmds.SRA;
            if ((currentCommand & 65280) == (short)Cmds.SLA)
                return Cmds.SLA;
            if ((currentCommand & 65280) == (short)Cmds.SRL)
                return Cmds.SRL;
            if ((currentCommand & 65280) == (short)Cmds.SLL)
                return Cmds.SLL;

            // 65408 = 11111111 10000000
            if ((currentCommand & 65280) == (short)Cmds.NOT)
                return Cmds.NOT;

            // 62208 = 11110011 00000000
            if ((currentCommand & 65280) == (short)Cmds.BZ)
                return Cmds.BZ;
            if ((currentCommand & 65280) == (short)Cmds.BNZ)
                return Cmds.BNZ;
            if ((currentCommand & 65280) == (short)Cmds.BC)
                return Cmds.BC;
            if ((currentCommand & 65280) == (short)Cmds.B)
                return Cmds.B;

            // 63488 = 11111000 00000000
            if ((currentCommand & 65280) == (short)Cmds.BZD)
                return Cmds.BZD;
            if ((currentCommand & 65280) == (short)Cmds.BNZD)
                return Cmds.BNZD;
            if ((currentCommand & 65280) == (short)Cmds.BCD)
                return Cmds.BCD;
            if ((currentCommand & 65280) == (short)Cmds.BD)
                return Cmds.BD;

            return Cmds.NOT;
        }

        private short findRegNr()
        {
            return (short)((ToShort(CommandRegister) & (3 << 10)) >> 10);
        }

        public void Execute()
        {
            Cmds cmd = find();
            short regNr = 0;
            switch (cmd)
            {
                case Cmds.END:
                    IsRunnung = false;
                    break;
                case Cmds.CLR:
                    regNr = findRegNr();
                    Register[regNr][0] = 0;
                    Register[regNr][1] = 0;
                    CarryFlag = false;
                    break;
                case Cmds.ADD:
                    regNr = findRegNr();
                    Register[0] = FromShort((short)(ToShort(Register[0]) + ToShort(Register[regNr])));
                    // TODO: carryflag korrekt setzen
                    CarryFlag = false;
                    break;
            }

            CommandCounter = FromShort((short)(ToShort(CommandCounter) + 2));
            StepCounter++;
        }

        public void Fetch()
        {
            CommandRegister = FromMemory((int)ToShort(CommandCounter), Cpu.WORD_LENGTH);
        }

        public static short ToShort(byte[] bytes)
        {
            return (short)((bytes[1] << 8) | (bytes[0] << 0));
        }

        public static byte[] FromShort(short number)
        {
            return new[] { (byte)(number & 255), (byte)(number >> 8) }; //TODO: or other way round...
        }
    }
}
