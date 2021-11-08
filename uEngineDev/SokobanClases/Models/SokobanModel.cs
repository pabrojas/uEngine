using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Models
{
    public class SokobanModel
    {
        private List<SokobanLevel> Levels;
        private int Index;

        public SokobanLevel Level { get { return Levels.Count == 0 ? null : Levels[Index]; } }
        
        public SokobanModel()
        {
            Levels = new List<SokobanLevel>();
            Index = 0;
        }

        public void Add(string filename)
        {
            SokobanLevel level = new SokobanLevel(filename);
            Levels.Add(level);
        }

        public void MoveUp()
        {
            Level?.MoveUp();
        }

        public void MoveDown()
        {
            Level?.MoveDown();
        }

        public void MoveLeft()
        {
            Level?.MoveLeft();
        }

        public void MoveRight()
        {
            Level?.MoveRight();
        }

        public void GoToNextLevel()
        {
            Index += 1;
            if (Index >= Levels.Count)
            {
                Index = Levels.Count - 1;
            }
        }
    }
}
