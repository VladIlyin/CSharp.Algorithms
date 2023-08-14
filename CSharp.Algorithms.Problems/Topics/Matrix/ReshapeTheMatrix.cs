namespace CSharp.Algorithms.Problems.Topics.Matrix;

public partial class MatrixProblem
{
    public static int[][] MatrixReshape(int[][] mat, int r, int c)
    {
        if (mat == null || mat.Length == 0) return mat;

        int elemCount = mat.Length * mat[0].Length;

        if (elemCount != r * c) return mat;

        int row = 0, col = 0, elemNum = 1;

        var res = new int[r][];
        for (int i = 0; i < r; i++)
        {
            res[i] = new int[c];
        }

        for (int i = 0; i < mat.Length; i++)
        {
            for (int j = 0; j < mat[i].Length; j++)
            {
                if (elemNum % c == 0)
                {
                    row = (elemNum / c) - 1;
                    col = c - 1;
                }
                else
                {
                    row = elemNum / c;
                    col = (elemNum % c) - 1;
                }

                //row = elemNum % c == 0 ? (elemNum / c) - 1 : elemNum / c;
                //col = elemNum % c == 0 ? c - 1 : (elemNum % c) - 1;

                res[row][col] = mat[i][j];
                elemNum++;
            }
        }

        return res;
    }
}