namespace CSharp.Algorithms.Problems.Topics.Arrays;

public partial class ArraysProblem
{
    public IEnumerable<int> Intersect(int[] first, int[] second)
    {
        Dictionary<int, int> dict = new();

        foreach (var n in first)
        {
            if (!dict.TryAdd(n, 1))
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