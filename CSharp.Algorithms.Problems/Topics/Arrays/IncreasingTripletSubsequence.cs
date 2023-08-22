namespace CSharp.Algorithms.Problems.Topics.Arrays
{
    public partial class ArraysProblem
    {
        public bool IncreasingTriplet(int[] nums)
        {
            var (bucket1, bucket2) = (int.MaxValue, int.MaxValue);

            foreach (var n in nums)
            {
                if (n == bucket1 || n == bucket2) continue;

                if (n < bucket1)
                {
                    bucket1 = n;
                }
                else if (n < bucket2)
                {
                    bucket2 = n;
                }
                else if (n > bucket2)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
