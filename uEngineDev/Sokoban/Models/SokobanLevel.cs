using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Models
{
    public class SokobanLevel
    {
        public enum Tile { None = 0, Wall = 1, Floor = 2, Box = 3 }

        public int Rows { private set; get; }
        public int Cols { private set; get; }
        public int PlayerRow { private set; get; }
        public int PlayerCol { private set; get; }

        public Tile[,] Board { private set; get; }
        public bool[,] Goals { private set; get; }

        public SokobanLevel(string filename)
        {
            LoadLevelFromFile(filename);
        }

        private void LoadLevelFromFile(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            string[] numbers;

            //First line contains (Rows, Cols)
            numbers = lines[0].Split(' ');
            Rows = int.Parse(numbers[0]);
            Cols = int.Parse(numbers[1]);
            Board = new Tile[Rows, Cols];
            Goals = new bool[Rows, Cols];

            //Second line contains (PlayerRow, PlayerCol)
            numbers = lines[1].Split(' ');
            PlayerRow = int.Parse(numbers[0]);
            PlayerCol = int.Parse(numbers[1]);

            //Next (Rows) lines contains (Cols) numbers that represent level info
            //0 -> None, 1 -> Wall, 2 -> Floor, 3 -> Box
            for (int i = 0; i < Rows; i++ )
            {
                numbers = lines[i + 2].Split(' ');
                for (int j = 0; j < Cols; j++)
                {
                    int tile = int.Parse(numbers[j]);
                    /*
                    switch(tile)
                    {
                        case 1: Board[i, j] = Tile.Wall; break;
                        case 2: Board[i, j] = Tile.Floor; break;
                        case 3: Board[i, j] = Tile.Box; break;
                        default: Board[i, j] = Tile.None; break;
                    }
                    */
                    Board[i, j] = (Tile)Enum.ToObject(typeof(Tile), tile);
                }
            }

            //Next (Rows) lines contains (Cols) numbers that represent Goal information
            //0 -> no goal, 1 -> goal
            for (int i = 0; i < Rows; i++)
            {
                numbers = lines[i + Rows + 2].Split(' ');
                for (int j = 0; j < Cols; j++)
                {
                    int goal = int.Parse(numbers[j]);
                    Goals[i, j] = (goal == 1);
                }
            }
        }

        public bool IsComplete()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if( Goals[i, j] == true && Board[i, j] != Tile.Box )
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void MoveUp()
        {
            if (PlayerRow - 1 >= 0)
            {
                if (Board[PlayerRow - 1, PlayerCol] == Tile.Floor)
                {
                    PlayerRow--;
                }
                else if (Board[PlayerRow - 1, PlayerCol] == Tile.Box)
                {
                    if (PlayerRow - 2 >= 0)
                    {
                        if (Board[PlayerRow - 2, PlayerCol] == Tile.Floor)
                        {
                            Board[PlayerRow - 1, PlayerCol] = Tile.Floor;
                            Board[PlayerRow - 2, PlayerCol] = Tile.Box;
                            PlayerRow--;
                        }
                    }
                }
            }
        }

        public void MoveDown()
        {
            if (PlayerRow + 1 < Rows)
            {
                if (Board[PlayerRow + 1, PlayerCol] == Tile.Floor)
                {
                    PlayerRow++;
                }
                else if(Board[PlayerRow + 1, PlayerCol] == Tile.Box)
                {
                    if( PlayerRow + 2 < Rows )
                    {
                        if (Board[PlayerRow + 2, PlayerCol] == Tile.Floor)
                        {
                            Board[PlayerRow + 1, PlayerCol] = Tile.Floor;
                            Board[PlayerRow + 2, PlayerCol] = Tile.Box;
                            PlayerRow++;
                        }
                    }
                }

            }
        }

        public void MoveLeft()
        {
            if( PlayerCol - 1 >= 0 )
            {
                if( Board[PlayerRow, PlayerCol - 1] == Tile.Floor )
                {
                    PlayerCol--;
                }
                else if (Board[PlayerRow, PlayerCol - 1] == Tile.Box)
                {
                    if (PlayerCol - 2 >= 0)
                    {
                        if (Board[PlayerRow, PlayerCol - 2] == Tile.Floor)
                        {
                            Board[PlayerRow, PlayerCol - 1] = Tile.Floor;
                            Board[PlayerRow, PlayerCol - 2] = Tile.Box;
                            PlayerCol--;
                        }
                    }
                }
            }
        }

        public void MoveRight()
        {
            if (PlayerCol + 1 < Cols)
            {
                if (Board[PlayerRow, PlayerCol + 1] == Tile.Floor)
                {
                    PlayerCol++;
                }
                else if (Board[PlayerRow, PlayerCol + 1] == Tile.Box)
                {
                    if (PlayerCol + 2 < Cols)
                    {
                        if (Board[PlayerRow, PlayerCol + 2] == Tile.Floor)
                        {
                            Board[PlayerRow, PlayerCol + 1] = Tile.Floor;
                            Board[PlayerRow, PlayerCol + 2] = Tile.Box;
                            PlayerCol++;
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            string representation = "";

            representation += "Total Rows: " + Rows + Environment.NewLine;
            representation += "Total Cols: " + Rows + Environment.NewLine;
            representation += "Player Row: " + PlayerRow + Environment.NewLine;
            representation += "Player Col: " + PlayerCol + Environment.NewLine;
            representation += "Board" + Environment.NewLine;
            for (int i = 0; i < Rows; i++)
            {
                representation += "\t";
                for (int j = 0; j < Cols; j++)
                {
                    representation += (int)Board[i, j] + " ";
                }
                representation += Environment.NewLine;
            }
            representation += "Goals" + Environment.NewLine;
            for (int i = 0; i < Rows; i++)
            {
                representation += "\t";
                for (int j = 0; j < Cols; j++)
                {
                    representation += (Goals[i, j] ? "1" : "0") + " ";
                }
                representation += Environment.NewLine;
            }

            return representation;
        }
        

    }
}
