using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti1822
    {
        public int ArraySign(int[] nums)
        {
            int n = nums.Length;
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] < 0)
                    count++;
                if (nums[i] == 0)
                    return 0;
            }
            if (count % 2 != 0)
                return -1;
            else 
                return 1;
        }
    }
}
