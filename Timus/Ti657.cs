using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti657
    {
        public bool JudgeCircle(string moves)
        {
            (int x, int y) point = (0, 0);
            int n = moves.Length;
            for(int i = 0; i < n; i++)
            {
                switch(moves[i])
                {
                    case 'U':
                        point.y++;
                        break;
                    case 'D':
                        point.y--;
                        break;
                    case 'R':
                        point.x++;
                        break;
                    case 'L':
                        point.x--;
                        break;
                }
            }
            return point == (0, 0);
        }
    }
}
