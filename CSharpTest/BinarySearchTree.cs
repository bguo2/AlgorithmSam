using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class BinarySearchTree<T> where T: IComparable<T>
    {
        public class Node<T>
        {
            public T Data { get; set; }
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }
        }

        public Node<T> Root { get; private set; }

        public Node<T> CreateNode(T content)
        {
            var tmp = new Node<T>
            {
                Data = content,
                Left = null,
                Right = null
            };

            return tmp;
        }

        public void CreateRoot(T content)
        {
            Root = CreateNode(content);
        }

        public void Insert(T content)
        {
            if (Root == null)
                CreateRoot(content);
            else
                Insert(Root, content);
        }

        private void Insert(Node<T> node, T content)
        {
            if (node == null)
                return;

            if (content.CompareTo(node.Data) < 0)
            {
                if (node.Left == null)
                    node.Left = CreateNode(content);
                else
                    Insert(node.Left, content);
            }
            else
            {
                if (node.Right == null)
                    node.Right = CreateNode(content);
                else
                    Insert(node.Right, content);
            }
        }

        public T GetMinimum(Node<T> node)
        {
            if (node == null)
                return default(T);
            while (node.Left != null)
                node = node.Left;
            return node.Data;
        }

        public T GetMinimumRecursive(Node<T> node)
        {
            if (node == null)
                return default(T);
            if(node.Left == null)
                return node.Data;
            var min = GetMinimumRecursive(node.Left);
            return min;
        }

        public Node<T> FindMinNode(Node<T> node)
        {
            if (node == null)
                return null;
            while (node.Left != null)
                node = node.Left;
            return node;
        }

        public Node<T> DeleteMinRecur(Node<T> node)
        {
            if (node == null)
                return null;
            if (node.Left == null)
            {
                return node.Right;
            }

            node.Left = DeleteMinRecur(node.Left);
            return node;
        }

        public Node<T> Delete(T toDelete, Node<T> node)
        {
            if (node == null)
                return null;
            if (toDelete.CompareTo(node.Data) < 0)
                node.Left = Delete(toDelete, node.Left);
            if (toDelete.CompareTo(node.Data) > 0)
                node.Right = Delete(toDelete, node.Right);
            //equal
            if (toDelete.CompareTo(node.Data) == 0)
            {
                if (node.Left == null && node.Right == null)
                    node = null;
                else if (node.Left == null)
                {
                    var tmp = node;
                    node = node.Right;
                    tmp = null;
                }
                else if (node.Right == null)
                {
                    var tmp = node;
                    node = node.Left;
                    tmp = null;
                }
                else
                {
                    var minNode = FindMinNode(node.Right);
                    node.Data = minNode.Data;
                    Delete(minNode.Data, node.Right);
                    //or DeleteMinRecur(node.Right);
                }
            }
            return node;
        }

        public void InOrder(Node<T> node)
        {
            if (node == null)
                return;
            InOrder(node.Left);
            Console.WriteLine("{0}", node.Data);
            InOrder(node.Right);
        }

        public int PrintLevelRec(Node<T> root, int level, int printLevel)
        {
            if (root == null)
                return 0;
            var printCount = 0;
            if (level == 1)
            {
                Console.WriteLine("{0} => Level {1}", root.Data, printLevel);
                return 1;
            }
            else if (level > 1)
            {
                printCount += PrintLevelRec(root.Left, level - 1, printLevel);
                printCount  += PrintLevelRec(root.Right, level - 1, printLevel);
                return printCount;
            }

            return 0;
        }


        public static void Test()
        {
            var tree = new BinarySearchTree<int>();
            tree.Insert(9);
            tree.Insert(6);
            tree.Insert(12);
            tree.Insert(1);
            tree.Insert(8);
            tree.Insert(7);
            tree.Insert(10);

            tree.InOrder(tree.Root);

            var level = 1;
            while (true)
            {
                if (tree.PrintLevelRec(tree.Root, level, level) == 0)
                    break;
                level++;
            }


            tree.Root = tree.DeleteMinRecur(tree.Root);
/*            tmp = tree.DeleteMinRecur1(tree.Root);
            tmp = tree.DeleteMinRecur1(tree.Root);
            tmp = tree.DeleteMinRecur1(tree.Root);
            tmp = tree.DeleteMinRecur1(tree.Root);
            tmp = tree.DeleteMinRecur1(tree.Root);*/

            //var min = tree.GetMinimumRecursive(tree.Root);
            //var min = tree.DeleteMinRecur();
            //min = tree.DeleteMinRecur();
            tree.Root = tree.Delete(6, tree.Root);
        }
    }
}
