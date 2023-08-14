namespace CSharp.Algorithms.Problems.Topics.BFSDFS;

public partial class BFSDFS
{
        
    // Rewrite algorithm without any "internal" methods

    public static int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        var initColor = image[sr][sc];
        return FloodFillInternal(image, sr, sc, ref color, ref initColor);

        static int[][] FloodFillInternal(int[][] image, int sr, int sc, ref int color, ref int initColor)
        {
            if (image[sr][sc] == color)
            {
                return image;
            }

            if (image[sr][sc] == initColor)
            {
                image[sr][sc] = color; 
            }
            else
            {
                return image;
            }

            // left
            if (sc > 0)
            {
                FloodFillInternal(image, sr, sc - 1, ref color, ref initColor);
            }

            // up
            if (sr > 0)
            {
                FloodFillInternal(image, sr - 1, sc, ref color, ref initColor);
            }

            // down
            if (sr < image.Length - 1)
            {
                FloodFillInternal(image, sr + 1, sc, ref color, ref initColor);
            }

            // right
            if (sc < image[sr].Length - 1)
            {
                FloodFillInternal(image, sr, sc + 1, ref color, ref initColor);
            }

            return image;
        }
    }
}