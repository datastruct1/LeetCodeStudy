using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti43
    {
        public string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0") return "0";
            int m = num1.Length;
            int n = num2.Length;
            int[] res = new int[m + n];

            for (int i = m - 1; i >= 0; i--)
            {
                int x1 = num1[i] - '0';
                for (int j = n - 1; j >= 0; j--)
                {
                    int x2 = num2[j] - '0';
                    int c = x1 * x2;
                    int pos = i + j + 1;
                    res[pos] += c;

                    res[pos - 1] += res[pos] / 10;
                    res[pos] %= 10;
                }
            }
            StringBuilder num = new StringBuilder();
            foreach (int i in res)
            {
                if (num.Length == 0 && i == 0)
                    continue;
                num.Append(i);
            }

            return num.Length == 0 ? "0" : num.ToString();
        }
    }
}
