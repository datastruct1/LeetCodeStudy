using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti13
    {
        public int RomanToInt(string s)
        {
            Dictionary<char, int> map = new()
            {
                ['I'] = 1,
                ['V'] = 5,
                ['X'] = 10,
                ['L'] = 50,
                ['C'] = 100,
                ['D'] = 500,
                ['M'] = 1000,
            };
            int n = s.Length;
            int num = 0;
            int cur = 0;
            for (int i = 0; i < n; i++)
            {
                cur = map[s[i]];
                if (i < n - 1 && cur < map[s[i + 1]])
                    num -= cur;
                else
                    num += cur;
            }
            return num;
        }
    }
}
