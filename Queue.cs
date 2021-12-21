using System;
using System.Collections.Generic;

namespace Queues
{
    public class Queue
    {
        private List<int> _Data;

        public Queue()
        {
            _Data = new List<int>();					// 1
        }
        
        public void Enqueue(int element)					// 1
        {
            _Data.Add(element);						// 1
        }

        public int Dequeue()
        {
            if (IsEmpty())
                throw new NullReferenceException("Очередь пуста");
            int result = _Data[0];
            _Data.RemoveAt(0);
            return result;
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new NullReferenceException("Очередь пуста");
            return _Data[0];
        }
        

        public void Clear()
        {
            _Data.Clear();
        }

        public int Get(int position)
        {
            if (position < 0 || position > Count)
                throw new IndexOutOfRangeException("Выход за пределы массива");
            
            for(int i = 0; i < position; ++i)
                Enqueue(Dequeue());
            
            int val = Peek();
            
            for(int i = position; i < Count; ++i)
                Enqueue(Dequeue());
            
            return val;
        }

        public void Set(int position, int value)
        {
            if (position < 0 || position > Count)
                throw new IndexOutOfRangeException("Выход за пределы массива");
            
            for(int i = 0; i < position; ++i)
                Enqueue(Dequeue());
            
            _Data[0] = value;
            
            for(int i = position; i < Count; ++i)
                Enqueue(Dequeue());
        }

        public bool IsEmpty() => Count == 0;					// 2
        
        public int Count
        {
            get => _Data.Count;
        }

        /// <summary>
        /// Перегрузка квадратных скобок
        /// </summary>
        /// <param name="position"></param>
        public int this[int position]
        {
            get => Get(position);
            set => Set(position, value);
        }
        
        public void Swap(int i, int j)
        {
            int temp = Get(i);
            Set(i, Get(j));
            Set(j, temp);
            //Check += 7;
        }

        public void Print()
        {
            for(int i = 0; i < Count; ++i)
                Console.Write(_Data[i] + " ");
            Console.Write("\n");
        }
    }

    public class Sort : Queue
    {
        private int Partition(int start, int end)
        {
            int x = Get((start + end) / 2);
            int i = start;
            int j = end;
            
            //Check += 10;
            while (i <= j)
            {
                while (Get(j) > x){ --j; /*Check += 3;*/}
                while (Get(i) < x) {++i; /*Check += 3;*/}
                //Check += 1;
                if(i >= j)
                    break;
                Swap(i++, j--);
                //Check += 3;
            }
            //Check += 1;
            return j;

        }

        public int FindPivot(int i, int j, int k)
        {
            //Check += 3;
            if (Get(i) > Get(j))
            {
                //Check += 3;
                if (Get(k) > Get(i)) {/*Check += 4*/; return i;}
                //Check += 3;
                
                //Check += 3;
                if (Get(j) > Get(k))
                {
                    //Check += 4;
                    return j;
                }
                
                return k;
            }

            //Check += 3;
            if (Get(k) > Get(j))
            {
                //Check += 4;
                return j;
            }
            //Check += 4;
            return Get(i) > Get(k) ? i : k;
        }
        public void QuickSort(int start, int end)
        {
            //Check += 2;
            if (start < end)
            {
                //Check += 1;
                int p = FindPivot(start, (start + end )/ 2, end);
                //Check += 4;
                Swap(p, (start + end )/ 2);
                //Check += 3;
                int q = Partition(start, end);
                //Check += 2;
                //Check += 2;
                QuickSort(start, q);
                QuickSort(q + 1, end);
            }
        }
        
    }
}
//————————————————————————————————————————————————
  
using System;

namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {

            Sort queue = new Sort();

            var rnd = new Random();
            for (int i = 0; i < 300; ++i)
                queue.Enqueue(rnd.Next(-10, 10));
            queue.Print();
            Console.WriteLine("------------------\n");
            queue.QuickSort(0, queue.Count - 1);
            queue.Print();

        }

    }
}


