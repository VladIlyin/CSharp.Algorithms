namespace CSharp.Algorithms.Problems.Topics.Techniques.DynamicProgramming._1_FibonacciNumbers;

public partial class DynamicProgrammingTechnique
{
    public static long ClimbStairs(int n)
    {
        if (n is 0 or 1)
            return 1;

        long temp = 1;
        long res = 1;

        for (var i = 2; i < n + 1; i++)
        {
            var accum = temp + res;
            temp = res;
            res = accum;
        }

        return res;
    }
}