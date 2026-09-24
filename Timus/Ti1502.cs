using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti1502
    {
        public bool CanMakeArithmeticProgression(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j + 1] < arr[j])
                    {
                        int temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            for (int i = 1; i < n - 1; i++)
            {
                if (arr[i + 1] - arr[i] != arr[i] - arr[i - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
