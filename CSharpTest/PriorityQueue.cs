using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        public int Capacity { get; private set; }
        private T[] _elements;
        private int _last;
        public PriorityQueue(int capacity)
        {
            _elements = new T[capacity];
            Capacity = capacity;
            _last = 0;
        }

        //level i => 2i (left), 2i+1(right), insert it to the last and move it up if it has less priority
        public void Insert(T data)
        {
            if (_last >= Capacity)
                return;
            _elements[_last] = data;
            _last++;
            int i = _last;
            while (i > 1 && _elements[i-1].CompareTo(_elements[i/2-1]) < 0)
            {
                T temp = _elements[i-1];
                _elements[i-1] = _elements[i/2-1];
                _elements[i/2-1] = temp;
                i = i / 2;
            }
        }

        //move the last element to the top and push it down
        public void DeleteMin()
        {
            if (_last == 0)
                return;
            T min = _elements[0];
            _elements[0] = _elements[_last - 1];
            _elements[_last - 1] = default(T);
            _last--;
            int i = 1, j = 0;
            while (i <= _last / 2)
            {
                if (_elements[2 * i - 1].CompareTo(_elements[2 * i]) < 0 || 2*i == _last)
                    j = 2 * i - 1;
                else
                    j = 2 * i;
                //exchange
                if (_elements[i-1].CompareTo(_elements[j]) > 0)
                {
                    T temp = _elements[i-1];
                    _elements[i-1] = _elements[j];
                    _elements[j] = temp;
                    i = j+1;
                }
                else
                    return;
            }
        }

        public static void Test()
        {
            var queue = new PriorityQueue<int>(20);
            queue.Insert(3);
            queue.Insert(5);
            queue.Insert(9);
            queue.Insert(6);
            queue.Insert(8);
            queue.Insert(9);
            queue.Insert(10);
            queue.Insert(10);
            queue.Insert(18);
            queue.Insert(9);

            queue.DeleteMin();
            queue.DeleteMin();
            queue.DeleteMin();
            queue.DeleteMin();
            queue.DeleteMin();
            queue.DeleteMin();
            queue.DeleteMin();
            queue.DeleteMin();
            queue.DeleteMin();
            queue.DeleteMin();
        }

        public static void heapSort(int[] numbers)
        {
          int i, temp;
          var array_size = numbers.Length;

          for (i = (array_size / 2)-1; i >= 0; i--)
            siftDown(numbers, i, array_size-1);

          for (i = array_size-1; i >= 1; i--)
          {
            temp = numbers[0];
            numbers[0] = numbers[i];
            numbers[i] = temp;
            siftDown(numbers, 0, i-1);
          }
        }

        public static void siftDown(int[] numbers, int root, int bottom)
        {
          int maxChild, temp;
          bool done = false;

          while ((root*2 <= bottom) && !done)
          {
            if (root*2 == bottom)
              maxChild = root * 2;
            else if (numbers[root * 2] > numbers[root * 2 + 1])
              maxChild = root * 2;
            else
              maxChild = root * 2 + 1;

            if (numbers[root] < numbers[maxChild])
            {
              temp = numbers[root];
              numbers[root] = numbers[maxChild];
              numbers[maxChild] = temp;
              root = maxChild;
            }
            else
              done = true;
          }
        }
    }
}
