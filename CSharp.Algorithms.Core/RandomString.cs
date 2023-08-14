using System.Text;

namespace CSharp.Algorithms.Core;

public class RandomString
{
    readonly HashSet<string> _set = new();

    public string GetRandomString(int length = 7)
    {
        StringBuilder stringBuilder = new StringBuilder();
        Random random = new Random();

        char letter;
        double rnd;
        int shift;

        for (int i = 0; i < length; i++)
        {
            rnd = random.NextDouble();
            shift = Convert.ToInt32(Math.Floor(25 * rnd));
            letter = Convert.ToChar(shift + 65);
            stringBuilder.Append(letter);
        }

        return stringBuilder.ToString();
    }

    public string GetUniqueRandomString(int length = 7)
    {
        string str;

        do
        {
            str = GetRandomString(length);
        }
        while (_set.Contains(str));                

        return str;
    }

    public IEnumerable<string> GetUniqueRandomStrings(int length = 7, int count = 10)
    {
        _set.Clear();
        string str;

        for (int i = 0; i < count; i++)
        {
            str = GetRandomString(length);

            while (_set.Contains(str))
                str = GetRandomString();

            yield return str;
        }
    }
}