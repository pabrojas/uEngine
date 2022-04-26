using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine;
using Selector.Scenes;

namespace Selector
{
    public class SelectorGame : uGame
    {
        SelectionScene ss; //0
        Escena1 e1; //1
        Escena2 e2; //2
        Escena3 e3; //3

        private int id;


        public SelectorGame(int windowWidth, int windowHeight, int targetFPS) : base(windowWidth, windowHeight, targetFPS)
        {
            id = 0;

            ss = new SelectionScene();
            e1 = new Escena1();
            e2 = new Escena2();
            e3 = new Escena3();
        }

        public override void GameUpdate()
        {
            switch (id)
            {
                case 0: 
                    ss.GameUpdate(); 
                    if(ss.isEnded())
                    {
                        id = ss.getSelection() + 1;
                        ss.Initialize();
                    }
                    
                    break;
                case 1: 
                    e1.GameUpdate(); 
                    if( e1.isEnded() )
                    {
                        id = 0;
                        e1.Initialize();
                    }
                    break;
                case 2: 
                    e2.GameUpdate();
                    if (e2.isEnded())
                    {
                        id = 0;
                        e2.Initialize();
                    }
                    break;
                case 3: 
                    e3.GameUpdate();
                    if (e3.isEnded())
                    {
                        id = 0;
                        e3.Initialize();
                    }
                    break;
            }
        }

        public override void ProcessInput()
        {
            switch (id)
            {
                case 0: ss.ProcessInput(); break;
                case 1: e1.ProcessInput(); break;
                case 2: e2.ProcessInput(); break;
                case 3: e3.ProcessInput(); break;
            }
        }

        public override void Render(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, 1024, 738);

            
            switch (id)
            {
                case 0: ss.Render(g); break;
                case 1: e1.Render(g); break;
                case 2: e2.Render(g); break;
                case 3: e3.Render(g); break;
            }
        }
    }
}
