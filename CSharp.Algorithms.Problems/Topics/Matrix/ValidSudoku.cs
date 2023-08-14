namespace CSharp.Algorithms.Problems.Topics.Matrix;

public partial class MatrixProblem
{
    public static bool IsValidSudoku(char[][] board)
    {
        for (int i = 0; i < board.Length; i++)
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
        HashSet<char> row = new HashSet<char>(9);
        HashSet<char> column = new HashSet<char>(9);

        for (int i = 0; i < board.Length; i++)
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
        HashSet<char> subBox = new HashSet<char>(9);

        for (int jInit = 0; jInit < board[iInit].Length; jInit += 3)
        {
            for (int i = iInit; i < iInit + 3; i++)
            {
                for (int j = jInit; j < jInit + 3; j++)
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