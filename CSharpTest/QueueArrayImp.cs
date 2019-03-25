using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class QueueArrayImp<T> where T: new()
    {
        private int _capacity, _count = 0, _front = 0, _back = 0;
        private T[] _element = null;

        public QueueArrayImp()
        {
            _capacity = 10;
            _element = new T[_capacity];
        }

        public QueueArrayImp(int capacity)
        {
            _capacity = capacity;
            _element = new T[_capacity];
        }

        public bool IsEmpty()
        {
            return (_count == 0);
        }

        public bool IsFull()
        {
            return (_count == _capacity);
        }

        public void Enqueue(T data)
        {
            if (IsFull())
                throw new Exception("it is full");
            _element[_back % _capacity] = data;
            _back++;
            _count++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new Exception("it is empty");
            T data = _element[_front % _capacity];
            _front++;
            _count--;
            return data;
        }

        public T Front()
        {
            if (IsEmpty())
                throw new Exception("it is empty");
            return _element[_front % _capacity];
        }

        public static void Test()
        {
            try
            {
                var queue = new QueueArrayImp<int>(5);
                queue.Enqueue(1);
                queue.Enqueue(2);
                queue.Enqueue(3);
                queue.Enqueue(4);
                queue.Enqueue(5);

                var front = queue.Dequeue();
                front = queue.Dequeue();
                queue.Enqueue(6);
                queue.Enqueue(7);
                front = queue.Dequeue();
                front = queue.Dequeue();
                front = queue.Dequeue();
                front = queue.Dequeue();
                front = queue.Dequeue();
                front = queue.Dequeue();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
