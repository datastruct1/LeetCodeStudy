using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti682
    {
        public int CalPoints(string[] operations)
        {
            int n = operations.Length;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                if (operations[i] == "+" || operations[i] == "D" || operations[i] == "C")
                {
                    switch (operations[i])
                    {
                        case "+":
                            int a = stack.Pop();
                            int b = stack.Pop();
                            int c = a + b;
                            stack.Push(b);
                            stack.Push(a);
                            stack.Push(c);
                            break;
                        case "D":
                            int d = stack.Pop();
                            int e = d * 2;
                            stack.Push(d);
                            stack.Push(e);
                            break;
                        case "C":
                            int f = stack.Pop();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    int sign = 1;
                    int j = 0;
                    int num = 0;
                    if (operations[i][0] == '-')
                    {
                        sign = -1;
                        j = 1;
                    }
                    else
                        sign = 1;
                    for (; j < operations[i].Length;j++)
                        num = num * 10 + (operations[i][j] - '0');
                    stack.Push(num * sign);
                }
            }
            int sum = 0;
            while (stack.Count > 0)
            {
                sum += stack.Pop();
            }
            return sum;
        }
    }
}
