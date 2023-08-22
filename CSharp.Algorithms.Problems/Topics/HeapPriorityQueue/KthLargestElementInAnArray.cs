namespace CSharp.Algorithms.Problems.Topics.HeapPriorityQueue
{
    public partial class HeapPriorityQueueProblem
    {
        public int FindKthLargest(int[] nums, int k)
        {
            var queue = new PriorityQueue<int, int>();

            foreach (var n in nums)
            {
                queue.Enqueue(n, n);
                if (queue.Count > k)
                {
                    queue.Dequeue();
                }
            }

            return queue.Peek();
        }
        
        // Quickselect approach
        public int FindKthLargestQS(int[] nums, int k)
        {
            return QuickSelect(new List<int>(nums), k);

            static int QuickSelect(List<int> nums, int k)
            {
                var pivotIndex = new Random().Next(nums.Count);
                var pivot = nums[pivotIndex];

                var left = new List<int>();
                var mid = new List<int>();
                var right = new List<int>();

                foreach (var num in nums)
                {
                    if (num > pivot)
                    {
                        left.Add(num);
                    }
                    else if (num < pivot)
                    {
                        right.Add(num);
                    }
                    else
                    {
                        mid.Add(num);
                    }
                }

                if (k <= left.Count)
                {
                    return QuickSelect(left, k);
                }

                if (left.Count + mid.Count < k)
                {
                    return QuickSelect(right, k - left.Count - mid.Count);
                }

                return pivot;
            }
        }
    }
}
