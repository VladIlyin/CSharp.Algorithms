namespace CSharp.Algorithms.Problems.Topics.BitManipulation;

public partial class BitManipulation
{
    public static bool IsPowerOfTwo(int n)
    {
        if (n <= 0) return false;

        return (n & (n - 1)) == 0;
    }
}