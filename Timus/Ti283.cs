using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti283
    {
        public void MoveZeroes(int[] nums)
        {
            int n = nums.Length;
            int j = 0;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] != 0)
                {
                    int t = nums[i];
                    nums[i] = nums[j];
                    nums[j] = t;
                    j++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write(nums[i]);
            }
        }
        
    }

}
