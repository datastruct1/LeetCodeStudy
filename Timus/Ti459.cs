using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti459
    {
        public bool RepeatedSubstringPattern(string s)
        {
            //abab
            int n = s.Length;
            int[] next = new int[n];
            for(int i = 1, j = 0; i < n; i++)
            {
                while (j > 0 && s[i] != s[j])
                    j = next[j - 1];
                if (s[i] == s[j])
                    j++;   
                next[i] = j;
            }
            int len = next[n - 1];
            if (len == 0) 
                return false;
            int period = n - len;
            if (n % period == 0)
                return true;
            return false;
        }
    }
}
