using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti54
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            List<int> list = new List<int>();
            int m = matrix.Length;
            int n = matrix[0].Length;
            int top = 0;
            int left = 0;
            int bottom = m - 1;
            int right = n - 1;

            while (left <= right && top <= bottom)
            {
                for (int j = left; j <= right; j++)
                    list.Add(matrix[top][j]);
                top++;
                for (int i = top; i <= bottom; i++)
                    list.Add(matrix[i][right]);
                right--;
                if (top <= bottom)
                {
                    for (int j = right; j >= left; j--)
                        list.Add(matrix[bottom][j]);
                    bottom--;
                }
                if (left <= right)
                {
                    for (int i = bottom; i >= top; i--)
                        list.Add(matrix[i][left]);
                    left++;
                }


            }
            foreach (int num in list)
                Console.Write($"{num}->");
            return list;
        }
    }
}
