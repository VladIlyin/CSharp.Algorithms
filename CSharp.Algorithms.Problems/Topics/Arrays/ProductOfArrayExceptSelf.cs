namespace CSharp.Algorithms.Problems.Topics.Arrays
{
    public partial class Arrays
    {
        /// <summary>
        /// Return an array answer such that answer[i] is equal
        /// to the product of all the elements of nums except nums[i]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// https://leetcode.com/problems/product-of-array-except-self
        public static int[] ProductExceptSelf(int[] nums)
        {
            var zeroCount = 0;
            var productAggregate = nums.Aggregate((x, y) =>
            {
                if (x == 0)
                {
                    zeroCount++;
                    return y;
                }

                if (y == 0)
                {
                    zeroCount++;
                    return x;
                }

                if (zeroCount > 1)
                {
                    return 0;
                }

                return x * y;
            });

            var res = new int[nums.Length];

            switch (zeroCount)
            {
                case 0:
                {
                    for (var i = 0; i < res.Length; i++)
                    {
                        res[i] = (int)(productAggregate * Math.Pow(nums[i], -1));
                    }

                    break;
                }
                case 1:
                {
                    for (var i = 0; i < res.Length; i++)
                    {
                        res[i] = nums[i] == 0 ? productAggregate : 0;
                    }

                    break;
                }
            }

            return res;
        }
    }
}
