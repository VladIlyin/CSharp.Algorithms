namespace CSharp.Algorithms.Problems.Topics.Techniques.DynamicProgramming._3_UnboundedKnapsack;

//https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/Greedy_algorithm_36_cents.svg/1200px-Greedy_algorithm_36_cents.svg.png
public partial class DynamicProgrammingTechnique
{
    public class ImplementationWithArray
    {
        public static int GetMinimumCoins(int[] coins, int amount)
        {
            var dp = new long[amount + 1];
            for (int i = 0; i <= amount; i++)
            {
                dp[i] = int.MaxValue;
            }

            dp[0] = 0;

            for (int i = 1; i <= amount; i++)
            {
                foreach (var coin in coins)
                {
                    if (coin <= i)
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                    }
                }
            }

            return dp[amount] > amount ? -1 : (int)dp[amount];
        }
    }

    //https://en.wikipedia.org/wiki/Change-making_problem
    public class ImplementationWithMatrix
    {
        public static int GetMinimumCoins(int[] coins, int amount)
        {
            // Initialize matrix to store minimum number of coins required for each amount
            var matrix = InitializeMatrix(coins, amount);

            // Iterate through each coin and each amount to fill the matrix
            for (int coinIndex = 1; coinIndex <= coins.Length; coinIndex++)
            {
                int coin = coins[coinIndex - 1];
                for (var currentAmount = 1; currentAmount < amount + 1; currentAmount++)
                {
                    if (coin < currentAmount)
                    {
                        matrix[coinIndex][currentAmount] = Math.Min(matrix[coinIndex - 1][currentAmount], 1 + matrix[coinIndex][currentAmount - coin]);
                    }
                    else if (coin > currentAmount)
                    {
                        matrix[coinIndex][currentAmount] = matrix[coinIndex - 1][currentAmount];
                    }
                    else
                    {
                        matrix[coinIndex][currentAmount] = 1;
                    }
                }
            }

            return float.IsInfinity(matrix[^1][^1]) ? -1 : (int)matrix[^1][^1];
        }

        /// <summary>
        /// Initializes the matrix to store minimum number of coins required for each amount.
        /// </summary>
        /// <param name="coins">Array of available coins.</param>
        /// <param name="amount">Amount to be made up using coins.</param>
        /// <returns>Initialized matrix.</returns>
        private static float[][] InitializeMatrix(int[] coins, int amount)
        {
            float[][] matrix = new float[coins.Length + 1][];
            for (int i = 0; i < coins.Length + 1; i++)
            {
                matrix[i] = new float[amount + 1];
            }

            // Set first row of matrix to positive infinity
            for (int i = 0; i < amount + 1; i++)
            {
                matrix[0][i] = float.PositiveInfinity;
            }

            return matrix;
        }
    }
}