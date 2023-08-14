namespace CSharp.Algorithms.Problems.Topics.Techniques.SlidingWindow;

public partial class SlidingWindow
{
    private const int MaxCharArrValue = 127;

    public static bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length)
        {
            return false;
        }

        char[] s1Arr = new char[MaxCharArrValue],
            s2Arr = new char[MaxCharArrValue];

        foreach (var t in s1)
        {
            s1Arr[t]++;
        }

        int left = 0, right = s1.Length;

        while (right <= s2.Length)
        {
            for (var i = left; i < right; i++)
            {
                s2Arr[s2[i]]++;
            }

            if (CompareChars(s1Arr, s2Arr))
            {
                return true;
            }

            Array.Clear(s2Arr, 0, s2Arr.Length);
            left++;
            right++;
        }

        return false;
    }

    static bool CompareChars(char[] arr1, char[] arr2)
    {
        return !arr2.Where((t, i) => arr1[i] != t).Any();
    }
}