using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti709
    {
        public string ToLowerCase(string s)
        {
            int n = s.Length;
            char[] cs = new char[n];
            for(int i = 0; i < n; i++)
            {
                cs[i] = s[i];
                if (cs[i] >='A' && cs[i]<='Z')
                    cs[i] = (char)(cs[i] + 32);
            }
            return new string(cs);
        }
    }
}
