using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti28
    {
        //暴力法
        public int StrStr(string haystack, string needle)
        {
            int n = needle.Length;
            for (int i = 0; i < haystack.Length - n + 1; i++)
            {
                var s = haystack.Substring(i, n);

                if (s.Equals(needle))
                {
                    Console.WriteLine(i);
                    return i;
                }
            }
            Console.WriteLine(-1);
            return -1;
        }
        //kmp法
        public int StrStrKmp(string haystack, string needle)
        {
            int m = haystack.Length;
            int n = needle.Length;
            if (n == 0)
            {
                Console.WriteLine(-1);
                return 0;
            }
            int[] next = new int[n];
            for (int i = 1, j = 0; i < n; i++)
            {

                while (j > 0 && needle[i] != needle[j])
                {
                    j = next[j - 1];
                }
                if (needle[i] == needle[j])
                    j++;
                next[i] = j;
            }
            for (int i = 0, j = 0; i < m; i++)
            {
                while (j > 0 && haystack[i] != needle[j])
                    j = next[j - 1];

                if (haystack[i] == needle[j])
                    j++;
                if (j == n)
                {
                    
                    return i - j + 1;
                }
            }


            return -1;
        }
    }
}
