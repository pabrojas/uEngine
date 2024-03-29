﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine;

namespace Breakout
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Cargo mis recursos externos
            uImagePool.Load("paddleBlu.png", "PlayerPad");
            uImagePool.Load("element_blue_rectangle.png", "BrickBlue");
            uImagePool.Load("element_red_rectangle.png", "BrickRed");



            BreakoutGame game = new BreakoutGame(1024, 768, 60);
            game.Start();

            Application.Run();
        }
    }
}
