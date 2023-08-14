namespace CSharp.Algorithms.Problems.Topics.BFSDFS;

public partial class BFSDFS
{
    public static int[][] Update01MatrixDP(int[][] mat)
    {
        int rows = mat.Length;
        if (rows == 0)
            return mat;
        int cols = mat[0].Length;

        // vector<vector<int>> dist(rows, vector<int> (cols, INT_MAX -100000));
        int[][] dist = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            dist[i] = new int[cols];
        }

        //First pass: check for left and top
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (mat[i][j] == 0)
                {
                    mat[i][j] = 0;
                }
                else
                {
                    if (i > 0)
                        mat[i][j] = Math.Min(mat[i][j], mat[i - 1][j] + 1);
                    if (j > 0)
                        mat[i][j] = Math.Min(mat[i][j], mat[i][j - 1] + 1);
                }
            }
        }

        //Second pass: check for bottom and right
        for (int i = rows - 1; i >= 0; i--)
        {
            for (int j = cols - 1; j >= 0; j--)
            {
                if (i < rows - 1)
                    mat[i][j] = Math.Min(mat[i][j], mat[i + 1][j] + 1);
                if (j < cols - 1)
                    mat[i][j] = Math.Min(mat[i][j], mat[i][j + 1] + 1);
            }
        }

        return mat;
    }

    public static int[][] Update01Matrix(int[][] mat)
    {
        Queue<(int, int)> queue = new Queue<(int, int)>();
        HashSet<(int, int)> set = new HashSet<(int, int)>();
        int[,] visited = new int[mat.Length, mat[0].Length];

        for (int i = 0; i < mat.Length; i++)
        {
            for (int j = 0; j < mat[i].Length; j++)
            {
                if (mat[i][j] == 0)
                {
                    continue;
                }

                mat[i][j] = FindNearestDistanceToZero(mat, i, j);
            }
        }

        int FindNearestDistanceToZero(int[][] mat, int i, int j)
        {
            var (initI, initJ) = (i, j);
                
            queue.Enqueue((i, j));
            set.Add((i, j));

            while (queue.Count > 0)
            {
                (i, j) = queue.Dequeue();

                // go up
                if (i > 0 && !set.Contains((i - 1, j)))
                {
                    if (mat[i - 1][j] == 0)
                    {
                        i--;
                        break;
                    }
                    queue.Enqueue((i - 1, j));
                    set.Add((i - 1, j));
                }

                // go down
                if (i < mat.Length - 1 && !set.Contains((i + 1, j)))
                {
                    if (mat[i + 1][j] == 0)
                    {
                        i++;
                        break;
                    }
                    queue.Enqueue((i + 1, j));
                    set.Add((i + 1, j));
                }

                // go left
                if (j > 0 && !set.Contains((i, j - 1)))
                {
                    if (mat[i][j - 1] == 0)
                    {
                        j--;
                        break;
                    }
                    queue.Enqueue((i, j - 1));
                    set.Add((i, j - 1));
                }

                // go right
                if (j < mat[i].Length - 1 && !set.Contains((i, j + 1)))
                {
                    if (mat[i][j + 1] == 0)
                    {
                        j++;
                        break;
                    }
                    queue.Enqueue((i, j + 1));
                    set.Add((i, j + 1));
                }
            }

            queue.Clear();
            set.Clear();
            return Math.Abs(initI - i) + Math.Abs(initJ - j);
        }

        return mat;
    }
}