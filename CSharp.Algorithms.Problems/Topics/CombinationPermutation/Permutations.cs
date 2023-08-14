namespace CSharp.Algorithms.Problems.Topics.CombinationPermutation;

public partial class Combinatorics
{
    public static IList<IList<int>> Permute(int[] nums)
    {
        var res = new List<IList<int>>();

        PermuteInternal(
            nums,
            new Stack<int>(),
            res,
            new bool[nums.Length]);

        return res;
    }

    static void PermuteInternal(
        int[] nums,
        Stack<int> queue,
        List<IList<int>> res,
        bool[] used)
    {
        if (queue.Count == nums.Length)
        {
            res.Add(queue.ToList());
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (!used[i])
            {
                used[i] = true;
                queue.Push(nums[i]);
                PermuteInternal(nums, queue, res, used);
                used[i] = false;
                queue.Pop();
            }
        }
    }

    public static List<string> SinglePermutations(string s)
    {
        if (s.Length == 1)
        {
            return new List<string>() { s };
        }

        var res = new List<string>();

        for (int i = 0; i < s.Length; i++)
        {
            res.AddRange(SinglePermutations(
                    s.Remove(i, 1))
                .Select(y => {
                    var res = s[i] + y;
                    return res;
                }).ToList());
        }

        return res.Distinct().ToList();
    }

    public static List<string> SinglePermutationsCodeWarsBest(string s) => $"{s}".Length < 2 ?
        new List<string> { s } :
        SinglePermutations(s.Substring(1))
            .SelectMany(x => Enumerable.Range(0, x.Length + 1)
                .Select((_, i) => x.Substring(0, i) + s[0] + x.Substring(i)))
            .Distinct()
            .ToList();

}