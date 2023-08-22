namespace CSharp.Algorithms.Problems.Topics.Arrays;

public partial class ArraysProblem
{
    public static IList<IList<int>> Generate(int numRows)
    {
        if (numRows <= 0) return null;
        if (numRows == 1) return new List<IList<int>>() { new List<int>() { 1 } };

        var res = new List<IList<int>>()
        {
            new List<int>() { 1 },
            new List<int>() { 1, 1 },
        };

        var n = 3;

        while (n <= numRows)
        {
            res.Add(new List<int>() { 1 });

            for (var i = 0; i < res[n - 2].Count - 1; i++)
            {
                res[n - 1].Add(res[n - 2][i] + res[n - 2][i + 1]);
            }

            res[n - 1].Add(1);

            n++;
        }

        return res;
    }
}