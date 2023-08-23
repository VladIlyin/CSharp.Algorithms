namespace CSharp.Algorithms.Problems.Topics.Arrays;

public partial class ArraysProblem
{
    // https://blog.devgenius.io/leetcode-88-merge-sorted-array-get-solution-with-images-a6a40539c50
    public static void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        var i = m - 1;
        var j = n - 1;
        var k = m + n - 1;

        while (k >= 0)
        {
            if (i >= 0 && j >= 0)
            {
                if (nums1[i] >= nums2[j])
                {
                    nums1[k--] = nums1[i--];
                }
                else
                {
                    nums1[k--] = nums2[j--];
                }
            }
            else if (j >= 0)
            {
                nums1[k--] = nums2[j--];
            }
            else
            {
                break;
            }
        }
    }
}