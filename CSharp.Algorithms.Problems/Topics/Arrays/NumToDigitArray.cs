namespace CSharp.Algorithms.Problems.Topics.Arrays;

public static class NumToDigitArray
{
    public static IEnumerable<int> NumToArrayOfDigit(long n)
    {
        double current = n;
        int intPart;
        do
        {
            current /= 10d;
            intPart = (int)Math.Floor(current);
            yield return (int)Math.Floor(current % 1 * 10);
        } while (intPart != 0);
    }

    public static long ArrayOfDigitToNum(long[] arr)
    {
        return (int)arr
            .Select((num, idx) => num * Math.Pow(10, arr.Length - idx - 1))
            .Sum();
    }
}