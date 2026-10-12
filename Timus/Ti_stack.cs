using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti_stack
    {
        public IList<string> BuildArray(int[] target, int n)
        {
            List<string> op = new List<string>();
            int j = 0;
            int len = target.Length;
            for (int i = 1; i <= n && j < len; i++)
            {
                if (target[j] == i)
                {
                    op.Add("Push");
                    j++;
                }
                else
                {
                    op.Add("Push");
                    op.Add("Pop");
                }

            }

            return op;
        }
    }
}
