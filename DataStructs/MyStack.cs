using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.DataStructs
{
    //栈--数组实现
    public class MyStack<T>
    {
        T[] data;
        int top;
        public int Count => top + 1;
        public bool IsEmpty => top == -1;
        public MyStack(int Capcity = 10)
        {
            data = new T[Capcity];
            top = -1;
        }
        public void Push(T item)
        {
            if (Count == data.Length)
                Resize(2 * data.Length);
            data[top] = item;
            top++;
        }
        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("栈为空");
            var a = data[top];
            top--;
            return a;
        }
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("栈为空");
            return data[top];
        }
        private void Resize(int newCapacity)
        {
            T[] newData = new T[newCapacity];
            Array.Copy(data, newData, top + 1);
            data = newData;
        }
    }
}