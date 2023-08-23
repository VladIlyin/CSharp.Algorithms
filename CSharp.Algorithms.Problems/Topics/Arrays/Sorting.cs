using CSharp.Algorithms.Core.Helpers;
using Array = System.Array;

namespace CSharp.Algorithms.Problems.Topics.Arrays;

public partial class ArraysProblem
{
    /// <summary>
    /// Bubble sort.
    /// </summary>
    /// <param name="arr"></param>
    public static void BubbleSort(int[] arr)
    {
        var allSorted = false;

        while (!allSorted)
        {
            allSorted = true;
            for (var i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    arr.Swap(i, i + 1);
                    allSorted = false;
                }
            }
        }
    }

    /// <summary>
    /// Insertion sort.
    /// </summary>
    /// <param name="arr"></param>
    public static void InsertionSort(int[] arr)
    {
        var sortIndex = 1;

        while (sortIndex < arr.Length)
        {
            if (arr[sortIndex] < arr[sortIndex - 1])
            {
                var index = FindInsertionIndex(arr, arr[sortIndex]);
                arr.Insert(index, sortIndex);
            }

            sortIndex++;
        }

        int FindInsertionIndex<T>(T[] arr, T value)
        {
            var comparer = Comparer<T>.Default;

            for (var i = 0; i < arr.Length; i++)
            {
                if (comparer.Compare(arr[i], value) == 1)
                {
                    return i;
                }
            }

            return -1;
        }
    }

    /// <summary>
    /// Merge sort.
    /// </summary>
    /// <param name="arr"></param>
    public static void MergeSort(int[] arr)
    {
        if (arr.Length <= 1)
        {
            return;
        }

        var leftSize = arr.Length / 2;
        var rightSize = arr.Length - leftSize;
        var left = new int[leftSize];
        var right = new int[rightSize];

        Array.Copy(arr, 0, left, 0, leftSize);
        Array.Copy(arr, leftSize, right, 0, rightSize);

        MergeSort(left);
        MergeSort(right);
        arr.Merge(left, right);
    }

    /// <summary>
    /// Quick sort.
    /// </summary>
    /// <param name="arr"></param>
    public static void QuickSort(int[] arr)
    {
        Sort(arr, 0, arr.Length - 1);

        void Sort(int[] arr, int left, int right)
        {
            //if left = right (array with one element), then skip sorting
            if (left == right) return;

            var partitionIndex = ArrayPartition(arr, left, right);
            Sort(arr, left, partitionIndex);
            Sort(arr, partitionIndex + 1, right);
        }

        int ArrayPartition(int[] arr, int left, int right)
        {
            // pivot can be first element in the array,
            // but to make it work we need to change this method a bit
            var pivot = arr[(left + right) / 2];

            while (true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                // >= because j can be in the same position as i or it can be after i
                // For example, while first partitioning:
                // 2,9,1,5,4,6 - after (return j=0, j will be decremented in the last while cycle)
                // 2,0,1,5,4,6 - same position (return j=1)
                if (left >= right)
                {
                    return right;
                }

                arr.Swap(left, right);

                // if we use do...while, then we don't need these lines
                // also don't forget to decrement/increment left and right before while(true) cycle
                left++;
                right--;
            }
        }
    }

    /// <summary>
    /// Selection sort.
    /// </summary>
    /// <param name="arr"></param>
    public static void SelectionSort(int[] arr)
    {
        var sortIndex = 0;

        while (sortIndex < arr.Length)
        {
            var index = FindSmallestIndex(arr, sortIndex);
            arr.Swap(sortIndex, index);

            sortIndex++;
        }

        int FindSmallestIndex(int[] arr, int fromIndex)
        {
            var currentValue = arr[fromIndex];
            var currentIndex = fromIndex;

            for (var i = fromIndex + 1; i < arr.Length; i++)
            {
                if (currentValue <= arr[i]) continue;
                currentValue = arr[i];
                currentIndex = i;
            }

            return currentIndex;
        }
    }
}