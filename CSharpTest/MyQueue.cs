using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    //Queue implementation with stack: s2 is the reverse of s1
    public class MyQueue
    {
        private Stack<int> s1 = new Stack<int>();
        private Stack<int> s2 = new Stack<int>();

        //make Deque costly
        public int Dequeue()
        {
            int e;
            if (s2.Count > 0)
            {
                e = s2.Pop(); 
                Console.WriteLine("{0} ", e);
                return e;
            }
            while (s1.Count > 0)
                s2.Push(s1.Pop());

            e = s2.Pop();
            Console.WriteLine("{0} ", e);

/*            while (s1.Count > 0)
                s2.Push(s1.Pop());
            var e = s2.Pop();
            while (s2.Count > 0)
                s1.Push(s2.Pop());
            Console.WriteLine("{0} ", e);*/
            return e;
        }

        public void Enqueue(int n)
        {
            s1.Push(n);
        }

        //make Enqueue costly
        public int Dequeue2()
        {
            var e = s1.Pop();
            Console.WriteLine("{0} ", e);
            return e;
        }

        public void Enqueue2(int n)
        {
            var s2 = new Stack<int>();
            while (s1.Count > 0)
            {
                s2.Push(s1.Pop());
            }

            s1.Push(n);
            while (s2.Count > 0)
                s1.Push(s2.Pop());
        }

        public static void Test()
        {
            var queue = new MyQueue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            var x = queue.Dequeue();
            x = queue.Dequeue();
            queue.Enqueue(4);
            queue.Enqueue(5);
            x = queue.Dequeue();
            x = queue.Dequeue();
            x = queue.Dequeue();
        }
    }
}
