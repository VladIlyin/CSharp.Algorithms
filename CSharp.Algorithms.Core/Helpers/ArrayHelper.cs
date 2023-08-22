namespace CSharp.Algorithms.Core.Helpers;

public static class ArrayHelper
{
    /// <summary>
    /// The method takes two integer parameters, idxFrom and idxTo,
    /// and swaps the elements at these positions within the array.
    /// If the elements at the given positions are equal,
    /// the method returns without making any changes. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arr"></param>
    /// <param name="idxFrom"></param>
    /// <param name="idxTo"></param>
    public static void Swap<T>(this T[] arr, int idxFrom, int idxTo)
    {
        if (arr[idxFrom].Equals(arr[idxTo]))
        {
            return;
        }

        (arr[idxFrom], arr[idxTo]) = (arr[idxTo], arr[idxFrom]);
    }

    /// <summary>
    /// The method is used to move an element from the insertFrom position
    /// to the insertAt position in the array, shifting the elements
    /// in-between one position to the right.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arr"></param>
    /// <param name="insertAt"></param>
    /// <param name="insertFrom"></param>
    public static void Insert<T>(this T[] arr, int insertAt, int insertFrom)
    {
        var temp = arr[insertAt];

        arr[insertAt] = arr[insertFrom];

        for (var i = insertFrom; i > insertAt + 1; i--)
        {
            arr[i] = arr[i - 1];
        }

        arr[insertAt + 1] = temp;
    }

    /// <summary>
    /// Implementation of the merge step in the Merge Sort algorithm.
    /// It takes two sorted arrays, left and right,
    /// and merges them into a single sorted array.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arr"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    public static void Merge<T>(this T[] arr, T[] left, T[] right)
    {
        Comparer<T> comparer = Comparer<T>.Default;
        var count = left.Length + right.Length;
        int indexMerged = 0, indexLeft = 0, indexRight = 0;

        while (count > 0)
        {
            if (indexRight >= right.Length)
            {
                arr[indexMerged] = left[indexLeft++];
            }
            else if (indexLeft >= left.Length)
            {
                arr[indexMerged] = right[indexRight++];
            }
            else if (comparer.Compare(left[indexLeft], right[indexRight]) == 1)
            {
                arr[indexMerged] = right[indexRight++];
            }
            else
            {
                arr[indexMerged] = left[indexLeft++];
            }

            indexMerged++;
            count--;
        }
    }
}