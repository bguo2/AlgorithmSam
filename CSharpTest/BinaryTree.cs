using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class BinaryTree<T>
    {
        public class TreeNode
        {
            public T Data { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
        }

        public TreeNode Root { get; private set; }

        private TreeNode CreateNode(T content)
        {
            var tmpNode = new TreeNode
            {
                Data = content,
                Left = null,
                Right = null
            };

            return tmpNode;
        }

        //insert to the Binary tree as balance as possible
        public void Insert(T content)
        {
            if (Root == null)
            {
                Root = CreateNode(content);
                return;
            }

            var current = FindPlaceToInsert(Root);
            if (current.Left == null)
                current.Left = CreateNode(content);
            else
                current.Right = CreateNode(content);            
        }

        private TreeNode FindPlaceToInsert(TreeNode node)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(node);
            while (queue.Count != 0)
            {
                var x = queue.Peek();
                queue.Dequeue();
                if (x.Left == null || x.Right == null)
                    return x;
                if (x.Left != null)
                    queue.Enqueue(x.Left);
                if (x.Right != null)
                    queue.Enqueue(x.Right);
            }

            return null;
        }

        public void Bfs(TreeNode node)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(node);
            while (queue.Count != 0)
            {
                var x = queue.Dequeue();
                Console.WriteLine("{0},", x.Data);
                if(x.Left != null)
                    queue.Enqueue(x.Left);
                if(x.Right != null)
                    queue.Enqueue(x.Right);
            }
        }

        public void PrintLevel(TreeNode root)
        {
            if (root == null)
                return;
            var currentLevel = new Queue<TreeNode>();
            currentLevel.Enqueue(root);
            var nextLevel = new Queue<TreeNode>();
            int level0 = 1, level1 = 1;
            while (currentLevel.Count != 0)
            {
                var node = currentLevel.Dequeue();
                if (level1 != level0)
                {
                    Console.WriteLine("Level switch: {0} => Level {1} ", level0, level1);
                    level0 = level1;
                }

                Console.WriteLine("{0} => Level {1} ", node.Data, level1);
                if (node.Left != null)
                    nextLevel.Enqueue(node.Left);
                if (node.Right != null)
                    nextLevel.Enqueue(node.Right);

                if (currentLevel.Count == 0)
                {
                    level1++;
                    var tmp = currentLevel;
                    currentLevel = nextLevel;
                    nextLevel = tmp;
                }
            }
        }

        public void PrintLevel1(TreeNode root)
        {
            if (root == null)
                return;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var level = 1;
            Console.WriteLine("Level: {0}", level);
            while (queue.Count > 0)
            {
                var qsize = queue.Count;
                while (qsize > 0)
                {
                    var node = queue.Dequeue();
                    qsize--;
                    Console.WriteLine("{0} => Level {1}", node.Data, level);
                    if (node.Left != null)
                        queue.Enqueue(node.Left);
                    if (node.Right != null)
                        queue.Enqueue(node.Right);
                }
                level++;
                Console.WriteLine("Switch to level: {0}", level);
            }
        }

        //total count number to be printed.
        public int PrintLevelRec(TreeNode root, int level, int printLevel)
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
                printCount += PrintLevelRec(root.Right, level - 1, printLevel);
                return printCount;
            }

            return 0;
        }

        //it is pre-order
        public void Dfs(TreeNode node)
        {
            if (node == null)
                return;
            Console.WriteLine("{0},", node.Data);
            Dfs(node.Left);
            Dfs(node.Right);
        }

        public string DfsSum(TreeNode node)
        {
            if (node == null)
                return "0";
            var sum = node.Data.ToString();
            sum = string.Format("{0}+{1}+{2}", sum, DfsSum(node.Left), DfsSum(node.Right));
            return sum;
        }

        //it is pre-order
        public void DfsNonRecursive(TreeNode node)
        {
            if (node == null)
                return;
            var stack = new Stack<TreeNode>();
            stack.Push(node);
            while (stack.Count != 0)
            {
                var x = stack.Pop();
                Console.WriteLine("{0},", x.Data);
                if (x.Right != null)
                    stack.Push(x.Right);
                if (x.Left != null)
                    stack.Push(x.Left);
            }
        }

        public void PreOrder(TreeNode node)
        {
            if (node == null)
                return;
            Console.WriteLine("{0}", node.Data);
            PreOrder(node.Left);
            PreOrder(node.Right);
        }

        public void InOrder(TreeNode node)
        {
            if (node == null)
                return;
            InOrder(node.Left);
            Console.WriteLine("{0}", node.Data);
            InOrder(node.Right);
        }

        public void NonRecursiveInOrder(TreeNode node)
        {
            if (node == null)
                return;
            var stack = new Stack<TreeNode>();
            var current = node;
            while (current != null || stack.Count > 0)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    current = stack.Pop();
                    Console.WriteLine("{0}", current.Data);
                    current = current.Right;
                }
            }
        }

        public void PostOrder(TreeNode node)
        {
            if (node == null)
                return;
            PostOrder(node.Left);
            PostOrder(node.Right);
            Console.WriteLine("{0}", node.Data);
        }

        public void NonRecursivePostOrder(TreeNode node)
        {
            if (node == null)
                return;
            var stack = new Stack<TreeNode>();
            stack.Push(node);
            while (stack.Count > 0)
            {
                var next = stack.Peek();
                bool finishedSubTrees = (next.Left == node || next.Right == node);
                bool isLeaf = (next.Left == null && next.Right == null);
                if (finishedSubTrees || isLeaf)
                {
                    node = stack.Pop();
                    Console.WriteLine("{0}", node.Data);
                }
                else
                {
                    if (next.Right != null)
                        stack.Push(next.Right);
                    if (next.Left != null)
                        stack.Push(next.Left);
                }
            }
        }

        public int Height(TreeNode node)
        {
            if (node == null)
                return -1;
            int leftH = Height(node.Left);
            int rightH = Height(node.Right);
            if (leftH > rightH)
                return leftH + 1;
            else
                return rightH + 1;
        }

        public int Helper(List<List<T>> list, TreeNode root)
        {
            if (root == null)
                return -1;

            int left = Helper(list, root.Left);
            int right = Helper(list, root.Right);
            int curr = Math.Max(left, right) + 1;

            // the first time this code is reached is when curr==0,
            //since the tree is bottom-up processed.
            if (list.Count <= curr)
            {
                list.Add(new List<T>());
            }

            list[curr].Add(root.Data);

            return curr;
        }

        //IEnumerable implementation for preorder
        public IEnumerable<TreeNode> PreOrderEnumeratorImp(TreeNode root)
        {
            if (root == null)
                yield break;
            var stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                yield return node;
                if (node.Right != null)
                    stack.Push(node.Right);
                if (node.Left != null)
                    stack.Push(node.Left);
            }
        }

        //IEnumerable implementation for preorder
        public IEnumerable<TreeNode> InOrderEnumeratorImp(TreeNode root)
        {
            if (root == null)
                yield break;
            var stack = new Stack<TreeNode>();
            var current = root;
            while (true)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        current = stack.Pop();
                        yield return current;
                        current = current.Right;
                    }
                    else
                        break;
                }
            }
        }

        //IEnumerable recursive imp for InOrder
        public IEnumerable<TreeNode> InOrderRecIEnumImp(TreeNode node)
        {
            if (node == null)
                yield break;
            foreach (var e in InOrderRecIEnumImp(node.Left))
                yield return e;
            yield return node;
            foreach (var e in InOrderRecIEnumImp(node.Right))
                yield return e;
        }

        //IEnumerable recursive imp for PostOrder
        public IEnumerable<TreeNode> PostOrderRecIEnumImp(TreeNode node)
        {
            if (node == null)
                yield break;
            foreach (var e in PostOrderRecIEnumImp(node.Left))
                yield return e;
            foreach (var e in PostOrderRecIEnumImp(node.Right))
                yield return e;
            yield return node;
        }

        public IEnumerator<T> GetPreOrderEnumerator(TreeNode root)
        {
            if (root == null)
                yield break;
            var stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                yield return node.Data;
                if (node.Right != null)
                    stack.Push(node.Right);
                if (node.Left != null)
                    stack.Push(node.Left);
            }
        }

        //print tree node vertically
        public void PrintVerticalOrder(TreeNode root)
        {
            var markResult = new Dictionary<int, List<T>>();
            MarkTreeNode(root, 0, markResult);
            //find the min width
            var lWidth = 0;
            while (true)
            {
                if (markResult.ContainsKey(lWidth))
                {
                    lWidth--;
                    continue;
                }
                break;
            }

            if (lWidth != 0)
                lWidth++;

            var rWidth = markResult.Count + lWidth;
            for (int i = lWidth; i < rWidth; i++)
            {
                Console.WriteLine("Level: {0}", i);
                foreach (var e in markResult[i])
                    Console.Write("{0} ", e);
                Console.WriteLine("");
            }
        }

        private void MarkTreeNode(TreeNode root, int hDistance, Dictionary<int, List<T>> result)
        {
            if (root == null)
                return;
            if (!result.ContainsKey(hDistance))
            {
                result[hDistance] = new List<T>();
            }
            result[hDistance].Add(root.Data);
            MarkTreeNode(root.Left, hDistance - 1, result);
            MarkTreeNode(root.Right, hDistance + 1, result);
        }

        public IEnumerator GetInOrderIterator()
        {
            var iterator = new BinaryTreeInOrderIterator(Root);
            return iterator;
        }

        public IEnumerator GetPreOrderIterator()
        {
            var iterator = new BinaryTreePreOrderIterator(Root);
            return iterator;
        }

        public IEnumerator GetPostOrderIterator()
        {
            var iterator = new BinaryTreePostOrderIterator(Root);
            return iterator;
        }

        public class BinaryTreeInOrderIterator : IEnumerator
        {
            private TreeNode _current, _root;
            private Stack<TreeNode> _stack = new Stack<TreeNode>();

            public BinaryTreeInOrderIterator(TreeNode root)
            {
                _root = root;
                Reset();
            }

            public bool MoveNext()
            {
                bool hasMore = _stack.Count > 0;
                if (_stack.Count > 0)
                {
                    var current = _stack.Pop();
                    current = current.Right;
                    while (current != null)
                    {
                        _stack.Push(current);
                        current = current.Left;
                    }
                    if(_stack.Count > 0)
                        _current = _stack.Peek();
                }

                return hasMore;
            }

            object IEnumerator.Current
            {
                get { return _current; }
            }

            public void Reset()
            {
                _stack.Clear();
                var current = _root;
                while (current != null)
                {
                    _stack.Push(current);
                    current = current.Left;
                }
                if(_stack.Count > 0)
                    _current = _stack.Peek();
            }            
        }

        public class BinaryTreePreOrderIterator : IEnumerator
        {
            private TreeNode _current, _root;
            private Stack<TreeNode> stack = new Stack<TreeNode>();

            public BinaryTreePreOrderIterator(TreeNode root)
            {
                _root = root;
                _current = root;
                Reset();
            }

            public bool MoveNext()
            {
                var hasMore = stack.Count > 0;
                if (!hasMore)
                    return false;
                var current = stack.Pop();
                _current = current;
                if (_current.Right != null)
                    stack.Push(_current.Right);
                if (_current.Left != null)
                    stack.Push(_current.Left);
                return true;
            }

            public void Reset()
            {
                stack.Clear();
                stack.Push(_root);
                _current = stack.Pop();
                if (_current.Right != null)
                    stack.Push(_current.Right);
                if (_current.Left != null)
                    stack.Push(_current.Left);
            }

            object IEnumerator.Current
            {
                get { return _current; }
            }
        }

        public class BinaryTreePostOrderIterator : IEnumerator
        {
            private TreeNode _current, _root, _popNode;
            private Stack<TreeNode> stack = new Stack<TreeNode>();

            public BinaryTreePostOrderIterator(TreeNode root)
            {
                _root = root;
                Reset();
            }

            public bool MoveNext()
            {
                var hasMore = (stack.Count > 0);
                var current = stack.Peek();
                var isLeaf = (current.Left == null && current.Right == null);
                var isSubtreeFinished = (current.Left == _popNode || current.Right == _popNode);
                if(isLeaf || isSubtreeFinished)
                {
                    _popNode = stack.Pop();
                }
                else
                {
                    current = stack.Peek();
                    while (current != null)
                    {
                        if (current.Right != null)
                            stack.Push(current.Right);
                        if (current.Left != null)
                            stack.Push(current.Left);
                        current = current.Left;
                    }
                }
                _current = stack.Peek();

                return hasMore;
            }

            public object Current
            {
                get { return _current; }
            }

            public void Reset()
            {
                stack.Clear();
                var current = _root;
                stack.Push(current);
                while (current != null)
                {
                    if (current.Right != null)
                        stack.Push(current.Right);
                    if (current.Left != null)
                        stack.Push(current.Left);
                    current = current.Left;
                }
                _current = stack.Peek();
            }
        }

        public static void Test()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);
            tree.Insert(4);
            tree.Insert(5);
            tree.Insert(6);
            tree.Insert(7);
            tree.Insert(8);
            tree.Insert(9);

            //
            var result = new List<List<int>>();
            tree.Helper(result, tree.Root);

            var sum = tree.DfsSum(tree.Root);

            Console.WriteLine("PrintLevel");
            tree.PrintLevel(tree.Root);

            Console.WriteLine("PrintLevel1");
            tree.PrintLevel1(tree.Root);

            Console.WriteLine("PrintLevel Recursive");
            var level = 1;
            while (true)
            {
                if (tree.PrintLevelRec(tree.Root, level, level) == 0)
                    break;
                level++;
            }

            tree.Bfs(tree.Root);
            int h = tree.Height(tree.Root);
            Console.WriteLine("Height: {0}", h);

            Console.WriteLine("Print vertical order:");
            tree.PrintVerticalOrder(tree.Root);


            Console.WriteLine("Preorder:");
            tree.PreOrder(tree.Root);

            Console.WriteLine("Preorder with IEnumerable:");
            var nodes = tree.PreOrderEnumeratorImp(tree.Root);
            foreach (var node in nodes)
            {
                Console.WriteLine("{0}", node.Data);
            }

            Console.WriteLine("PreOrder with Enumerator:");
            IEnumerator<int> iterator = tree.GetPreOrderEnumerator(tree.Root);
            while (iterator.MoveNext()) 
            {
                Console.WriteLine("{0}", iterator.Current);
            }

            Console.WriteLine("PreOrder with My IEnumerator:");
            var iterator0 = tree.GetPreOrderIterator();
            Console.WriteLine("{0}", ((TreeNode)iterator0.Current).Data);
            while (iterator0.MoveNext())
            {
                Console.WriteLine("{0}", ((TreeNode)iterator0.Current).Data);
            }

            Console.WriteLine("Inorder:");
            tree.InOrder(tree.Root);
            Console.WriteLine("NonRecursiveInOrder:");
            tree.NonRecursiveInOrder(tree.Root);

            Console.WriteLine("Inorder with IEnumerable:");
            nodes = tree.InOrderEnumeratorImp(tree.Root);
            foreach (var node in nodes)
            {
                Console.WriteLine("{0}", node.Data);
            }

            Console.WriteLine("Inorder recusion with IEnumerable:");
            nodes = tree.InOrderRecIEnumImp(tree.Root);
            foreach (var node in nodes)
            {
                Console.WriteLine("{0}", node.Data);
            }
          
            Console.WriteLine("InOrder with My IEnumerator:");
            var iterator1 = tree.GetInOrderIterator();
            Console.WriteLine("{0}", ((TreeNode)iterator1.Current).Data);
            while (iterator1.MoveNext())
            {
                Console.WriteLine("{0}", ((TreeNode)iterator1.Current).Data);
            }

            Console.WriteLine("Postorder:");
            tree.PostOrder(tree.Root);
            Console.WriteLine("NonRecursivePostOrder:");
            tree.NonRecursivePostOrder(tree.Root);

            Console.WriteLine("Postorder recusion with IEnumerable:");
            nodes = tree.PostOrderRecIEnumImp(tree.Root);
            foreach (var node in nodes)
            {
                Console.WriteLine("{0}", node.Data);
            }

            Console.WriteLine("Postorder recusion with My IEnumerator:");
            var iterator2 = tree.GetPostOrderIterator();
            Console.WriteLine("{0}", ((TreeNode)iterator2.Current).Data);
            while (iterator2.MoveNext())
            {
                Console.WriteLine("{0}", ((TreeNode)iterator2.Current).Data);
            }

            Console.WriteLine("Dfs:");
            tree.Dfs(tree.Root);
            Console.WriteLine("DfsNonRecursive:");
            tree.DfsNonRecursive(tree.Root);
        }
    }
}
