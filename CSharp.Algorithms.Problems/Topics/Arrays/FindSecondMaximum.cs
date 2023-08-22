namespace CSharp.Algorithms.Problems.Topics.Arrays;

public partial class ArraysProblem
{
    // https://youtu.be/SKwB41FrGgU?list=PL6Wui14DvQPySdPv5NUqV3i8sDbHkCKC5&t=1241
    public int SecondMax(int[] arr)
    {
        switch (arr.Length)
        {
            case < 2:
                throw new ArgumentException("Length of the array must be greater then 1");
            case 2:
                return Math.Min(arr[0], arr[1]);
        }

        var (max1, max2) = (Math.Max(arr[0], arr[1]), Math.Min(arr[0], arr[1]));

        for (var i = 2; i < arr.Length; i++)
        {
            if (arr[i] > max1)
            {
                max2 = max1;
                max1 = arr[i];
            }
            else if (arr[i] > max2)
            {
                max2 = arr[i];
            }
        }
        
        return max2;
    }
}