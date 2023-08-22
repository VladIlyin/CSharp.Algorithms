namespace CSharp.Algorithms.Problems.Topics.Techniques.DynamicProgramming;

public class TriangleMinimumTotal
{
    // https://www.youtube.com/watch?v=9z27sGgMRdw
    public static int MinimumTotal(IList<IList<int>> triangle)
    {
        var n = triangle.Count;
        var memo = new int[n][];

        for (var i = 0; i < n; i++)
        {
            memo[i] = new int[n];
            for (var j = 0; j < memo[i].Length; j++)
            {
                memo[i][j] = int.MaxValue;
            }
        }

        memo[0][0] = triangle[0][0];

        for (var i = 1; i < n; i++)
        for (var j = 0; j < triangle[i].Count; j++)
        {
            memo[i][j] =
                Math.Min(
                    memo[i - 1][j],
                    memo[i - 1][Math.Max(j - 1, 0)])
                + triangle[i][j];
        }

        return memo[n - 1].Min();
    }
}