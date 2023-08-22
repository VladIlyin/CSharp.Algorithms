namespace CSharp.Algorithms.Problems.Others.FisherYatesShuffle;

public static class FisherYatesShuffle
{
    public static IEnumerable<T> Shuffle<T>(List<T> list)
    {
        var rand = new Random();

        for (var i = list.Count - 1; i > 0; i--)
        {
            var k = rand.Next(i + 1);
            var value = list[k];
            list[k] = list[i];
            list[i] = value;
        }

        return list;
    }
}