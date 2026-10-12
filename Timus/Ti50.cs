using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti50
    {
        //x^n
        //递归法
        public double MyPow(double x, int n)
        {
            long N = n;
            if (N == 0) return 1;
            if (N < 0)
            {
                x = 1 / x;
                N = -N;
            }
            return Pow(x, N);
        }
        private double Pow(double x, long N)
        {
            if (N == 0) return 1;
            double half = Pow(x, N / 2);
            if (N % 2 == 0)
                return half * half;
            else
                return half * half * x;
        }
        //迭代法
        public double Power(double x, int n)
        {
            long N = n;
            if (N < 0)
            {
                N = -N;
                x = 1 / x;
            }
            double res = 1;
            double cur = x;
            while (N > 0)
            {
                if (N % 2 != 0)
                    res = res * cur;
                cur *= cur;
                N /= 2;
            }

            return res;
        }
    }
}
