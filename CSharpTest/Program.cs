using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CSharpTest
{
    public class A
    {
    }

    class Program
    {
        public class Node<T>
        {
            public T data;
            public Node<T> next;
        }

        public static Node<T> NewNode<T> (T data1)
        {
            var tmp = new Node<T>
            {
                data = data1,
                next = null
            };
            return tmp;
        }

        public static Node<T> ReverseNode<T>(Node<T> head)
        {
            Node<T> pre = null, cur, next;
            cur = head;
            while (cur != null)
            {
                next = cur.next;
                cur.next = pre;
                pre = cur;
                cur = next;
            }

            return pre;
        }

        public static Node<T> RecurReverseNode<T>(Node<T> node)
        {
            if (node == null || node.next == null)
                return node;
            var tmp = RecurReverseNode(node.next);
            node.next.next = node;
            node.next = null;
            return tmp;
        }

        public static string RecursiveReverseString(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 1)
                return s;
            var ch = s[0];
            string result = RecursiveReverseString(s.Substring(1));
            result = result + ch;
            return result;
        }

        public static string ReverseString(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 1)
                return s;
            var ss = new System.Text.StringBuilder(s);
            int i = 0, j = ss.Length - 1;
            while (i < j)
            {
                var ch = ss[i];
                ss[i] = ss[j];
                ss[j] = ch;
                i++;
                j--;
            }
            return ss.ToString();
        }

        public static void ReverseCharArray(char[] arr, int start, int end)
        {
            if (arr == null || arr.Length < 2)
                return;
            int i = start, j = end;
            while (i < j)
            {
                var tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;
                i++;
                j--;
            }
        }

        public static void RecursiveReverse(char[] arr, int start, int end)
        {
            if (start >= end)
                return;
            var temp = arr[end];
            arr[end] = arr[start];
            arr[start] = temp;
            RecursiveReverse(arr, start + 1, end - 1);
        }

        public static string ReverseString1(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 2)
                return input;
            var tmp = input.ToCharArray();
            int end = input.Length - 1;
            if (tmp[end] == ' ' || tmp[end] == '.' || tmp[end] == ',' || tmp[end] == '?')
                end = input.Length - 2;
            ReverseCharArray(tmp, 0, end);
            int j = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (tmp[i] == ' ' || tmp[i] == ',' || tmp[i] == '.' || i == input.Length)
                {
                    ReverseCharArray(tmp, j, i-1);
                    j = i+1;
                }
            }

            return new string(tmp);
        }

        //0,1,1,2,3,5,8,13,21...
        public static void FibonacciSeries(uint n)
        {
            uint a0 = 0, a1 = 1, sum = 0;

            Console.WriteLine("{0}", a0);
            Console.WriteLine("{0}", a1);
            while (sum < n)
            {
                sum = a0 + a1;
                Console.WriteLine("{0}", sum);
                a0 = a1;
                a1 = sum;
            }
        }

        //recursively get the value by index.
        public static uint RecFibonacciSeries(uint index)
        {
            if(index == 0)
                return 0;
            if (index == 1)
                return 1;
            var sum = RecFibonacciSeries(index - 1) + RecFibonacciSeries(index - 2);
            return sum;
        }

        //insert * between each chars
        public static string RecInsertStarBetween(string source)
        {
            if (string.IsNullOrEmpty(source) || source.Length == 1)
                return source;
            var ch = source[0];
            var result = RecInsertStarBetween(source.Substring(1));
            result = ch + "*" + result;
            return result;
        }

        public static void BubbleSorting(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = arr.Length - 1; j > i; j--)
                {
                    if (arr[j] < arr[j-1])
                    {
                        var temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        public static void SelectionSort(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] < a[min])
                        min = j;
                }
                var temp = a[i];
                a[i] = a[min];
                a[min] = temp;
            }
        }

        public static void InsertionSort(int[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                int j = i;
                while (j > 0 && a[j] < a[j - 1])
                {
                    var temp = a[j];
                    a[j] = a[j - 1];
                    a[j - 1] = temp;
                    j--;
                }
            }
        }

        //find all pairs whose sum is the specific value
        //if no duplicates in the array, can use HashSet or Dictionary 
        //int[] A = { 9, 17, 1, -5, 6, 7, 9, 20, 25, 31, 45 };
        //{ 1, 8, -3, 0, 1, 3, -2, 4, 5 } 6
        //FindNumbers(A, 26);
        public static void FindNumbers(int[] numbers, int sum)
        {
            Dictionary<int, List<int>> match = new Dictionary<int, List<int>>();
            for (int i = 0; i < numbers.Length; i++)
            {
                int tmp = sum - numbers[i];
                if (match.ContainsKey(tmp))
                {
                    foreach (int e in match[tmp])
                    {
                        Console.WriteLine("{0},{1}", tmp, numbers[i]);
                        Console.WriteLine("index({0},{1})", e, i);
                    }
                }

                if(match.ContainsKey(numbers[i]))
                    match[numbers[i]].Add(i);
                else
                    match[numbers[i]] = new List<int> { i };
            }
        }

        //for sorted arrays
        public static void FindNumbers1(int[] a, int sum)
        {
            int i = 0, j = a.Length - 1;
            while (i < j)
            {
                int tempSum = a[i] + a[j];
                if (tempSum == sum)
                {
                    Console.WriteLine("{0}  {1}", a[i], a[j]);
                    if (a[j - 1] == a[j])
                        j--;
                    else
                        i++;
                }
                else if (tempSum < sum)
                    i++;
                else
                    j--;
            }
        }

        //String matching where one string contains wildcard characters
        //* --> Matches with 0 or more instances of any character or set of characters.
        //? --> Matches with any one character.
        //“g*ks” matches with “geeks”, “ge?ks*” matches with “geeksforgeeks” 
        public static bool StringMatch(string pattern, string source)
        {
            return StringMatch1(pattern, 0, source, 0);
        }

        private static bool StringMatch1(string pattern, int pIndex, string source, int sIndex)
        {
            var pLen = pattern.Length;
            var sLen = source.Length;
            //reached the last character
            if(pIndex == pLen && sIndex == sLen)
                return true;
            //reached the end of source
            if (sIndex == sLen && pIndex < pLen)
            {
                if (pIndex == pLen - 1 && pattern[pIndex] == '*')
                    return true;
                return false;
            }

            //reached the end of pattern
            if (pIndex == pLen && sIndex < sLen)
            {
                //the last of pattern is *, matched!
                if(pattern[pIndex-1] == '*')
                    return true;
                return false;
            }

            //reached the end of source
            if (pattern[pIndex] == '*' && pIndex + 1 <= pLen && sIndex == sLen)
                return false;
            //match 1 more char, advance 1 for both 
            if (pattern[pIndex] == '?' || pattern[pIndex] == source[sIndex])
                return StringMatch1(pattern, pIndex + 1, source, sIndex + 1);
            if (pattern[pIndex] == '*')
                return StringMatch1(pattern, pIndex + 1, source, sIndex) || StringMatch1(pattern, pIndex, source, sIndex + 1);
            return false;
        }

        public static int ReverseNumber(int number, int result)
        {
            if (number == 0)
                return result;
            var m = number % 10;
            result = result * 10 + m;
            var tmp = ReverseNumber(number/10, result);
            return tmp;
        }

        public static int ReverseNumber(int number)
        {
            if (number == 0)
                return 0;
            var m = number % 10;
            var result = m * Math.Pow(10, number.ToString().Length-1) + ReverseNumber(number / 10);
            return (int)result;
        }

        //find a number in a sorted array, if the number is not found, return the index where to insert it
        public static int FindNumberInSortedArrayOrIndexToInsert(int[] input, int target)
        {
            if (input == null)
                return -1;
            if (input.Length == 1 && target == input[0])
                return 0;

            int start = 0, end = input.Length - 1, mid;
            while (start < end)
            {
                mid = start + (end - start)/2;
                if (input[mid] == target)
                    return mid;
                if (target < input[mid])
                    end = mid - 1;
                else
                    start = mid + 1;
            }

            if (start == input.Length)
                return input.Length;
            if (target < input[start])
                return start;
            return start + 1;
        }

        public static int FindNumberInSortedArrayOrIndexToInsert(int[] input, int start, int end, int target)
        {
            if (input == null)
                return -1;
            int mid = (start + end)/2;
            if (input[mid] == target)
                return mid;
            if (target < input[mid])
            {
                if (start < mid)
                    return FindNumberInSortedArrayOrIndexToInsert(input, start, mid - 1, target);
                //not found
                return start;
            }
            else
            {
                if(end > mid)
                    return FindNumberInSortedArrayOrIndexToInsert(input, mid + 1, end, target);
                //not found
                return end + 1;
            }
        }

        [STAThread]
        static void Main()
        {
            //var ret = ReverseString1("I   like   Ms ?");

            //InsertionSort(a);
            //FindReaptedNumber.FindRepeatedNumber1(a);
            //var s = RecursiveReverseString("this");
            //var r = RecInsertStarBetween("12345");
            //FibonacciSeries(34);
            //MyList<int>.Test();

            BinarySearchTree<int>.Test();

            //BinaryTree<int>.Test();
            //var form = new Form1();
            //form.ShowDialog();

            /*Node<int> head, tail;
            tail = NewNode<int>(1);
            head = tail;

            tail.next = NewNode<int>(2);
            tail = tail.next;
            tail.next = NewNode<int>(3);
            tail = tail.next;
            tail.next = NewNode<int>(4);
            tail = tail.next;*/

            //head = ReverseNode(head);
            //head = RecurReverseNode(head);

            /*            string p = "stbbtst";
                        var result = LongestSubPalidrome(p);*/

            //PriorityQueue<int>.Test();

            //QuickSort.Test();
            //MergeSort.Test();

            //DecoratorTest.Test();
            //MyQueue.Test();

            //QueueArrayImp<int>.Test();

            //MergeSort.Test();

            //var match = StringMatch("te?st", "te1st");

            //BinaryTreeNode<int>.Test();

            //Tries.Test();

            //Dynamic.Test();

            //LongestCommonString.Test();
            //var ret = ReverseNumber(153, 0);
            //ret = ReverseNumber(1534);

            /*int[] a = new int[] {1,5,7};
            var index = FindNumberInSortedArrayOrIndexToInsert(a, -4);
            index = FindNumberInSortedArrayOrIndexToInsert(a, 0, a.Length - 1, -4);
            */

            Histogram.Test();
            //LongestWordConsistOtherWords.Test();
        }
    }
}
