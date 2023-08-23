namespace CSharp.Algorithms.Problems.Topics.Arrays;

public partial class ArraysProblem
{
    public static int MaxProfit(int[] prices)
    {
        if (prices.Length == 0) return 0;

        var maxProfit = 0;
        var currentMin = prices[0];

        for (var i = 1; i < prices.Length; i++)
        {
            if (prices[i] < prices[i - 1])
            {
                if (prices[i] < currentMin)
                {
                    currentMin = prices[i];
                }
            }
            else
            {
                maxProfit = Math.Max(maxProfit, prices[i] - currentMin);
            }
        }

        return maxProfit;
    }
}