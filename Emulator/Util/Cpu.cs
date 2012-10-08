
namespace Emulator.Util
{
    public class Cpu
    {
        public const int WORD_LENGTH = 2;
        public const int MEMORY_SIZE = 2 ^ 10;

        // Accumulator = 0, R1, R2, R3
        public short[] Register { get; set; }
        public short CommandRegister { get; set; }
        public short CommandCounter { get; set; }

        public byte[] Memory { get; set; }

        public bool CarryFlag { get; set; }

        public Cpu()
        {
            Register = new short[4];
            Memory = new byte[MEMORY_SIZE];
            CommandCounter = 100;
        }
    }
}
