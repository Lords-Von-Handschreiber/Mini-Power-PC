using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class Cpu
    {
        public const int WORD_LENGTH = 2;
        public const int MEMORY_SIZE = 2 ^ 10;

        public MemoryStream Memory { get; set; }

        private const int carryFlagAddress = 66;
        public byte[] CarryFlag
        {
            get
            {
                var retVal = new byte[2];
                Memory.Read(retVal, carryFlagAddress, WORD_LENGTH);
                return retVal;
            }
            set
            {
                Memory.Write(value, carryFlagAddress, WORD_LENGTH);
            }
        }

        private byte[] buffer;

        public Cpu()
        {
            buffer = buffer = new byte[MEMORY_SIZE];
            Memory = new MemoryStream(buffer);
        }
    }
}
