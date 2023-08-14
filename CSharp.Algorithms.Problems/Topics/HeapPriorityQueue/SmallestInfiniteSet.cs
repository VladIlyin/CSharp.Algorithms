namespace CSharp.Algorithms.Problems.Topics.HeapPriorityQueue
{
    public partial class HeapPriorityQueueProblem
    {
        public class SmallestInfiniteSet
        {
            private readonly PriorityQueue<int, int> _minHeap;
            private readonly HashSet<int> _popped;

            private int _smallest = 1;

            public SmallestInfiniteSet()
            {
                _minHeap = new();
                _minHeap.Enqueue(int.MaxValue, int.MaxValue);
                _popped = new();
            }

            public int PopSmallest()
            {
                if (_smallest < _minHeap.Peek())
                {
                    var n = _smallest;
                    _popped.Add(n);
                    _smallest++;
                    return n;
                }

                _popped.Add(_minHeap.Peek());
                return _minHeap.Dequeue();
            }

            public void AddBack(int num)
            {
                if (_popped.Contains(num))
                {
                    _minHeap.Enqueue(num, num);
                    _popped.Remove(num);
                }
            }
        }
    }
}