using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti1672
    {
        public int MaximumWealth(int[][] accounts)
        {
            int n = accounts.Length;
            int[] sum = new int[n];
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                foreach (int w in accounts[i])
                {
                    sum[i] += w;
                    if (sum[i] > max)
                        max = sum[i];
                }
            }

            return max;
        }
    }
}
