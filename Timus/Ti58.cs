using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti58
    {
        public int LengthOfLastWord(string s)
        {
            int i = s.Length - 1;
            while (i >= 0 && s[i] == ' ')
                i--;
            int l = 0;
            while (i >= 0 && s[i] != ' ')
            {
                l++;
                i--;
            }
            return l;
        }
    }
}
