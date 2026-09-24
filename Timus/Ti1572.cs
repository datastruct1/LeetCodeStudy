using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti1572
    {
        public int DiagonalSum(int[][] mat)
        {
            int l = mat.Length;
            int sum = 0;
            for (int i = 0; i < l; i++)
            {
                sum = sum + mat[i][i];
                if (i != l - i - 1)
                    sum += mat[i][l - i - 1];
            }

            return sum;
        }
    }
}
