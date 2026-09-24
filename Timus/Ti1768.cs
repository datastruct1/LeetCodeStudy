using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti1768
    {
        public string MergeAlternately(string word1, string word2)
        {
            int max = Math.Max(word1.Length, word2.Length);
            var sb = new StringBuilder();
            for (int i = 0; i < max; i++)
            {
                if (i < word1.Length)
                    sb.Append(word1[i]);
                if (i < word2.Length)
                    sb.Append(word2[i]);

            }
            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }


    }
}
