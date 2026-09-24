using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti389
    {
        public char FindTheDifference(string s, string t)
        {
            char res = '\0';
            foreach (char c in s)
                res ^= c;
            foreach (char c in t)
                res ^= c;
            Console.WriteLine($"'{res}'是那个被添加的字母。");
            return res;
        }
    }
}
