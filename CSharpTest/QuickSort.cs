using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class QuickSort
    {
        public static int partition(int[] arr, int left, int right)
        {
              int i = left, j = right;
              int tmp;
              int pivot = arr[(left + right) / 2];
     
              while (i <= j) 
              {
                    while (arr[i] < pivot)
                          i++;
                    while (arr[j] > pivot)
                          j--;
                    if (i <= j) {
                          tmp = arr[i];
                          arr[i] = arr[j];
                          arr[j] = tmp;
                          i++;
                          j--;
                    }
              };
     
              return i;
        }

        static public void QuickSort_Recursive(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int index = partition(arr, left, right);
                QuickSort_Recursive(arr, left, index - 1);
                QuickSort_Recursive(arr, index, right);
            }
        }

        static public int GetKthLargest(int k, int[] nums, int start, int end)
        {
            int pivot = nums[end];

            int left = start;
            int right = end;

            while (true)
            {
                while (left < right && nums[left] < pivot)
                    left++;

                while (left < right && nums[right] >= pivot)
                    right--;

                if (left == right)
                {
                    swap(nums, left, end);
                    break;
                }

                swap(nums, left, right);
            }

            if (k == left + 1)
                return pivot;
            else if (k < left + 1)
                return GetKthLargest(k, nums, start, left - 1);
            else
                return GetKthLargest(k, nums, left + 1, end);
        }

        public static void swap(int[] nums, int n1, int n2)
        {
            int tmp = nums[n1];
            nums[n1] = nums[n2];
            nums[n2] = tmp;
        }

        public static void Test()
        {
            int[] numbers = { 9, 8, 10, 3, 5, 4, 3, 1, 9 };
            int len = numbers.Length;

            Console.WriteLine("QuickSort By Recursive Method");
            QuickSort_Recursive(numbers, 0, len - 1);
            for (int i = 0; i < len; i++)
                Console.WriteLine(numbers[i]);

            int[] num = { 9, 8, 10, 3, 5, 4, 3, 1, 9 };//{9, 8, 4, 10, 5, 4, 3, 9, 1};
            //K: 1~num.Length, descending, num.Length: the largest
            var result = GetKthLargest(num.Length, num, 0, num.Length - 1);
            Console.WriteLine();
        }
    }
}
