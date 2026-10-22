using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.DataStructs
{
    public class MyQueue<T>
    {
        T[] data;
        int head;
        int tail;
        public int Count => tail - head + 1;
        public bool IsEmpty => tail - head + 1 == 0;
        public bool IsFull => tail - head + 1 == data.Length;
        public MyQueue(int Capcity = 10)
        {
            data = new T[Capcity];
            head = 0;
            tail = 0;
        }
        public void Enqueue(T item)
        {
            if (IsFull)
                Resize(2 * data.Length);
            data[tail] = item;
            tail = (tail + 1) % data.Length;
        }
        public T Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("队空");
            var a = data[head];
            head = (head + 1) % data.Length;
            return a;
        }
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("队空");
            return data[head];
        }
        private void Resize(int newCapcity)
        {
            T[] newData = new T[newCapcity];
            for(int i = 0; i < newCapcity; i++)
                newData[i] = data[(head + i) % data.Length];
            head = 0;
            data = newData;
            tail = Count;
        }
    }
}
