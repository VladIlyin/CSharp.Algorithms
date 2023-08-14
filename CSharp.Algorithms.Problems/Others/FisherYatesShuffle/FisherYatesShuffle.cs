namespace CSharp.Algorithms.Problems.Others.FisherYatesShuffle;

public static class FisherYatesShuffle
{
    public static IEnumerable<T> Shuffle<T>(List<T> list)
    {
        Random rand = new Random();

        for (int i = list.Count - 1; i > 0; i--)
        {
            int k = rand.Next(i + 1);
            T value = list[k];
            list[k] = list[i];
            list[i] = value;
        }

        return list;
    }
}