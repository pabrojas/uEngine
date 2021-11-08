using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine
{
    public interface IScene
    {
        void ProcessInput(int deltaTime);
        void GameUpdate(int deltaTime);
        void Render(Graphics g, int deltaTime);

        bool IsAlive();
        IScene Next();


    }
}
