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
            UNDEFINED = -1,
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

            // 65408 = 11111111 10000000
            if ((currentCommand & 65280) == (short)Cmds.NOT)
                return Cmds.NOT;

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

            //57344 = 11100000 00000000
            if ((currentCommand & 57344) == (short)Cmds.SWDD)
                return Cmds.SWDD;
            if ((currentCommand & 57344) == (short)Cmds.LWDD)
                return Cmds.LWDD;

            return Cmds.UNDEFINED;
        }

        private short findRegNr()
        {
            return (short)((ToShort(CommandRegister) & (3 << 10)) >> 10);
        }

        public void Execute()
        {
            Cmds cmd = find();
            short regNr = 0;
            bool countUp = true;
            switch (cmd)
            {
                case Cmds.END:
                    countUp = false;
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
                    Register[0] = AddBytes(Register[0], Register[regNr]); // FromShort((short)(ToShort(Register[0]) + ToShort(Register[regNr])));
                    // TODO: carryflag korrekt setzen
                    CarryFlag = false;
                    break;
                case Cmds.ADDD:
                    //mask = 32767 (01111111 11111111)
                    Register[0] = AddBytes(Register[0], FromShort((short)(ToShort(CommandRegister) ^ 32767)));
                    break;
                case Cmds.INC:
                    Register[0] = AddBytes(Register[0], FromShort(1));
                    break;
                case Cmds.DEC:
                    Register[0] = AddBytes(Register[0], FromShort(-1));
                    break;
                case Cmds.LWDD:
                    //mask = 1023 (00000011 11111111)
                    Register[findRegNr()] = FromMemory((short)(ToShort(CommandRegister) & 1023), WORD_LENGTH);
                    break;
                case Cmds.SWDD:
                    ToMemory(Register[findRegNr()], (short)(ToShort(CommandRegister) & 1023));
                    break;
                case Cmds.SRA:
                    //TODO: correct shift right arithmetic
                    var origSra = Register[0];
                    CarryFlag = LSb(origSra);
                    Register[0] = FromShort((short)(((ToShort(origSra) >> 1)) | (ToShort(origSra) & 192))); //192 = 11000000
                    break;
                case Cmds.SLA:
                    //TODO: correct shift left arithmetic
                    var origSla = Register[0];
                    var origSlaMSb = MSb(origSla);
                    CarryFlag = MSb(FromShort((short)(ToShort(origSla) >> 1)));
                    Register[0] = FromShort((short)((ToShort(Register[0]) << 1)));
                    break;
                case Cmds.SRL:
                    CarryFlag = LSb(Register[0]);
                    Register[0] = FromShort((short)(ToShort(Register[0]) >> 1));
                    break;
                case Cmds.SLL:
                    CarryFlag = MSb(Register[0]);
                    Register[0] = FromShort((short)(ToShort(Register[0]) << 1));
                    break;
                case Cmds.AND:
                    Register[0] = FromShort((short)(ToShort(Register[0]) & ToShort(Register[findRegNr()])));
                    break;
                case Cmds.OR:
                    Register[0] = FromShort((short)(ToShort(Register[0]) | ToShort(Register[findRegNr()])));
                    break;
                case Cmds.NOT:
                    Register[0] = FromShort((short)(~ToShort(Register[0]) - 1));
                    break;
                case Cmds.BZ:
                    if (Register[0] == new byte[2] { 0, 0 })
                    {
                        countUp = false;
                        CommandCounter = Register[findRegNr()];
                    }
                    break;
                case Cmds.BNZ:
                    if (Register[0] != new byte[2] { 0, 0 })
                    {
                        countUp = false;
                        CommandCounter = Register[findRegNr()];
                    }
                    break;
                case Cmds.BC:
                    if (CarryFlag)
                    {
                        countUp = false;
                        CommandCounter = Register[findRegNr()];
                    }
                    break;
                case Cmds.B:
                    countUp = false;
                    CommandCounter = Register[findRegNr()];
                    break;
                case Cmds.BZD:
                    if (Register[0] == new byte[2] { 0, 0 })
                    {
                        countUp = false;
                        CommandCounter = FromShort((short)(ToShort(CommandRegister) & 1023));
                    }
                    break;
                case Cmds.BNZD:
                    if (Register[0] != new byte[2] { 0, 0 })
                    {
                        countUp = false;
                        CommandCounter = FromShort((short)(ToShort(CommandRegister) & 1023));
                    }
                    break;
                case Cmds.BCD:
                    if (CarryFlag)
                    {
                        countUp = false;
                        CommandCounter = FromShort((short)(ToShort(CommandRegister) & 1023));
                    }
                    break;
                case Cmds.BD:
                    countUp = false;
                    CommandCounter = FromShort((short)(ToShort(CommandRegister) & 1023));
                    break;
            }

            if (countUp)
                CommandCounter = AddBytes(CommandCounter, FromShort(2));
            if (IsRunnung)
                StepCounter++;
        }

        public void Fetch()
        {
            CommandRegister = FromMemory((int)ToShort(CommandCounter), Cpu.WORD_LENGTH);
        }

        public static bool MSb(byte[] b)
        {
            return ((b[0] >> 7) & 1) == 1;
        }

        public static bool LSb(byte[] b)
        {
            return (b[b.Length - 1] & 1) == 1;
        }

        public byte[] AddBytes(byte[] b1, byte[] b2)
        {
            var s = ToShort(b1) + ToShort(b2);
            CarryFlag = s > short.MaxValue;
            return FromShort((short)s);
        }

        public static short ToShort(byte[] bytes)
        {
            return (short)((bytes[0] << 8) | (bytes[1] << 0));
        }

        public static byte[] FromShort(short number)
        {
            return new[] { (byte)(number >> 8), (byte)(number & 255) };
        }
    }
}
