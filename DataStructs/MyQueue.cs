using System;
using System.Collections.Generic;
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
            if(IsFull)
            {

            }
            data[tail] = item;
            tail++;
        }
    }
}
