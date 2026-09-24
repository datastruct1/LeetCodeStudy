using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti1523
    {
        public int CountOdds(int low, int high)
        {
            return (high + 1) / 2 - low / 2;
        }
    }
}
