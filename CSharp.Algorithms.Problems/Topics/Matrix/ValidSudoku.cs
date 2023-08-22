namespace CSharp.Algorithms.Problems.Topics.Matrix;

public partial class MatrixProblem
{
    public static bool IsValidSudoku(char[][] board)
    {
        for (var i = 0; i < board.Length; i++)
        {
            if (!CheckRowAndColumn(board, i))
            {
                return false;
            }

            if (i % 3 == 0)
            {
                if (!CheckSubBoxes(board, i))
                {
                    return false;
                }
            }
        }

        return true;
    }

    static bool CheckRowAndColumn(char[][] board, int idx)
    {
        var row = new HashSet<char>(9);
        var column = new HashSet<char>(9);

        for (var i = 0; i < board.Length; i++)
        {
            if (row.Contains(board[idx][i]) || column.Contains(board[i][idx]))
            {
                return false;
            }
                
            if (board[idx][i] != '.') row.Add(board[idx][i]);

            if (board[i][idx] != '.') column.Add(board[i][idx]);
        }

        return true;
    }

    static bool CheckSubBoxes(char[][] board, int iInit)
    {
        var subBox = new HashSet<char>(9);

        for (var jInit = 0; jInit < board[iInit].Length; jInit += 3)
        {
            for (var i = iInit; i < iInit + 3; i++)
            {
                for (var j = jInit; j < jInit + 3; j++)
                {
                    if (subBox.Contains(board[i][j]))
                    {
                        return false;
                    }

                    if ((board[i][j] != '.'))
                        subBox.Add(board[i][j]);
                }
            }

            subBox.Clear();
        }

        return true;
    }
}