using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti860
    {
        public bool LemonadeChange(int[] bills)
        {
            int[] changes = new int[2];
            //[5,5,5,10,20]
            foreach (int bill in bills)
            {
                if (bill == 5)
                    changes[0]++;
                if (bill == 10)
                {
                    if (changes[0] == 0)
                        return false;
                    else
                    {
                        changes[0]--;
                        changes[1]++;
                    }

                }
                if (bill == 20)
                {
                    if (changes[0] > 0 && changes[1] > 0)
                    {
                        changes[0]--;
                        changes[1]--;
                    }
                    else if (changes[0] >= 3)
                        changes[0] -= 3;
                    else
                        return false;

                }
            }
            return true;
        }
    }
}
