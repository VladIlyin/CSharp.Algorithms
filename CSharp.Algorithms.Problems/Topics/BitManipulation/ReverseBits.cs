namespace CSharp.Algorithms.Problems.Topics.BitManipulation;

public partial class BitManipulation
{
    public static uint ReverseBits(uint n)
    {
        uint reversed = 0;
        byte i = 0;

        // traversing 32 bits of 'n' from the right
        // we know in advance, that we have exactly 32 bits
        while (i < 32)
        {
            // bitwise left shift 'reversed' by 1
            // make current bit always '0'
            reversed <<= 1;

            // if current bit is '1' add '1' bit to 'reversed' with XOR operation
            if ((int)(n & 1) == 1)
                reversed ^= 1;

            // bitwise right shift 'n' by 1
            n >>= 1;

            i++;
        }

        return reversed;
    }
}