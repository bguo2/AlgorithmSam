using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public static class LongestCommonString
    {
        public static int Lcs(char[] s1, char[] s2, int m, int n)
        {
            if (m == 0 || n == 0)
                return 0;
            if (s1[m - 1] == s2[n - 1])
            {
                return 1 + Lcs(s1, s2, m - 1, n - 1);
            }
            return Math.Max(Lcs(s1, s2, m, n - 1), Lcs(s1, s2, m - 1, n));
        }

        //dynamic programming
        public static int LcsDynamic(char[] s1, char[] s2, int m, int n)
        {
            int[,] len = new int[m + 1, n + 1];
            // Following steps build L[m+1][n+1] in bottom up fashion. Note
            // that L[i][j] contains length of LCS of X[0..i-1] and Y[0..j-1] 
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        len[i, j] = 0;
                    else if (s1[i - 1] == s2[j - 1])
                        len[i, j] = len[i - 1, j - 1] + 1;
                    else
                        len[i, j] = Math.Max(len[i - 1, j], len[i, j - 1]);
                }
            }

            return len[m,n];
        }

        public static void PrintLcs(char[] s1, char[] s2)
        {
            int m = s1.Length, n = s2.Length;
            int[,] len = new int[m+1, n+1];
            int i, j;
            // Following steps build L[m+1][n+1] in bottom up fashion. Note
            // that L[i][j] contains length of LCS of X[0..i-1] and Y[0..j-1] 
            for (i = 0; i <= m; i++)
            {
                for (j = 0; j <=n; j++)
                {
                    if (i == 0 || j == 0)
                        len[i, j] = 0;
                    else if (s1[i - 1] == s2[j - 1])
                        len[i, j] = len[i - 1, j - 1] + 1;
                    else
                        len[i, j] = Math.Max(len[i - 1, j], len[i, j - 1]);
                }
            }
            
          // Following code is used to print LCS
           int index = len[m, n];
 
           // Create a character array to store the lcs string
           char[] lcs = new char[index+1];
 
           // Start from the right-most-bottom-most corner and
           // one by one store characters in lcs[]
           i = m;
           j = n;
           while (i > 0 && j > 0)
           {
              // If current character in X[] and Y are same, then
              // current character is part of LCS
              if (s1[i-1] == s2[j-1])
              {
                  lcs[index-1] = s1[i-1]; // Put current character in result
                  i--; j--; index--;     // reduce values of i, j and index
              }
 
              // If not same, then find the larger of two and
              // go in the direction of larger value
              else if (len[i-1, j] > len[i, j-1])
                 i--;
              else
                 j--;
           }

           Console.WriteLine("LCS is: {0}", new string(lcs));            
        }

        //Shortest Common Supersequence
        //Given two strings str1 and str2, find the shortest string that has both str1 and str2 as subsequences.
        //Length of the shortest supersequence  = (Sum of lengths of given two strings) - (Length of LCS of two given strings) 
        public static int ShortestSuperSequenceLen(char[] s1, char[] s2)
        {
            int lcs = Lcs(s1, s2, s1.Length, s2.Length);
            return (s1.Length + s2.Length - lcs);
        }

        public static void Test()
        {
            string s1 = "AGGTAB";
            string s2 = "GXTXAYB";

            var a1 = s1.ToArray();
            var a2 = s2.ToArray();
            //GTAB
            var len = Lcs(a1, a2, a1.Length, a2.Length);
            len = LcsDynamic(a1, a2, a1.Length, a2.Length);
            PrintLcs(a1, a2);

            len = ShortestSuperSequenceLen(a1, a2);
        }
    }
}
