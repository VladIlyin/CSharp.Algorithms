using System.Text;

namespace CSharp.Algorithms.Core;

public static class GenerateTestData
{
    public static int[] GenerateArrayOfInteger(int length, int minValue = 0, int maxValue = Int32.MaxValue)
    {
        Random rand = new Random();
        int[] arr = new int[length];
        for (int i = 0; i < length; i++)
        {
            arr[i] = rand.Next(minValue, maxValue);
        }

        return arr;
    }

    public static int[] GenerateUniqueArrayOfInteger(int length, int minValue = 0, int maxValue = Int32.MaxValue)
    {
        if (length > maxValue - minValue)
        {
            throw new ArgumentException();
        }

        Random rand = new Random();
        HashSet<int> hashSet = new HashSet<int>();
        int currValue = 0;

        while (hashSet.Count < length)
        {
            currValue = rand.Next(minValue, maxValue);
            if (!hashSet.Contains(currValue))
            {
                hashSet.Add(currValue);
            }
        }

        return hashSet.ToArray();
    }

    public static string GetRandomString(int length = 7)
    {
        StringBuilder stringBuilder = new StringBuilder();
        Random random = new Random();

        for (int i = 0; i < length; i++)
        {
            var rnd = random.NextDouble();
            var shift = Convert.ToInt32(Math.Floor(25 * rnd));
            var letter = Convert.ToChar(shift + 65);
            stringBuilder.Append(letter);
        }
            
        return stringBuilder.ToString();
    }

    public static IEnumerable<string> GetRandomStrings(int length = 7, int count = 10)
    {
        HashSet<string> hashSet = new HashSet<string>();
        string str;

        for (int i = 0; i < count; i++)
        {
            str = GetRandomString(length);
                
            while(hashSet.Contains(str))
                str = GetRandomString();

            yield return str;
        }
    }
}