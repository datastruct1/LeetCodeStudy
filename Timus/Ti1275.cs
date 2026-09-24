using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.Timus
{
    public class Ti1275
    {
        public string Tictactoe(int[][] moves)
        {
            int[] rows = new int[3];
            int[] cols = new int[3];
            int diag1 = 0, diag2 = 0;
            int n = moves.Length;
            for (int i = 0; i < n; i++)
            {
                int r = moves[i][0];
                int c = moves[i][1];
                int player = (i % 2 == 0) ? 1 : -1;
                rows[r] += player;
                cols[c] += player;
                if (r == c) diag1 += player;
                if (r + c == 2) diag2 += player;
                if (Math.Abs(rows[r]) == 3 ||
                    Math.Abs(cols[c]) == 3 ||
                    Math.Abs(diag1) == 3 ||
                    Math.Abs(diag2) == 3)
                {
                    return player == 1 ? "A" : "B";
                }
            }

            return moves.Length == 9 ? "Draw" : "Pending";
        }
    }
}
