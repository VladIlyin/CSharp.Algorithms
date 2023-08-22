namespace CSharp.Algorithms.Problems.Topics.BitManipulation;

public partial class BitManipulation
{
    public static int HammingWeight(uint n)
    {
        var count = 0;

        while (n != 0)
        {
            count += (int)(n % 2);
            n >>= 1;
        }

        return count;
    }
}