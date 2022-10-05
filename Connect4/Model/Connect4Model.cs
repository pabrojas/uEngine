using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
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

            Drop(Token.Yellow, 0);
            Drop(Token.Yellow, 0);
            Drop(Token.Yellow, 0);
            Drop(Token.Red, 0);

            Drop(Token.Yellow, 1);
            Drop(Token.Yellow, 1);
            Drop(Token.Red, 1);

            Drop(Token.Yellow, 2);
            Drop(Token.Red, 2);




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

        public bool IsFull()
        {
            for (int i = 0; i < 7; i++)
            {
                if( HasAvailableSpace(i) == true )
                {
                    return false;
                }
            }
            return true;
        }

        public bool hasWon(int row, int col)
        {
            int horizontal = CalculateHorizontal(row, col);
            int vertical = CalculateVertical(row, col);
            int diagonal1 = CalculatePositiveDiagonal(row, col);
            int diagonal2 = CalculateNegativeDiagonal(row, col);

            return (horizontal >= 4 || vertical >= 4 || diagonal1 >= 4 || diagonal2 >= 4);
        }

        public int CalculateHorizontal(int row, int col)
        {
            Token token = Board[row, col];
            int total = 1;
            
            int j = 1;
            while (col + j < 7 && Board[row, col + j] == token)
            {
                total++;
                j++;
            }

            j = 1;
            while (col - j >= 0 && Board[row, col - j] == token)
            {
                total++;
                j++;
            }

            return total;
        }

        public int CalculateVertical(int row, int col)
        {
            Token token = Board[row, col];
            int total = 1;
            
            int i = 1;
            while (row + i < 6 && Board[row + i, col] == token)
            {
                total++;
                i++;
            }

            i = 1;
            while (row - i >= 0 && Board[row - i, col] == token)
            {
                total++;
                i++;
            }

            return total;
        }

        private int CalculateNegativeDiagonal(int row, int col)
        {
            Token token = Board[row, col];
            int total = 1;
            int i, j;

            i = 1;
            j = 1;
            while (row + i < 6 && col + j < 7 && Board[row + i, col + j] == token)
            {
                total++;
                i++;
                j++;
            }

            i = 1;
            j = 1;
            while (row - i >= 0 && col - j >= 0 && Board[row - i, col - j] == token)
            {
                total++;
                i++;
                j++;
            }

            return total;
        }

        private int CalculatePositiveDiagonal(int row, int col)
        {
            Token token = Board[row, col];
            int total = 1;
            int i, j;

            i = 1;
            j = 1;
            while (row + i < 6 && col - j > 0 && Board[row + i, col - j] == token)
            {
                total++;
                i++;
                j++;
            }

            i = 1;
            j = 1;
            while (row - i > 0 && col + j < 7 && Board[row - i, col + j] == token)
            {
                total++;
                i++;
                j++;
            }

            return total;
        }

        public void Glow(int row, int col)
        {
            int horizontal = CalculateHorizontal(row, col);
            int vertical = CalculateVertical(row, col);
            int diagonal1 = CalculatePositiveDiagonal(row, col);
            int diagonal2 = CalculateNegativeDiagonal(row, col);

            if (horizontal >= 4)
            {
                GlowHorizontal(row, col);
            }
            else if (vertical >= 4)
            {
                GlowVertical(row, col);
            }
            else if (diagonal1 >= 4)
            {
                GlowPositiveDiagonal(row, col);
            }
            else if (diagonal2 >= 4)
            {
                GlowNegativeDiagonal(row, col);
            }
        }

        public void GlowHorizontal(int row, int col)
        {
            Token token = Board[row, col];
            Board[row, col] = Token.Glow;

            int j = 1;
            while (col + j < 7 && Board[row, col + j] == token)
            {
                Board[row, col + j] = Token.Glow;
                j++;
            }

            j = 1;
            while (col - j >= 0 && Board[row, col - j] == token)
            {
                Board[row, col - j] = Token.Glow;
                j++;
            }
        }

        public void GlowVertical(int row, int col)
        {
            Token token = Board[row, col];
            Board[row, col] = Token.Glow;

            int i = 1;
            while (row + i < 6 && Board[row + i, col] == token)
            {
                Board[row + i, col] = Token.Glow;
                i++;
            }

            i = 1;
            while (row - i >= 0 && Board[row - i, col] == token)
            {
                Board[row - i, col] = Token.Glow;
                i++;
            }
        }

        private void GlowNegativeDiagonal(int row, int col)
        {
            Token token = Board[row, col];
            Board[row, col] = Token.Glow;
            int i, j;

            i = 1;
            j = 1;
            while (row + i < 6 && col + j < 7 && Board[row + i, col + j] == token)
            {
                Board[row + i, col + j] = Token.Glow;
                i++;
                j++;
            }

            i = 1;
            j = 1;
            while (row - i >= 0 && col - j >= 0 && Board[row - i, col - j] == token)
            {
                Board[row - i, col - j] = Token.Glow;
                i++;
                j++;
            }
        }

        private void GlowPositiveDiagonal(int row, int col)
        {
            Token token = Board[row, col];
            Board[row, col] = Token.Glow;

            int i, j;

            i = 1;
            j = 1;
            while (row + i < 6 && col - j > 0 && Board[row + i, col - j] == token)
            {
                Board[row + i, col - j] = Token.Glow;
                i++;
                j++;
            }

            i = 1;
            j = 1;
            while (row - i > 0 && col + j < 7 && Board[row - i, col + j] == token)
            {
                Board[row - i, col + j] = Token.Glow;
                i++;
                j++;
            }
        }
    }
}
