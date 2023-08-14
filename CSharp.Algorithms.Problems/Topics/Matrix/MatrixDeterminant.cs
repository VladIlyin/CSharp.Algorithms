namespace CSharp.Algorithms.Problems.Topics.Matrix;

public partial class MatrixProblem
{
    public static int MatrixDeterminant(int[][] matrix)
    {
        switch (matrix.Length)
        {
            case 1:
                return matrix[0][0];
            case 2:
                return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
        }

        var res = 0;
        for (var i = 0; i < matrix.Length; i++)
        {
            res = i == 0
                ? matrix[0][i] * MatrixDeterminant(GetMinor(matrix, i))
                : i % 2 == 0
                    ? res + matrix[0][i] * MatrixDeterminant(GetMinor(matrix, i))
                    : res - matrix[0][i] * MatrixDeterminant(GetMinor(matrix, i));
        }

        return res;
    }

    private static int[][] GetMinor(IReadOnlyList<int[]> mx, int y)
    {
        var arr = new int[mx.Count - 1][];
        var n = 0;
        for (var i = 1; i < mx.Count; i++)
        {
            arr[n++] = mx[i].Where((_, idx) => idx != y).ToArray();
        }

        return arr;
    }
}