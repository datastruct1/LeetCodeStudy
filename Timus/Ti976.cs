using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti976
    {
        public int LargestPerimeter(int[] nums)
        {
            int len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len - i - 1; j++)
                {
                    if (nums[j + 1] > nums[j])
                    {
                        int index = nums[j + 1];
                        nums[j + 1] = nums[j];
                        nums[j] = index;
                    }
                }
            }
            for (int i = 0; i < len - 2; i++)
            {
                int a = nums[i];
                int b = nums[i + 1];
                int c = nums[i + 2];
                if (b + c > a)
                    return a + b + c;
            }
            return 0;
        }

    }
}
