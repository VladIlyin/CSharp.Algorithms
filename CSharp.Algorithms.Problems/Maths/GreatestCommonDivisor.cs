namespace CSharp.Algorithms.Problems.Maths;

public partial class Maths
{
    public static int GreatestCommonDivisor(int a, int b) => b == 0 ? a : GreatestCommonDivisor(b, a % b);
}