namespace CSharp.Algorithms.Problems.Topics.BFSDFS;

public partial class BFSDFS
{
    public static int MaxAreaOfIsland(int[][] grid)
    {

        int maxArea = 0;
        Queue<(int, int)> queue = new Queue<(int, int)>();

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    maxArea = Math.Max(maxArea, CalculateArea(i, j));
                }
            }
        }

        int CalculateArea(int i, int j)
        {
            int area = 1;
            queue.Enqueue((i, j));
            grid[i][j] = -1;

            while (queue.Count > 0)
            {
                (int sr, int sc) = queue.Dequeue();

                // go right
                if (sc < grid[sr].Length - 1 && grid[sr][sc + 1] == 1)
                {
                    queue.Enqueue((sr, sc + 1));
                    grid[sr][sc + 1] = -1;
                    area++;
                }

                // go down
                if (sr < grid.Length - 1 && grid[sr + 1][sc] == 1)
                {
                    queue.Enqueue((sr + 1, sc));
                    grid[sr + 1][sc] = -1;
                    area++;
                }

                // go left
                if (sc > 0 && grid[sr][sc - 1] == 1)
                {
                    queue.Enqueue((sr, sc - 1));
                    grid[sr][sc - 1] = -1;
                    area++;
                }

                // go up
                if (sr > 0 && grid[sr - 1][sc] == 1)
                {
                    queue.Enqueue((sr - 1, sc));
                    grid[sr - 1][sc] = -1;
                    area++;
                }
            }

            return area;
        }

        return maxArea;
    }
}