using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    //implement Stack with queue
    public class MyStack
    {
        private Queue<int> q1 = new Queue<int>();

        //make Push costly
        public void Push1(int n)
        {
            var q2 = new Queue<int>();
            q2.Enqueue(n);
            while (q1.Count > 0)
            {
                q2.Enqueue(q1.Dequeue());
            }

            q1 = q2;
        }

        public int Pop1()
        {
            return q1.Dequeue();
        }

        //make Pop costly
        public void Push(int n)
        {
            q1.Enqueue(n);
        }

        public int Pop()
        {
            var q2 = new Queue<int>();
            while (q1.Count > 1)
                q2.Enqueue(q1.Dequeue());
            var x = q1.Dequeue();
            q1 = q2;
            return x;
        }
    }
}
