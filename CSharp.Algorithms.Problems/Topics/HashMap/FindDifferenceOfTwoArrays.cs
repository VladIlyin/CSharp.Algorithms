using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Algorithms.Problems.Topics.HashMap
{
    public partial class HashMapProblem
    {
        public static IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            var (hs1, hs2) = (nums1.ToHashSet(), nums2.ToHashSet());

            hs1.ExceptWith(nums2);
            hs2.ExceptWith(nums1);

            return new List<IList<int>>()
            {
                hs1.ToArray(),
                hs2.ToArray()
            };
        }
    }
}
