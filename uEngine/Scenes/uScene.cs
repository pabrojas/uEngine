﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine
{
    public interface uScene
    {
        void ProcessInputs();
        void GameUpdate(int DeltaTime);
        void Render(Graphics g);
    }
}
