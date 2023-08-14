namespace CSharp.Algorithms.Problems.Topics.CombinationPermutation;

public partial class Combinatorics
{
    public static IList<IList<int>> Combine(int n, int k)
    {
        // A temporary array to store
        // all combination one by one
        int[] data = new int[k];

        var arr = Enumerable.Range(1, n).ToArray();
        var res = new List<IList<int>>();

        // Print all combination
        // using temporary array 'data[]'
        CombinationInternal(arr, n, k, 0, data, 0, res);

        return res;
    }

    static void CombinationInternal(int[] arr, int n,
        int r, int index,
        int[] data, int i, List<IList<int>> res)
    {
        // Current combination is ready
        // to be printed, print it
        if (index == r)
        {
            List<int> list = new List<int>();
            for (int j = 0; j < r; j++)
                list.Add(data[j]);

            res.Add(list);
            return;
        }

        // When no more elements are
        // there to put in data[]
        if (i >= n)
            return;

        // current is included, put
        // next at next location
        data[index] = arr[i];
        CombinationInternal(arr, n, r,
            index + 1, data, i + 1, res);

        // current is excluded, replace
        // it with next (Note that
        // i+1 is passed, but index
        // is not changed)
        CombinationInternal(arr, n, r, index,
            data, i + 1, res);
    }
}