using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti896
    {
        public bool IsMonotonic(int[] nums)
        {
            int n = nums.Length;
            int count1 = 0;
            int count2 = 0;
            for (int i = 0; i < n - 1; i++)
            {
                if (nums[i + 1] >= nums[i])
                    count1++;
                if (nums[i + 1] <= nums[i])
                    count2++;
            }
            if (count1 == n - 1 || count2 == n - 1)
                return true;
            return false;
        }
    }

}
