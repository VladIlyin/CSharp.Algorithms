namespace CSharp.Algorithms.Problems.Topics.Techniques.Greedy;

public class ChangeMakingProblem
{
    public static int GetMinimumCoins(int[] coins, int amount)
    {
        Array.Sort(coins);
        var numCoins = 0;

        for (var i = coins.Length - 1; i >= 0; i--)
        {
            //take as much from coins[i]
            while (amount >= coins[i])
            {
                //after taking the coin, reduce the value.
                amount -= coins[i];
                //ans[numCoins] = coins[i];
                numCoins++;
            }

            if (amount == 0)
                break;

            if (i == 0)
                return -1;
        }

        return numCoins;
    }

    /// <summary>
    /// Returns a coin set of minimum change for a given amount
    /// </summary>
    /// <param name="coins">An array of coin denominations</param>
    /// <param name="change">The amount of change to be made</param>
    /// <returns>A list of coins that make up the minimum change</returns>
    public static List<int> GetCoinSet(int[] coins, int change)
    {
        var coinSet = new List<int>();
        var remainingChange = change;

        // Loop through the coin denominations in descending order
        for (var i = coins.Length - 1; i >= 0; i--)
        {
            // Calculate the number of coins needed for this denomination
            var numCoins = remainingChange / coins[i];

            // Add the coins to the coin set
            for (var j = 0; j < numCoins; j++)
            {
                coinSet.Add(coins[i]);
            }

            // Update the remaining change
            remainingChange %= coins[i];
        }

        return coinSet;
    }
}