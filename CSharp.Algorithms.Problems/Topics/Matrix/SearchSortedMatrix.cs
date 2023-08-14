namespace CSharp.Algorithms.Problems.Topics.Matrix;

public partial class MatrixProblem
{
    public static bool SearchMatrix(int[][] matrix, int target)
    {
        if (matrix == null || matrix.Length == 0) return false;

        if (matrix.Length == 1 && matrix[0].Length == 1)
            return matrix[0][0] == target;

        int rowCount = matrix.Length;
        int colCount = matrix[0].Length;
        int row = 0, col = 0;

        int minNum = 0;
        int maxNum = rowCount * colCount - 1;

        while (minNum <= maxNum)
        {

            int mid = (minNum + maxNum) / 2;
            getCoordinatesByElemNum(mid + 1);

            if (target == matrix[row][col])
            {
                return true;
            }
            else if (target < matrix[row][col])
            {
                maxNum = mid - 1;
            }
            else
            {
                minNum = mid + 1;
            }
        }

        return false;

        void getCoordinatesByElemNum(int elemNum)
        {
            if (elemNum % colCount == 0)
            {
                row = elemNum / colCount - 1;
                col = colCount - 1;
            }
            else
            {
                row = elemNum / colCount;
                col = elemNum % colCount - 1;
            }
        }
    }
}