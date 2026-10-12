using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti_shuzu
    {

        //探险模式--数组I
        public int[] GetConcatenation(int[] nums)
        {
            int len1 = nums.Length;
            int len2 = len1 * 2;
            int[] res = new int[len2];
            for (int i = 0; i < len2; i++)
            {
                if (i < len1)
                    res[i] = nums[i];
                if (i >= len1)
                    res[i] = nums[i - len1];
            }
            return res;
        }
        public int[] Shuffle(int[] nums, int n)
        {
            int len = nums.Length;
            int[] res = new int[len];
            int i = 0;
            int j = n;
            while (i < len / 2)
            {
                res[2 * i] = nums[i];
                res[2 * i + 1] = nums[j];
                i++;
                j++;
            }
            return res;
        }
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int len = nums.Length;
            int count = 0;
            int res = 0;
            for (int i = 0; i < len; i++)
            {
                if (nums[i] == 1)
                    count++;
                if (nums[i] == 0 || i == len - 1)
                {
                    if (res < count)
                        res = count;
                    count = 0;
                }
            }
            return res;
        }

        //探险模式--数组II
        public int[] FindErrorNums(int[] nums)
        {
            int len = nums.Length;
            int[] count = new int[len + 1];
            int error = 0;
            int miss = 0;
            foreach (int x in nums)
                count[x]++;
            for (int i = 1; i <= len; i++)
            {
                if (count[i] == 2)
                    error = i;
                if (count[i] == 0)
                    miss = i;
            }
            return [error, miss];
        }
        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            int len = nums.Length;
            int[] count = new int[len];
            for (int i = 0; i < len; i++)
            {
                int cur = nums[i];
                for (int j = 0; j < len; j++)
                {
                    if (cur > nums[j])
                        count[i]++;
                }
            }
            return count;
        }
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            int len = nums.Length;
            int[] count = new int[len + 1];
            List<int> dis = new List<int>();
            foreach (int x in nums)
                count[x] = x;
            for(int i = 1; i < len + 1; i++)
                if (count[i] == 0)
                    dis.Add(i);
            return dis;
        }
    }
}
