using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public static class FindReaptedNumber
    {
        //You are given an array of n+2 elements. All elements of the array are in range 1 to n. 
        //And all elements occur once except two numbers which occur twice. Find the two repeating numbers.
        public static void FindRepeatedNumber(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = -arr[i];
                if(arr[i] > 0)
                    Console.WriteLine("{0} ", arr[i]);
            }
        }

        //All numbers occur even number of times except one number which occurs odd number of times. 
        //Find the number in O(n) time & constant space
        public static void FindRepeatedNumber1(int[] arr)
        {
            int r = 0;
            foreach (var e in arr)
                r = r ^ e;
            Console.WriteLine("{0}", r);
        }
    }
}
