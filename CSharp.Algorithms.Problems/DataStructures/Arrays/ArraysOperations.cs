using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Algorithms.Problems.DataStructures.Arrays;

public class ArrayOperations
{
    public static int BinarySearch(int[] nums, int target)
    {
        var low = 0;
        var high = nums.Length - 1;

        while (low <= high)
        {
            var mid = low + (high - low) / 2;

            if (nums[mid] > target)
            {
                high = mid - 1;
            }
            else if (nums[mid] < target)
            {
                low = mid + 1;
            }
            else
            {
                return mid;
            }
        }

        return -1;
    }
    
    public static int BinarySearchLowerBound(int[] nums, int target)
    {
        var low = 0;
        var high = nums.Length;

        while (low < high)
        {
            var mid = low + (high - low) / 2;
            if (nums[mid] < target)
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }

        return low;
    }

    public static IEnumerable<int> Intersect(int[] first, int[] second)
    {
        Dictionary<int, int> dict = new();

        foreach (var n in first)
        {
            if (!dict.TryAdd(n , 1))
            {
                dict[n]++;
            }
        }

        foreach (var n in second)
        {
            if (dict.TryGetValue(n, out var val) && val > 0)
            {
                dict[n]--;
                yield return n;
            }
        }
    }
}