﻿namespace CSharp.Algorithms.Problems.Topics.Arrays;

public partial class Arrays
{
    public static int MaxProfit(int[] prices)
    {
        if (prices.Length == 0) return 0;

        int maxProfit = 0;
        int currMin = prices[0];

        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] < prices[i - 1])
            {
                if (prices[i] < currMin)
                {
                    currMin = prices[i];
                }
            }
            else
            {
                maxProfit = Math.Max(maxProfit, prices[i] - currMin);
            }
        }

        return maxProfit;
    }

    // Approach:

    // Instead this:

    //  if (prices[i] - currMin > maxProfit)
    //  {
    //    maxProfit = prices[i] - currMin;
    //  }

    // write this

    // maxProfit = Math.Max(maxProfit, prices[i] - currMin);
}