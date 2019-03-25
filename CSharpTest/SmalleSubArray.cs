using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    //Smallest subarray with sum greater than a given value
    //Given an array of integers and a number x, find the smallest subarray with sum greater than the given value.
    /*Examples:
        arr[] = {1, 4, 45, 6, 0, 19}
           x  =  51
        Output: 3
        Minimum length subarray is {4, 45, 6}

        arr[] = {1, 10, 5, 2, 7}
           x  = 9
        Output: 1
        Minimum length subarray is {10}

        arr[] = {1, 11, 100, 1, 0, 200, 3, 2, 1, 250}
            x = 280
        Output: 4
        Minimum length subarray is {100, 1, 0, 200}
     */
    public static class SmalleSubArray
    {
        public static int SmallestSubWithSum(int[] arr, int x)
        {
            int n = arr.Length;
           // Initialize current sum and minimum length
            int curr_sum = 0, min_len = n+1;
 
            // Initialize starting and ending indexes
            int start = 0, end = 0;
            while (end < n)
            {
                // Keep adding array elements while current sum
                // is smaller than x
                while (curr_sum <= x && end < n)
                    curr_sum += arr[end++];
 
                // If current sum becomes greater than x.
                while (curr_sum > x && start < n)
                {
                    // Update minimum length if needed
                    if (end - start < min_len)
                        min_len = end - start;
 
                    // remove starting elements
                    curr_sum -= arr[start++];
                }
            }

            return min_len;
        }
    }
}
