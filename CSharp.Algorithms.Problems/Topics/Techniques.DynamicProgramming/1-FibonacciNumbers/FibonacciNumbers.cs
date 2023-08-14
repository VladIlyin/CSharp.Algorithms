using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Algorithms.Problems.Topics.Techniques.DynamicProgramming._1_FibonacciNumbers;

// https://leetcode.com/problems/fibonacci-number/
// https://www.youtube.com/watch?v=mBNrRy2_hVs
public partial class DynamicProgrammingTechnique
{
    public static int FibonacciNumber(int n)
    {
        return n switch
        {
            0 => 0,
            1 => 1,
            _ => FibonacciNumber(n - 1) + FibonacciNumber(n - 2)
        };
    }

    public static int FibonacciNumberIterative(int n)
    {
        switch (n)
        {
            case < 0:
                throw new ArgumentOutOfRangeException(nameof(n));
            case < 2:
                return n;
            case < 5:
                return n - 1;
        }

        var (res, prev) = (1, 0);

        for (var i = 0; i < n - 1; i++)
        {
            var temp = res;
            (res, prev) = (res + prev, temp);
        }

        return res;
    }
}