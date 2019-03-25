using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
        public bool IsLeaf { get; set; }
    }

    public class Tries
    {
        private readonly TrieNode _root;

        public Tries()
        {
            _root = new TrieNode();
        }

        public void Insert(string word)
        {
            var children = _root.Children;
            for (int i = 0; i < word.Length; i++)
            {
                TrieNode t;
                if (children.ContainsKey(word[i]))
                {
                    t = children[word[i]];
                }
                else
                {
                    t = new TrieNode();
                    children[word[i]] = t;
                }

                children = t.Children;
                if (i == word.Length - 1)
                    t.IsLeaf = true;
            }           
        }

        public bool Search(string word)
        {
            if (string.IsNullOrEmpty(word))
                return false;

            var children = _root.Children;
            TrieNode t = null;
            foreach (char key in word)
            {
                if (children.ContainsKey(key))
                {
                    t = children[key];
                    children = t.Children;
                }
                else
                {
                    t = null;
                    break;
                }
            }

            if (t != null && t.IsLeaf)
                return true;
            return false;
        }

        public static void Test()
        {
            var tries = new Tries();
            var content0 = "this is my test for tries";
            var content = content0.Split(' ');
            foreach (string s in content)
            {
                tries.Insert(s);
            }

            var ret = tries.Search("is");
            Console.WriteLine("is is found:{0}", ret);
            ret = tries.Search("trie");
            Console.WriteLine("trie is found:{0}", ret);
            ret = tries.Search("tries");
            Console.WriteLine("tries is found:{0}", ret);
            ret = tries.Search("t");
            Console.WriteLine("t is found:{0}", ret);
        }
    }
}
