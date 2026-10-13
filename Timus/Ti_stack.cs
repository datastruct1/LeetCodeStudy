using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti_stack
    {
        public IList<string> BuildArray(int[] target, int n)
        {
            List<string> op = new List<string>();
            int j = 0;
            int len = target.Length;
            for (int i = 1; i <= n && j < len; i++)
            {
                if (target[j] == i)
                {
                    op.Add("Push");
                    j++;
                }
                else
                {
                    op.Add("Push");
                    op.Add("Pop");
                }

            }
            return op;
        }
        public int EvalRPN(string[] tokens)
        {
            var Stack = new MyStack<int>();
            foreach (var s in tokens)
            {
                if (s == "+" || s == "-" || s == "*" || s == "/")
                {
                    var a = Stack.Pop();
                    var b = Stack.Pop();
                    var res = s switch
                    {
                        "+" => b + a,
                        "-" => b - a,
                        "*" => b * a,
                        "/" => b / a,
                    };
                    Stack.Push(res);
                }
                else
                {
                    Stack.Push(int.Parse(s));
                }
            }
            return Stack.Pop();
        }
        public int[] ExclusiveTime(int n, IList<string> logs)
        {
            var Stack = new MyStack<int>();
            int preTime = 0;
            int[] res = new int[n];
            foreach (var l in logs)
            {
                string[] s = l.Split(":");
                int id = int.Parse(s[0]);
                string status = s[1];
                int time = int.Parse(s[2]);
                if (status == "start")
                {
                    if (Stack.Count > 0)
                        res[Stack.Peek()] += time - preTime;
                    Stack.Push(id);
                    preTime = time;
                }
                else
                {
                    res[Stack.Peek()] += time - preTime + 1;
                    Stack.Pop();
                    preTime = time + 1;
                }
            }
            return res;
        }

        public int[] FinalPrices(int[] prices)
        {
            int len = prices.Length;
            var stack = new MyStack<int>();
            for (int i = 0; i < len; i++)
            {
                while (stack.Count > 0 && prices[stack.Peek()] >= prices[i])
                {
                    int idx = stack.Pop();
                    prices[idx] = prices[idx] - prices[i];
                }
                stack.Push(i);
            }
            return prices;
        }
        public int[] DailyTemperatures(int[] temperatures)
        {
            int len = temperatures.Length;
            int[] res = new int[len];
            var stack = new MyStack<int>();
            for(int i = 0; i < len; i++)
            {
                while (stack.Count > 0 && temperatures[stack.Peek()] < temperatures[i])
                {
                    int idx = stack.Pop();
                    res[idx] = i - idx;
                }
                stack.Push(i);
            }
            return res;
        }
        public int LargestRectangleArea(int[] heights)
        {
            int square = 0;
            int len = heights.Length;
            var stack = new Stack<int>();
            for(int i = 0; i < len; i++)
            {
                while (stack.Count > 0 && heights[stack.Peek()] < heights[i])
                {

                }
            }
            return square;
        }
    }
    public class MyStack<T>
    {
        T[] data;
        int top;
        public int Count => top + 1;
        public bool IsEmpty => top == -1;
        public MyStack(int len = 10)
        {
            data = new T[len];
            top = -1;
        }
        public void Push(T item)
        {
            if (top + 1 == data.Length)
                Resize(data.Length * 2);
            top++;
            data[top] = item;
        }
        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("空");
            var a = data[top];
            top--;
            return a;
        }
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("空");
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
