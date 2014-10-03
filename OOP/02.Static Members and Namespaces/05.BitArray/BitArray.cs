namespace Bit
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Numerics;

    public class BitArray
    {
        private const int MinBorder = 1;
        private const int MaxBorder = 100000;
        private const byte BitsPerByte = 16; // you can specify another dimension for bits per byte
        private readonly int numberOfBytes;
        private readonly byte[] bits;
        private int numberOfBits;

        /// <summary>
        /// Initialize an instance of <see cref="BitArray"/> class.
        /// </summary>
        /// <param name="numberOfBits">number of bits that will be significant - size in bits.</param>
        public BitArray(int numberOfBits)
        {
            this.NumberOfBits = numberOfBits;
            this.numberOfBytes = (int)Math.Ceiling(this.NumberOfBits / (float)BitsPerByte);
            this.bits = new byte[this.numberOfBytes * BitsPerByte];
        }

        /// <summary>
        /// Gets number of bits in this <see cref="BitArray"/> instance.
        /// </summary>
        public int NumberOfBits
        {
            get
            {
                return this.numberOfBits;
            }

            private set
            {
                if (value < MinBorder || value > MaxBorder)
                {
                    throw new ArgumentOutOfRangeException("numberOfBits", string.Format("Number of bits must be in the range [{0}..{1}]!", MinBorder, MaxBorder));
                }

                this.numberOfBits = value;
            }
        }

        private byte[] Bits
        {
            get { return this.bits; }
        }

        public byte this[int index]
        {
            get
            {
                if (index >= MinBorder - 1 || index < MaxBorder)
                {
                    return this.Bits[index];
                }

                throw new ArgumentOutOfRangeException(
                    "Index", string.Format("Index cannot be lower than {0} and higher {1}", MinBorder - 1, this.NumberOfBits - 1));
            }

            set
            {
                if ((index >= MinBorder - 1 || index < MaxBorder) && index < this.NumberOfBits)
                {
                    if (value == 0 || value == 1)
                    {
                        this.Bits[index] = value;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid bit value provided!");
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        "Index", string.Format("Index cannot be lower than {0} and higher {1}", MinBorder - 1, this.NumberOfBits - 1));
                }
            }
        }

        public override string ToString()
        {
            return this.ConvertBinToDec().ToString(CultureInfo.InvariantCulture);
        }

        private BigInteger ConvertBinToDec()
        {
            BigInteger result = 0;
            for (int byteIndex = 0; byteIndex < this.numberOfBytes; byteIndex++)
            {
                BigInteger partial = 0;
                var oneByte = new byte[BitsPerByte];
                Array.Copy(this.Bits, byteIndex * BitsPerByte, oneByte, 0, BitsPerByte);
                int maxBits = BitsPerByte;
                if ((byteIndex == this.numberOfBytes - 1) && (this.NumberOfBits % BitsPerByte != 0))
                {
                    maxBits = this.NumberOfBits % BitsPerByte;
                }

                // if current subarray is only zeros, we skip it (no setup bits in it), no need to calculate.
                if (oneByte.Max() == 0)
                {
                    continue;
                }

                // Calculate the number represented with bits as 8-bit number
                for (byte bit = 0; bit < maxBits; bit++)
                {
                    partial += oneByte[bit] * (uint)Math.Pow(2, bit);
                }

                // shifting calculated 8-bits number to the position(byte position) coresponding in result
                partial = partial << (byteIndex * BitsPerByte);

                // combine the calculated and already positioned number with current final number
                result = result | partial;
            }

            return result;
        }
    }
}
