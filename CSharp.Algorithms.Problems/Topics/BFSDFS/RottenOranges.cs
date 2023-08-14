namespace CSharp.Algorithms.Problems.Topics.BFSDFS;

public partial class BFSDFS
{
    public static int OrangesRotting(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int oranges = 0;//contains total oranges present 
        int count = 0;//contains count of rotten oranges
        int ans = 0;
        Queue<(int, int)> rotten = new Queue<(int, int)>();//used for bfs
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] != 0) { oranges++; }//counting oranges
                if (grid[i][j] == 2) { rotten.Enqueue((i, j)); }//storing indexes of rotten oranges for BFS.
            }
        }

        int[] dx = { 0, 0, 1, -1 };//used for checking nearby oranges
        int[] dy = { 1, -1, 0, 0 };

        while (rotten.Count > 0)
        {
            int k = rotten.Count;
            count += k;//increase count by number of rotten oranges
            while (k > 0)
            {//checking nearby oranges of rotten oranges
                k--;
                (int x, int y) = rotten.Dequeue();
                //int x = rotten.front().first;
                //int y = rotten.front().second;
                //rotten.pop();//removing that index from queue after checking
                for (int i = 0; i < 4; i++)
                {
                    int newx = x + dx[i];
                    int newy = y + dy[i];
                    if (newx < 0 || newx >= m || newy < 0 || newy >= n || grid[newx][newy] != 1) 
                    { 
                        continue; 
                    }//if nearby orange doesn't exist or is rotten already
                    grid[newx][newy] = 2;//mark orange rotten
                    rotten.Enqueue((newx, newy));//insert it's index in queue
                }
            }

            if (rotten.Count > 0)
            {
                ans++;//increase the time by 1
            }
        }

        if (oranges == count)
        {   //if all oranges can get rotten
            return ans;
        }

        return -1;//if some oranges can't get rotten
    }
}