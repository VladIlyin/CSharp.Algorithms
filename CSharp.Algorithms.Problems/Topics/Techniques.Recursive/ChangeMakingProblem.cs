namespace CSharp.Algorithms.Problems.Topics.Techniques.Recursive;

public class ChangeMakingProblem
{
    /// <summary>
    /// Returns the minimum number of coins required to make up a given amount.
    /// </summary>
    /// <param name="coinDenominations">Array of coin denominations.</param>
    /// <param name="amount">Amount to be made up using coins.</param>
    /// <returns>Minimum number of coins required to make up amount. Returns -1 if amount cannot be made up using given coins.</returns>
    public static int GetMinimumCoins(int[] coinDenominations, int amount)
    {
        // Call internal recursive function to get minimum coins required
        var minCoins = GetMinimumCoinsInternal(coinDenominations, coinDenominations.Length, amount);

        // If minimum coins is equal to int.MaxValue, amount cannot be made up using given coins
        if (minCoins == int.MaxValue)
        {
            return -1;
        }

        return minCoins;

        int GetMinimumCoinsInternal(IReadOnlyList<int> denominations, int numDenominations, int remainingAmount)
        {
            // Base case: If remaining amount is 0, no more coins are required
            if (remainingAmount == 0)
            {
                return 0;
            }

            // Initialize minimum coins required to int.MaxValue
            var minCoinsRequired = int.MaxValue;

            // Iterate through all coin denominations
            for (var i = 0; i < numDenominations; i++)
            {
                if (denominations[i] <= remainingAmount)
                {
                    // Recursively call function with remaining amount reduced by current coin denomination
                    var currentMinCoins = GetMinimumCoinsInternal(denominations, numDenominations,
                        remainingAmount - denominations[i]);


                    /*
                        Check if any combinations exist with the current denomination
                        and the length of the combination is less than the minimum coins required
                    */
                    if (currentMinCoins != int.MaxValue && currentMinCoins + 1 < minCoinsRequired)
                    {
                        // Update minimum coins required with the new minimum
                        minCoinsRequired = currentMinCoins + 1;
                    }
                }
            }

            return minCoinsRequired;
        }
    }
}