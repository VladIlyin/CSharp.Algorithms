namespace CSharp.Algorithms.Problems.Topics.HeapPriorityQueue
{
    public partial class HeapPriorityQueueProblem
    {
        class ScoreSort : IComparer<int[]>
        {
            public int Compare(int[]? x, int[]? y)
            {
                return y[1] > x[1] ? 1 : 0;
            }
        }

        public long MaxScore(int[] nums1, int[] nums2, int k)
        {
            // Sort pair (nums1[i], nums2[i]) by nums2[i] in decreasing order.
            var n = nums1.Length;
            var pairs = new int[n][];

            for (var i = 0; i < n; ++i)
            {
                pairs[i] = new int[] { nums1[i], nums2[i] };
            }
            //Arrays.sort(pairs, (a, b)->b[1] - a[1]);
            //Array.Sort(pairs, new ScoreSort());

            pairs = pairs.OrderBy(x => x, new ScoreSort()).ToArray();

            // Use a min-heap to maintain the top k elements.
            var topKHeap = new PriorityQueue<int, int>();
            long topKSum = 0;
            for (int i = 0; i < k; ++i)
            {
                topKSum += pairs[i][0];
                topKHeap.Enqueue(pairs[i][0], pairs[i][0]);
            }

            // The score of the first k pairs.
            long answer = topKSum * pairs[k - 1][1];

            // Iterate over every nums2[i] as minimum from nums2.
            for (int i = k; i < n; ++i)
            {
                // Remove the smallest integer from the previous top k elements
                // then add nums1[i] to the top k elements.
                topKSum += pairs[i][0] - topKHeap.Dequeue();
                topKHeap.Enqueue(pairs[i][0], pairs[i][0]);

                // Update answer as the maximum score.
                answer = Math.Max(answer, topKSum * pairs[i][1]);
            }

            return answer;
        }
    }
}
