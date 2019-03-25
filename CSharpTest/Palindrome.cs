using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public static class Palindrome
    {
        //search from current position
        public static string SearchSubPalindrome(string input, int left, int right)
        {
            int len = input.Length;
            bool found = false;
            if (left == right)
            {
                left--;
                right++;
            }
            while (left >= 0 && right < len && input[left] == input[right])
            {
                left--;
                right++;
                found = true;
            }

            if (!found)
                return string.Empty;
            return input.Substring(left + 1, right - left - 1);
        }

        public static string LongestSubPalidrome(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;
            string longest = input.Substring(0, 1);
            for (int i = 0; i < input.Length; i++)
            {
                string p1 = SearchSubPalindrome(input, i, i);
                if (p1.Length > longest.Length)
                    longest = p1;
                string p2 = SearchSubPalindrome(input, i, i + 1);
                if (p2.Length > longest.Length)
                    longest = p2;
            }

            return longest;
        }
    }
}
