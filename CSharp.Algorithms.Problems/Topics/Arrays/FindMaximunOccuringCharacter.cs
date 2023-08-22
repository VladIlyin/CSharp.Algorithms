namespace CSharp.Algorithms.Problems.Topics.Arrays;

public partial class ArraysProblem
{
    // https://youtu.be/QLhqYNsPIVo?list=PL6Wui14DvQPySdPv5NUqV3i8sDbHkCKC5&t=926
    public char MostOccuringChar(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return new char();
        }

        var arr = new int[127];
        var res = str[0];
        var currMax = 0;

        foreach (var ch in str)
        {
            arr[ch]++;
            
            if (arr[ch] > currMax)
            {
                currMax = arr[ch];
                res = ch;
            }
        }

        return res;
    }
}