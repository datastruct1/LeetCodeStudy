using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti1491
    {
        public double Average(int[] salary)
        {
            double max = int.MinValue;
            double min = int.MaxValue;
            double sum = 0;
            foreach (int s in salary)
            {
                if (s > max)
                    max = s;
                if (s < min)
                    min = s;
                sum += s;
            }
            double ave = (sum - max - min) / (salary.Length - 2);
            return ave;
        }
    }
}
