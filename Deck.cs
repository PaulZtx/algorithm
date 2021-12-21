using System;

namespace Deck
{
    public class Node
    {
        public int data;
        public Node next = null;
        public Node previous = null;
    }
    
    public class Deck
    {
        private Node Head;
        private Node Tail;
        protected int count;
        public int Check;

        public Deck()
        {
            count = 0;
            Head = null;
            Tail = null;
            Check = 0;
            Check += 3;
        }

        public void AddFirst(int value)
        {
            Check += 2;
            if (Head == null)
            {
                Head = new Node();
                Head.data = value;
                Tail = Head;
                Check += 6;
            }
            else
            {
                Node temp = Head;
                Head = new Node();
                Head.next = temp;
                Head.data = value;
                temp.previous = Head;
                Check += 10;
            }
            
            count++;
        }

        public void AddLast(int value)
        {
            Check += 2;
            if (Tail == null)
            {
                Tail = new Node();
                Tail.data = value;
                Head = Tail;
                Check += 6;
            }
            else
            {
                Node temp = Tail;
                Tail = new Node();
                Tail.previous = temp;
                Tail.data = value;
                temp.next = Tail;
                Check += 10;
            }
            
            count++;
        }

        public int PopLast()
        {
            
            if (IsEmpty())
                throw new NullReferenceException("Дек пуст!");
            int res = Tail.data;

            if (count == 1)
            {
                count--;
                return res;
            }

            Node temp = Tail.previous;
            

            Tail = temp;
            Tail.next = null;
            count--;
            return res;
        }

        public int PopFirst()
        {
            Check += 2;
            if (IsEmpty())
                throw new NullReferenceException("Дек пуст!");
            Check += 2;
            int res = Head.data;
            
            Check += 1;
            if (count == 1)
            {
                count--;
                Check += 2;
                return res;
            }
               
            
            Node temp = Head.next;
            Head = temp;
            Head.previous = null;
            count--;
            Check += 7;
            return res;
        }
        

        public void Print()
        {
            Node temp = Head;
            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }
            Console.WriteLine();
        }

        public int PeekFirst()  => !IsEmpty() ? Head.data : throw new Exception("Пусто");
        public int PeekLast() => !IsEmpty() ? Tail.data : throw new Exception("Пусто");

        public bool IsEmpty() => Head == null;

        public int Count
        {
            get => count;
        }
        public int Get(int position)
        {
            //Console.WriteLine(position);
            Check += 4;
            if (position < 0 || position > Count)
                throw new Exception("Иди нахуй с такими значениями");
            
            int size = Count;
            Check += 3;
            for (int i = 0; i < position; ++i)
            {
                AddLast(PopFirst());
                Check += 4;
            }

            int result = PeekFirst();
            Check += 2;

            for (int i = position; i < size; ++i)
            {
                AddLast(PopFirst());
                Check += 4;
            }

            return result;
        }

        public void Set(int position, int val)
        {
            //Console.WriteLine(position);
            Check += 5;
            if (position < 0 || position > Count)
                throw new Exception("Иди нахуй с такими значениями");
            
            int size = Count;
            Check += 3;
            for (int i = 0; i < position; ++i)
            {
                AddLast(PopFirst());
                Check += 4;
            }

            PopFirst();
            Check += 2;
            AddFirst(val);
            
            Check += 2;
            for (int i = position; i < size; ++i)
            {
                Check += 4;
                AddLast(PopFirst());
            }
        }

        public void Swap(int i, int j)
        {
            int temp = Get(i);
            Set(i, Get(j));
            Set(j, temp);
            Check += 7;
        }
        
        public int this[int position]
        {
            get => Get(position);
            set => Set(position, value);
        }
        
    }

    public class Sorting : Deck
    {
        private int Partition(int start, int end)
        {
            int x = Get((start + end) / 2);
            int i = start;
            int j = end;
            
            Check += 10;
            while (i <= j)
            {
                while (Get(j) > x){ --j; Check += 3;}
                while (Get(i) < x) {++i; Check += 3;}
                Check += 1;
                if(i >= j)
                    break;
                Swap(i++, j--);
                Check += 3;
            }
            Check += 1;
            return j;

        }

        public int FindPivot(int i, int j, int k)
        {
            Check += 3;
            if (Get(i) > Get(j))
            {
                Check += 3;
                if (Get(k) > Get(i)) {Check += 4; return i;}
                Check += 3;
                
                Check += 3;
                if (Get(j) > Get(k))
                {
                    Check += 4;
                    return j;
                }
                
                else return k;
            }

            Check += 3;
            if (Get(k) > Get(j))
            {
                Check += 4;
                return j;
            }
            Check += 4;
            return Get(i) > Get(k) ? i : k;
        }
        public void QuickSort(int start, int end)
        {
            Check += 2;
            if (start < end)
            {
                Check += 1;
                int p = FindPivot(start, (start + end )/ 2, end);
                Check += 4;
                Swap(p, (start + end )/ 2);
                Check += 3;
                int q = Partition(start, end);
                Check += 2;
                Check += 2;
                QuickSort(start, q);
                QuickSort(q + 1, end);
            }
        }
        
    }
}