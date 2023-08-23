namespace CSharp.Algorithms.Problems.Topics.Heap
{
    public class BinaryHeap
    {
        private List<int> _arr = new();

        public IEnumerable<int> Heap => _arr;

        void HeapifyMax(int idx)
        {
            var left = Left(idx);
            var right = Right(idx);
            int largest;

            if (left <= _arr.Count && _arr[left - 1] > _arr[idx - 1])
            {
                largest = left;
            }
            else
            {
                largest = idx;
            }

            if (right <= _arr.Count && _arr[right - 1] > _arr[largest - 1])
            {
                largest = right;
            }

            if (largest != idx)
            {
                (_arr[idx - 1], _arr[largest - 1]) = (_arr[largest - 1], _arr[idx - 1]);
                HeapifyMax(largest);
            }
        }

        public void BuildMaxHeap(int[] arr)
        {
            _arr = new List<int>(arr);
            for (var i = _arr.Count / 2; i > 0; i--)
            {
                HeapifyMax(i);
            }
        }

        public int ExtractMax()
        {
            if (_arr.Count == 0) throw new ArgumentException("Heap underflow");

            var max = _arr[0];
            _arr[0] = _arr[^1];
            _arr.RemoveAt(_arr.Count - 1);

            HeapifyMax(1);

            return max;
        }

        public void InsertMaxHeap(int value)
        {
            _arr.Add(value);

            var i = _arr.Count;

            while (i > 1 && _arr[Parent(i) - 1] < _arr[i - 1])
            {
                (_arr[i - 1], _arr[Parent(i) - 1]) = (_arr[Parent(i) - 1], _arr[i - 1]);
                i = Parent(i);
            }
        }

        private int Left(int i) => 2 * i;
        private int Right(int i) => 2 * i + 1;
        private int Parent(int i) => i / 2;
    }
}
