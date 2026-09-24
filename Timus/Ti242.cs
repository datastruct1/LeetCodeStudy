using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti242
    {
        public bool IsAnagram(string s, string t)
        {
            int n = 10000;
            if (s.Length != t.Length)
                return false;
            int[] cnt = new int[n];
            foreach (char c in s)
                cnt[c - '\0']++;
            foreach (char c in t)
            {
                cnt[c - '\0']--;
                if (cnt[c - '\0'] < 0)
                    return false;
            }
            return true;
        }
    }
}
