﻿using System;
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

        /// <summary>
        /// Finds the command.
        /// </summary>
        /// <returns></returns>
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
            if ((currentCommand & 65408) == (short)Cmds.NOT)
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
            if ((currentCommand & 62208) == (short)Cmds.BZ)
                return Cmds.BZ;
            if ((currentCommand & 62208) == (short)Cmds.BNZ)
                return Cmds.BNZ;
            if ((currentCommand & 62208) == (short)Cmds.BC)
                return Cmds.BC;
            if ((currentCommand & 62208) == (short)Cmds.B)
                return Cmds.B;

            // 63488 = 11111000 00000000
            if ((currentCommand & 63488) == (short)Cmds.BZD)
                return Cmds.BZD;
            if ((currentCommand & 63488) == (short)Cmds.BNZD)
                return Cmds.BNZD;
            if ((currentCommand & 63488) == (short)Cmds.BCD)
                return Cmds.BCD;
            if ((currentCommand & 63488) == (short)Cmds.BD)
                return Cmds.BD;

            //57344 = 11100000 00000000
            if ((currentCommand & 57344) == (short)Cmds.SWDD)
                return Cmds.SWDD;
            if ((currentCommand & 57344) == (short)Cmds.LWDD)
                return Cmds.LWDD;

            throw new Exception("Command not found for: " + currentCommand);
            //return Cmds.UNDEFINED;
        }

        /// <summary>
        /// Finds the registry number.
        /// </summary>
        /// <returns></returns>
        private short findRegNr()
        {
            return (short)((ToShort(CommandRegister) & (3 << 10)) >> 10);
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        public void Execute()
        {
            short regNr = 0;
            bool countUp = true;
            switch (find())
            {
                case Cmds.END: //checked by tbx
                    countUp = false;
                    IsRunnung = false;
                    break;
                case Cmds.CLR: //checked by tbx
                    regNr = findRegNr();
                    Register[regNr] = new byte[2];
                    CarryFlag = false;
                    break;
                case Cmds.ADD: //checked by tbx - MUST BE RECHECKED PLEASE!!!!!
                    /* Ich bin mir nicht sicher was als resultat angegeben werden soll, falls ein überlauf statt gefunden hat?
                     * im moment zeige ich das resultat an, wie es gewesen wöre (einfach auf 16 bit gekürzt)
                     */
                    regNr = findRegNr();
                    Register[0] = AddBytes(Register[0], Register[regNr]); // FromShort((short)(ToShort(Register[0]) + ToShort(Register[regNr])));
                    break;
                case Cmds.ADDD: //MUST BE RECHECKED PLEASE!!!!!
                    Register[0] = AddBytes(Register[0], FromShort((short)(ToShort(CommandRegister) & 32767))); // 01111111 11111111
                    break;
                case Cmds.INC: //MUST BE RECHECKED PLEASE!!!!!
                    Register[0] = AddBytes(Register[0], FromShort(1));
                    break;
                case Cmds.DEC: //MUST BE RECHECKED PLEASE!!!!!
                    Register[0] = AddBytes(Register[0], FromShort(short.MinValue + 1));
                    break;
                case Cmds.LWDD: //checked by tbx
                    //mask = 1023 (00000011 11111111)
                    Register[findRegNr()] = FromMemory((short)(ToShort(CommandRegister) & 1023), WORD_LENGTH);
                    break;
                case Cmds.SWDD: //checked by tbx
                    ToMemory(Register[findRegNr()], (short)(ToShort(CommandRegister) & 1023));
                    break;
                case Cmds.SRA:
                    var origSra = Register[0];
                    CarryFlag = LSb(origSra);
                    //Register[0] = protectMsb(MSb(Register[0]), FromShort((short)((ToShort(Register[0]) >> 1))));
                    Register[0] = FromShort((short)((ToShort(Register[0]) >> 1)));
                    break;
                case Cmds.SLA:
                    CarryFlag = (ToShort(Register[0]) & (1 << 14)) == (1 << 14); // 0100000000000000
                    //Register[0] = protectMsb(MSb(Register[0]), FromShort((short)(ToShort(Register[0]) << 1)));
                    Register[0] = FromShort((short)(ToShort(Register[0]) << 1));
                    break;
                case Cmds.SRL:
                    CarryFlag = LSb(Register[0]);
                    //Register[0] = FromShort((short)(ToShort(Register[0]) >> 1));
                    Register[0] = FromShort((short)((ushort)ToShort(Register[0]) >> 1));
                    break;
                case Cmds.SLL:
                    CarryFlag = MSb(Register[0]);
                    //Register[0] = FromShort((short)(ToShort(Register[0]) << 1));
                    Register[0] = FromShort((short)((ushort)ToShort(Register[0]) << 1));
                    break;
                case Cmds.AND:
                    Register[0] = FromShort((short)(ToShort(Register[0]) & ToShort(Register[findRegNr()])));
                    break;
                case Cmds.OR:
                    Register[0] = FromShort((short)(ToShort(Register[0]) | ToShort(Register[findRegNr()])));
                    break;
                case Cmds.NOT: //checked by tbx
                    Register[0] = FromShort((short)(~ToShort(Register[0])));
                    break;
                case Cmds.BZ: //checked by tbx
                    if (Register[0][0] == 0 && Register[0][1] == 0)
                    {
                        countUp = false;
                        CommandCounter = Register[findRegNr()];
                    }
                    break;
                case Cmds.BNZ: //checked by tbx
                    if (Register[0][0] != 0 || Register[0][1] != 0)
                    {
                        countUp = false;
                        CommandCounter = Register[findRegNr()];
                    }
                    break;
                case Cmds.BC: //checked by tbx
                    if (CarryFlag)
                    {
                        countUp = false;
                        CommandCounter = Register[findRegNr()];
                    }
                    break;
                case Cmds.B: //checked by tbx
                    countUp = false;
                    CommandCounter = Register[findRegNr()];
                    break;
                case Cmds.BZD: //checked by tbx
                    if (Register[0][0] == 0 && Register[0][1] == 0)
                    {
                        countUp = false;
                        CommandCounter = FromShort((short)(ToShort(CommandRegister) & 1023)); // 00000011 11111111
                    }
                    break;
                case Cmds.BNZD: //checked by tbx
                    if (Register[0][0] != 0 || Register[0][1] != 0)
                    {
                        countUp = false;
                        CommandCounter = FromShort((short)(ToShort(CommandRegister) & 1023));// 00000011 11111111
                    }
                    break;
                case Cmds.BCD: //checked by tbx
                    if (CarryFlag)
                    {
                        countUp = false;
                        CommandCounter = FromShort((short)(ToShort(CommandRegister) & 1023));// 00000011 11111111
                    }
                    break;
                case Cmds.BD: //checked by tbx
                    countUp = false;
                    CommandCounter = FromShort((short)(ToShort(CommandRegister) & 1023));// 00000011 11111111
                    break;
            }

            if (countUp)
                CommandCounter = FromShort((short)(ToShort(CommandCounter) + 2));
            if (IsRunnung)
                StepCounter++;
        }

        /// <summary>
        /// Fetches the command.
        /// </summary>
        public void Fetch()
        {
            CommandRegister = FromMemory((int)ToShort(CommandCounter), Cpu.WORD_LENGTH);
        }

        /// <summary>
        /// Most significant bit.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public static bool MSb(byte[] b)
        {
            return (b[0] & (1 << 7)) == (1 << 7);
        }

        /// <summary>
        /// Least significant bit.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public static bool LSb(byte[] b)
        {
            return (b[b.Length - 1] & 1) == 1;
        }

        /// <summary>
        /// Addition of bytes.
        /// </summary>
        /// <param name="b1">The b1.</param>
        /// <param name="b2">The b2.</param>
        /// <returns></returns>
        private byte[] AddBytes(byte[] b1, byte[] b2)
        {
            short n1 = ToShort(b1);
            short n2 = ToShort(b2);
            var ires = n1 + n2;
            short res;
            byte[] retVal = new byte[2];
            CarryFlag = !short.TryParse(ires.ToString(), out res);
            if (CarryFlag) // überlauf...
            {
                var i = new[] { (byte)(ires >> 8), (byte)(ires & 255) };
                //retVal = protectMsb((((ires >> 31) & 1) == 1), i);
                retVal = i;
            }
            else
            {
                retVal = FromShort(res);
            }
            return retVal;
        }

        private byte[] protectMsb(bool set, byte[] n)
        {
            if (set) // negative zahl
                n[0] = (byte)(n[0] | (1 << 7));
            else
                n[0] = (byte)(n[0] & ~(1 << 7)); //~ == invers
            return n;
        }

        /// <summary>
        /// Converts to short.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns></returns>
        public static short ToShort(byte[] bytes)
        {
            return (short)((bytes[0] << 8) | (bytes[1] << 0));
        }

        /// <summary>
        /// Converts from short.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public static byte[] FromShort(short number)
        {
            return new[] { (byte)(number >> 8), (byte)(number & 255) };
        }

        /// <summary>
        /// To the binary string.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns></returns>
        public static string ToBinaryString(byte[] bytes)
        {
            //var s = ToShort(bytes);
            return string.Format("{0,8}-{1,8}", Convert.ToString((short)(bytes[0] << 0), 2), Convert.ToString((short)(bytes[1] << 0), 2)).Replace(' ', '0').Replace('-', ' ');
        }
    }
}