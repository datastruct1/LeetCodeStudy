using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti66
    {
        public int[] PlusOne(int[] digits)
        {
            int n = digits.Length;
            for(int i = n - 1; i >= 0; i--)
            {
                if(digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }
                digits[i] = 0;
            }
            int[] res = new int[digits.Length + 1];
            res[0] = 1;
            return res;
        }
    }
}
