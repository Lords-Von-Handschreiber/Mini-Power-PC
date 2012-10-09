
using Utils;
namespace Emulator.Util
{
    public class Cpu
    {
        public const int WORD_LENGTH = 2;
        public const int MEMORY_SIZE = 2 ^ 10;

        // Accumulator = 0, R1, R2, R3
        public byte[][] Register { get; set; }
        public byte[] CommandRegister { get; set; }
        public byte[] CommandCounter { get; set; }

        protected byte[] Memory { get; set; }

        public bool CarryFlag { get; set; }

        public Cpu()
        {
            CommandCounter = Command.FromShort(100);

            Register = new byte[4][];
            Register[0] = new byte[2];
            Register[1] = new byte[2];
            Register[2] = new byte[2];
            Register[3] = new byte[2];

            Memory = new byte[MEMORY_SIZE];

            CarryFlag = false;
        }

        public void ToMemory(byte[] data, int offset)
        {
            for (var i = 0; i < data.Length; i++)
            {
                Memory[offset + i] = data[i];
            }
        }
        
        public byte[] FromMemory(int offset)
        {
            return FromMemory(offset, Memory.Length - offset);
        }
        
        public byte[] FromMemory(int offset, int count)
        {
            byte[] retVal = new byte[count + 1];
            for (int i = 0; i < count; i++)
            {
                retVal[i] = Memory[offset + i];
            }
            return retVal;
        }
    }
}
