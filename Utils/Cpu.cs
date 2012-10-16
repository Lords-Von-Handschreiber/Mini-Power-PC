
namespace Utils
{
    public partial class Cpu
    {
        public const int WORD_LENGTH = 2;
        public readonly int MEMORY_SIZE = (int)System.Math.Pow(2, 10); // 2^10

        // Accumulator = 0, R1, R2, R3
        public byte[][] Register { get; set; }
        public byte[] CommandRegister { get; set; } //aktueller befehl
        public byte[] CommandCounter { get; set; }

        public byte[] Memory { get; set; }
        public bool CarryFlag { get; set; }

        public double StepCounter = 0;

        public bool IsRunnung { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cpu" /> class.
        /// </summary>
        public Cpu()
        {
            IsRunnung = false;

            Register = new byte[4][];
            Register[0] = new byte[2];
            Register[1] = new byte[2];
            Register[2] = new byte[2];
            Register[3] = new byte[2];

            CommandRegister = new byte[2];

            Memory = new byte[MEMORY_SIZE];

            CarryFlag = false;
        }

        /// <summary>
        /// Writes to the memory.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="offset">The offset.</param>
        public void ToMemory(byte[] data, int offset)
        {
            for (var i = 0; i < data.Length; i++)
            {
                Memory[offset + i] = data[i];
            }
        }

        /// <summary>
        /// Reads from the memory.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <returns></returns>
        public byte[] FromMemory(int offset)
        {
            return FromMemory(offset, Memory.Length - offset);
        }

        /// <summary>
        /// Reads from the memory.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public byte[] FromMemory(int offset, int count)
        {
            byte[] retVal = new byte[count];
            for (int i = 0; i < count; i++)
            {
                retVal[i] = Memory[offset + i];
            }
            return retVal;
        }
    }
}
