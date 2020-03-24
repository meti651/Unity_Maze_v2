using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures.PriorityQueue
{
    public class PriorityQueue <T> where T :IComparable
    {
        private LinkedList<T> data;

        public PriorityQueue()
        {
            data = new LinkedList<T>();
        }

        public void Enqueue(T newData) {
            if(data.Count < 1)
            {
                data.AddFirst(newData);
                return;
            }
           
            T previousItem = data.First(item => newData.CompareTo(item) <= 0);
            if(previousItem != null)
            {
                data.AddBefore(data.Find(previousItem), newData);
                return;
            }
            data.AddLast(newData);
        }

        public T Dequeue()
        {
            T item = data.Last();
            data.RemoveLast();
            return item;
        }

        public int Count()
        {
            return data.Count;
        }

    }
}
