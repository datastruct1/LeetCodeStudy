using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti1232
    {
        public bool CheckStraightLine(int[][] coordinates)
        {
            int x1 = coordinates[0][0];
            int y1 = coordinates[0][1];
            int x2 = coordinates[1][0];
            int y2 = coordinates[1][1];
            int dx = x2 - x1;
            int dy = y2 - y1;
            int len = coordinates.Length;
            for(int i = 2; i < len; i++)
            {
                int x = coordinates[i][0];
                int y = coordinates[i][1];
                int vx = x - x1;
                int vy = y - y1;
                if (dx * vy != dy * vx)
                    return false;
            }
       
            return true;
        }
    }
}
