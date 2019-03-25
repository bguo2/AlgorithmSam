using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class Dynamic
    {
        //Find the contiguous subarray within an array (containing at least one number) which has the largest sum.
        //For example, given the array [−2,1,−3,4,−1,2,1,−5,4], the contiguous subarray [4,−1,2,1] has the largest sum = 6.
        public static int LargestSum(int[] input)
        {
            //We should ignore the sum of the previous n-1 elements if nth element is greater than the sum.
            int max = input[0];
            int sum = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                sum = Math.Max(input[i], sum + input[i]);
                max = Math.Max(max, sum);
            }

            return max;
        }

        //Find the contiguous subarray within an array (containing at least one number) which has the largest product.
        public static int LargestProduct(int[] input)
        {
            if (input == null || input.Length == 0)
                return 0;
            int maxLocal = input[0];
            int minLocal = input[0];
            int global = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                int tmp = maxLocal;
                maxLocal = Math.Max(Math.Max(input[i] * maxLocal, input[i]), input[i] * minLocal);
                minLocal = Math.Min(Math.Min(input[i] * tmp, input[i]), input[i] * minLocal);
                global = Math.Max(maxLocal, global);
            }

            return global;
        }

        //buy and sell stock only once a day, max profit
        public static int LargestProfit1(int[] prices)
        {
            int maxProfit = 0;
            int minElement = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                minElement = Math.Min(minElement, prices[i]);
                maxProfit = Math.Max(maxProfit, prices[i] - minElement);
            }

            return maxProfit;
        }

        //Say you have an array for which the ith element is the price of a given stock on day i.
        //Design an algorithm to find the maximum profit. You may complete at most two transactions
        //A transaction is a buy & a sell. You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
        public static int LargestProfit(int[] prices)
        {
            //the max profit before i + max profit after i
            //highest profit in 0 ... i
            int[] left = new int[prices.Length];
            int[] right = new int[prices.Length];

            // DP from left to right
            left[0] = 0;
            int min = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                min = Math.Min(min, prices[i]);
                left[i] = Math.Max(left[i - 1], prices[i] - min);
            }

            //DP from right to left
            right[prices.Length-1] = 0;
            int max = prices[prices.Length - 1];
            for (int i = prices.Length - 2; i > -1; i--)
            {
                max = Math.Max(max, prices[i]);
                right[i] = Math.Max(right[i+1], max - right[i]);
            }

            int profit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                profit = Math.Max(profit, left[i] + right[i]);
            }

            return profit;
        }

        public static void Test()
        {
            int[] test = new int[] {-2, 1, 5, -6, 5};

            var max = LargestSum(test);
            Console.WriteLine("Largest sum is {0}", max);

            max = LargestProduct(test);
        }
    }
}
