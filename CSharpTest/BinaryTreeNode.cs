using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class BinaryTreeNode<T> : IEnumerable<T>
    {
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
        public T Data { get; set; }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            yield return this.Data;
            if (this.Left != null)
            {
                foreach (var node in this.Left)
                {
                    yield return node;
                }
            }
            if (this.Right != null)
            {
                foreach (var node in this.Right)
                {
                    yield return node;
                }
            }
        }

        public static void Test()
        {
            var root = new BinaryTreeNode<int>()
            {
                Data = 1,
                Left = new BinaryTreeNode<int>()
                {
                    Data = 2,
                    Left = new BinaryTreeNode<int>()
                    {
                        Data = 4
                    },
                    Right = new BinaryTreeNode<int>()
                    {
                        Data = 5
                    }
                },
                Right = new BinaryTreeNode<int>()
                {
                    Data = 3,
                    Left = new BinaryTreeNode<int>()
                    {
                        Data = 6
                    },
                    Right = new BinaryTreeNode<int>()
                    {
                        Data = 7
                    }
                }
            };

            foreach (var node in root)
            {
                Console.WriteLine("{0}", node);
            }
        }
    }
}
