namespace CSharp.Algorithms.Problems.Topics.BitManipulation;

public partial class BitManipulation
{
    // https://leetcode.com/problems/minimum-flips-to-make-a-or-b-equal-to-c/?envType=study-plan-v2&envId=leetcode-75
    public static int MinFlips(int a, int b, int c)
    {
        var flips = 0;

        while (a > 0 || b > 0 || c > 0)
        {
            flips += FlipCount(a & 1, b & 1, c & 1);
            a >>= 1;
            b >>= 1;
            c >>= 1;
        }

        return flips;

        int FlipCount(int n1, int n2, int n3)
        {
            if (n3 == 0)
            {
                return n1 + n2;
            }

            return n1 + n2 == 0 ? 1 : 0;
        }
    }
}