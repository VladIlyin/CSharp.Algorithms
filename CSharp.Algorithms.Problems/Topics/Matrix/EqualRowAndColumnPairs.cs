using System.Security.Cryptography.X509Certificates;

namespace CSharp.Algorithms.Problems.Topics.Matrix;

public partial class MatrixProblem
{
    public static int EqualPairs(int[][] grid)
    {
        var rows = new Dictionary<string, int>();
        string stringKey;

        for (var i = 0; i < grid.Length; i++)
        {
            var row = grid[i];
            stringKey = string.Join(",", row);
            if (!rows.TryAdd(stringKey, rows.GetValueOrDefault(stringKey, 0) + 1))
            {
                rows[stringKey]++;
            }
        }

        var res = 0;
        var col = new int[grid.Length];
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid.Length; j++)
            {
                col[j] = grid[j][i];
            }

            stringKey = string.Join(",", col);
            res += rows.ContainsKey(stringKey) ? rows[stringKey] : 0;
        }

        return res;

        //var rows = new Dictionary<string, int>();
        //var cols = new Dictionary<string, int>();
        //var col = new int[grid.Length];

        //for (var i = 0; i < grid.Length; i++)
        //{
        //    for (var j = 0; j < grid.Length; j++)
        //    {
        //        col[j] = grid[j][i];
        //    }

        //    var str = string.Join(",", grid[i]);
        //    if (!rows.TryAdd(str, rows.GetValueOrDefault(str, 0) + 1))
        //    {
        //        rows[str]++;
        //    }

        //    str = string.Join(",", col);
        //    if (!cols.TryAdd(str, cols.GetValueOrDefault(str, 0) + 1))
        //    {
        //        cols[str]++;
        //    }
        //}

        //return rows
        //    .Keys
        //    .Intersect(cols.Keys)
        //    .Sum(key => rows[key] * cols[key]);
    }
}