using CSharp.Algorithms.Core.Models;
using CSharp.Algorithms.Problems.DataStructures.Heap;
using CSharp.Algorithms.Problems.DataStructures.Tree;

namespace CSharp.Algorithms.UnitTests.DataStructures
{
    public class BinaryHeapTest
    {
        [Fact]
        public void BuildMaxHeapTest()
        {
            var heap = new BinaryHeap();

            heap.BuildMaxHeap(new int[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 });

            Assert.Equal(new List<int> { 16, 14, 10, 8, 7, 9, 3, 2, 4, 1 }, heap.Heap);
        }

        [Fact]
        public void ExtractMaxTest()
        {
            var heap = new BinaryHeap();

            heap.BuildMaxHeap(new int[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 });

            Assert.Equal(16, heap.ExtractMax());
            Assert.Equal(new List<int> { 14, 8, 10, 4, 7, 9, 3, 2, 1 }, heap.Heap);
        }

        [Fact]
        public void InsertMaxHeapTest()
        {
            var heap = new BinaryHeap();

            heap.BuildMaxHeap(new int[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 });
            heap.InsertMaxHeap(20);

            Assert.Equal(new List<int> { 20, 16, 10, 8, 14, 9, 3, 2, 4, 1, 7 }, heap.Heap);
        }
    }
}
