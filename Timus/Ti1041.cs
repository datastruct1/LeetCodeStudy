using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti1041
    {
        public bool IsRobotBounded(string instructions)
        {
            char[] forward = new char[4] { 'N', 'E', 'S', 'W' };
            (int x, int y) robot = (0, 0);
            int index = 0;
            foreach (var i in instructions)
            {
                switch (i)
                {
                    case 'G':
                        if (index == 0)
                            robot.y++;
                        if (index == 1)
                            robot.x++;
                        if (index == 2)
                            robot.y--;
                        if (index == 3)
                            robot.x--;
                        break;
                    case 'L':
                        index = (index + 3) % 4;
                        break;
                    case 'R':
                        index = (index + 1) % 4;
                        break;
                }
            }
            return robot == (0, 0) || index != 0;
        }

    }
}
