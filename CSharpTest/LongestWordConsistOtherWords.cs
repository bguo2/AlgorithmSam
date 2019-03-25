using System;
using System.Collections.Generic;

namespace CSharpTest
{
    //Write a program to find the longest word made of other words.
    //[the, test, aaa, cat, cataaa, testthecataaa, sdd] => testthecataaa
    public static class LongestWordConsistOtherWords
    {
        public static string FindLongestWord(string[] words)
        {
            if (words == null || words.Length == 1)
                return null;
            var set = new HashSet<string>(words);
            //sort with descending order
            Array.Sort(words, (string1, string2) =>
                {
                    if (string1.Length > string2.Length)
                        return -1;
                    if (string1.Length == string2.Length)
                        return 0;
                    return 1;
                });

            foreach (var word in words)
            {
                if (MadeOfWords(set, word, word.Length))
                    return word;
            }

            return null;
        }

        public static bool MadeOfWords(HashSet<string> set, string word, int origLen)
        {
            if (string.IsNullOrEmpty(word))
                return true;
            int len = word.Length;
            //check each combination to see if it is in the set
            for (int i = 1; i <= len; i++)
            {
                if (i == origLen) //itself
                    return false;
                var subWord = word.Substring(0, i);
                if (set.Contains(subWord))
                {
                    if (MadeOfWords(set, word.Substring(i), origLen))
                        return true;
                }
            }
            return false;
        }

        public static void Test()
        {
            /*
            string[] test = {"cat","cats","catsdogcats","catxdogcatsrat","dog",
                "dogcatsdog","hippopotamuses","rat","ratcatdogcat"};*/
            string[] test =
                {
                    "test", "tester", "testertest", "testing",
                    "apple", "seattle", "banana", "batting", "ngcat",
                    "batti", "bat", "testingtester", "testbattingcat"
                };
            var ret = FindLongestWord(test);
        }
    }
}
