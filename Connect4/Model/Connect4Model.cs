using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4.Model
{
    public class Connect4Model
    {
        private Token[,] Board;

        public Connect4Model()
        {
            Board = new Token[6, 7];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Board[i, j] = Token.Empty;
                }
            }
        }

        public Token Get(int row, int col)
        {
            return Board[row, col];
        }

        public bool HasAvailableSpace(int column)
        {
            for (int i = 5; i >= 0; i--)
            {
                if (Board[i, column] == Token.Empty)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetFreeRow(int column)
        {
            for (int i = 5; i >= 0; i--)
            {
                if (Board[i, column] == Token.Empty)
                {
                    return i;
                }
            }
            return -1;
        }



        public void Drop(Token token, int column)
        {
            for (int i = 5; i >= 0; i--)
            {
                if(Board[i, column] == Token.Empty)
                {
                    Board[i, column] = token;
                    return;
                }
            }
        }
    }
}
