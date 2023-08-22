namespace CSharp.Algorithms.Problems.Topics.Arrays
{
    public partial class ArraysProblem
    {
        /// <summary>
        /// Returns the maximum amount of water a container can store.
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        /// https://leetcode.com/problems/container-with-most-water
        public static int MaxArea(int[] height)
        {
            var maxArea = 0;
            var (lPtr, rPtr) = (0, height.Length - 1);

            while (lPtr < rPtr)
            {
                var area = Math.Min(height[lPtr], height[rPtr]) * (rPtr - lPtr);
                if (area > maxArea)
                {
                    maxArea = area;
                }

                if (height[lPtr] <= height[rPtr])
                {
                    lPtr++;
                }
                else
                {
                    rPtr--;
                }
            }

            return maxArea;
        }
    }
}
