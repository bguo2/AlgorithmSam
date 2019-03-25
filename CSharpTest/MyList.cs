using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class Node<T>
    {
        public T content { get; set; }
        public Node<T> Next { get; set; }
    }

    public class TreeNode<T>
    {
        public TreeNode<T>  Left { get; set; }
        public TreeNode<T>  Rigt { get; set; }
        public T  Data { get; set; }
    }

    public class MyList<T> where T : IComparable<T>
    {
        private Node<T> Head = null;
        private Node<T> Current = null;
        public int Count { get; private set; }

        public void Insert(T obj)
        {
            var temp = new Node<T>()
            {
                content = obj,
                Next = null
            };

            if (Head == null)
            {
                Head = temp;
                Current = temp;
            }
            else
            {
                Current.Next = temp;
                Current = temp;
            }
            Count++;
        }

        public void Push(ref Node<T> head, T data1)
        {
            var temp = new Node<T>()
            {
                content = data1,
                Next = null
            };

            temp.Next = head;
            head = temp;
        }

        public T Get(int pos)
        {
            var temp = Head;
            int curPos = 0;
            while (temp != null)
            {
                if (curPos == pos)
                {
                    return temp.content;
                }
                temp = temp.Next;
                curPos++;
            }

            return default(T);
        }

        public void AppendList(MyList<T> list1)
        {
            Current.Next = list1.Head;
            Current = list1.Current;
        }

        public Node<T> Reverse(Node<T> node)
        {
            if (node == null || node.Next == null)
                return node;
            Node<T> cur = node;
            Node<T> pre = null, next = null;
            while (cur != null)
            {
                next = cur.Next;
                cur.Next = pre;
                pre = cur;
                cur = next;
            }

            return pre;
        }

        public Node<T> ReverseRecursive(Node<T> node)
        {
            if (node == null)
                return null;
            if (node.Next == null)
                return node;
            Node<T> tmp = ReverseRecursive(node.Next);
            node.Next.Next = node;
            node.Next = null;
            return tmp;
        }

        public Node<T> Reverse1(Node<T> start, Node<T> end)
        {
            if (start == null || start.Next == null)
                return start;
            Node<T> cur = start;
            Node<T> pre = end, next;

            while (cur != end)
            {
                next = cur.Next;
                cur.Next = pre;
                pre = cur;
                cur = next;
            }

            return pre;
        }

        public static Node<T> MergeSortedList<T>(Node<T> list1, Node<T> list2) where T : IComparable<T>
        {
            if (list1 == null)
                return list2;
            if (list2 == null)
                return list1;
            //create a fake tail
            Node<T> tail = new Node<T>();
            Node<T> result = tail, curList1 = list1, curList2 = list2;
            while (curList1 != null && curList2 != null)
            {
                if (curList1.content.CompareTo(curList2.content) <= 0)
                {
                    tail.Next = curList1;
                    curList1 = curList1.Next;
                    tail = tail.Next;
                    tail.Next = null;
                }
                else
                {
                    tail.Next = curList2;
                    curList2 = curList2.Next;
                    tail = tail.Next;
                    tail.Next = null;
                }
            }

            if (curList1 == null)
            {
                tail.Next = curList2;
            }
            if (curList2 == null)
            {
                tail.Next = curList1;
            }

            //remove the faked tail
            var tmp = result;
            result = tmp.Next;
            tmp = null;
            return result;
        }

        public static Node<T> RecurMergeSortedList<T>(Node<T> list1, Node<T> list2) where T : IComparable<T>
        {
            if (list1 == null)
                return list2;
            if (list2 == null)
                return list1;
            Node<T> result = null;
            if (list1.content.CompareTo(list2.content) <= 0)
            {
                result = list1;
                result.Next = RecurMergeSortedList(list1.Next, list2);
            }
            else
            {
                result = list2;
                result.Next = RecurMergeSortedList(list1, list2.Next);
            }

            return result;
        }

        public Node<T> FindMiddle(Node<T> list)
        {
            if (list == null || list.Next == null)
                return null;
            Node<T> slow = list, fast = list;
            while (fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            return slow.Next;
        }

        public Node<T> RecurFindMiddle(Node<T> slow, Node<T> fast)
        {
            if (fast == null)
                return null;
            if(fast.Next == null)
                return slow.Next;
            if (fast.Next.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }
            else
            {
                return slow.Next;
            }
            slow = RecurFindMiddle(slow, fast);
            return slow;
        }

        public Node<T> SplitInTheMiddle(Node<T> list)
        {
            if (list == null)
                return list;

            Node<T> slow = list;
            Node<T> fast = list;

            while (fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            var tmp = slow.Next;
            slow.Next = null;
            return tmp;
        }

        public Node<T> MergeSort(Node<T> list)
        {
            if (list == null || list.Next == null)
                return list;
            Node<T> front = list;
            Node<T> back = SplitInTheMiddle(list);

            front = MergeSort(front);
            back = MergeSort(back);
            var head = MergeSortedList(front, back);
            return head;
        }

        //all numbers less than "number" must before "number"
        public Node<T> PartitionList(Node<T> head, T number)
        {
            if (head == null || head.Next == null)
                return head;
            var fakeHead1 = new Node<T>(); //smaller ones
            var fakeHead2 = new Node<T>(); //bigger ones
            var p = head;
            var fakeTail1 = fakeHead1;
            var faketail2 = fakeHead2;
            while (p != null)
            {
                if (p.content.CompareTo(number) < 0)
                {
                    fakeTail1.Next = p;
                    fakeTail1 = fakeTail1.Next;
                    p = p.Next;
                    fakeTail1.Next = null;
                }
                else
                {
                    faketail2.Next = p;
                    faketail2 = faketail2.Next;
                    p = p.Next;
                    faketail2.Next = null;
                }
            }

            fakeTail1.Next = fakeHead2.Next;
            return fakeHead1.Next;
        }

        //Given a linked list, swap every two adjacent nodes and return its head.
        //For example, given 1->2->3->4, you should return the list as 2->1->4->3.
        //Your algorithm should use only constant space. You may not modify the values in the list, only nodes itself can be changed.
        public static Node<T> SwapList<T>(Node<T> node)
        {
            if (node == null || node.Next == null)
                return node;
            var h = new Node<T>();
            h.Next = node;
            var p = h;
            while (p.Next != null && p.Next.Next != null)
            {
                //use t1 to track first node
                var t1 = p;
                p = p.Next;
                t1.Next = p.Next;

                //use t2 to track next node of the pair
                var t2 = p.Next.Next;
                p.Next.Next = p;
                p.Next = t2;
            }

            return h.Next;
        }

        public static int GetLength<T>(Node<T> head)
        {
            if (head == null)
                return 0;
            int length = 0;
            while (head != null)
            {
                length++;
                head = head.Next;
            }

            return length;
        }

        private static Node<T> nodeBst;
        public TreeNode<T> BuildBst(Node<T> head)
        {
            nodeBst = head;
            if (head == null)
                return null;
            int len = GetLength(head);
            return BuildBst(0, len - 1);
        }

        private TreeNode<T> BuildBst(int start, int end)
        {
            if (start > end)
                return null;
            int mid = (start + end)/2;
            TreeNode<T> left = BuildBst(start, mid - 1);
            TreeNode<T> root = new TreeNode<T>();
            root.Data = nodeBst.content;
            nodeBst = nodeBst.Next;
            TreeNode<T> right = BuildBst(mid + 1, end);
            root.Left = left;
            root.Rigt = right;
            return root;
        }

        public static void Test()
        {
            var list = new MyList<int>();
            list.Insert(1);
            list.Insert(2);
            list.Insert(3);
            list.Insert(4);
            var tmpEnd = list.Current;
            list.Insert(5);
            list.Insert(6);
            list.Insert(7);

            var temList = list.Reverse1(list.Head.Next, tmpEnd);

            list.Head = list.MergeSort(list.Head);
            var tree = list.BuildBst(list.Head);

            //var head0 = SwapList<int>(list.Head);

            //reverse a like
            //list.Head = list.Reverse(list.Head);

            //list.Head = list.ReverseRecursive(list.Head);

            var list2 = new MyList<int>();
            list2.Insert(2);
            list2.Insert(9);
            list2.Insert(11);

            //list.Head = list.MergeSort(list.Head);
            //var result = MergeSortedList<int>(list.Head, list2.Head);

            //Node<int> result1 = RecurMergeSortedList<int>(list.Head, list2.Head);

            int length = 1;
            //var middle = list.FindMiddle(list.Head);
            //var middle = list.RecurFindMiddle(list.Head, list.Head);

            //var back = list.SplitInTheMiddle(list.Head);

            var head = list.MergeSort(list.Head);

            var list3 = new MyList<int>();
            list3.Insert(1);
            list3.Insert(4);
            list3.Insert(3);
            list3.Insert(2);
            list3.Insert(5);
            var head1 = list3.Head;
            var cur = head1;
            var pre = head1;
            while (cur.Next != null)
            {
                var next = cur.Next;
                cur.Next = next.Next;
                next.Next = cur;
                if (pre == head1)
                    head1 = next;
                else
                    pre.Next = next;
                pre = cur;
                cur = cur.Next;
            }
            //var result = list3.PartitionList(list3.Head, 3);
        }
    }
}
