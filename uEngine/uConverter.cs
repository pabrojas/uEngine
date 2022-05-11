using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine
{
    public class uConverter
    {

        static public uBounds<int> Parse( uBounds<double> worldBounds, 
            uViewport viewport, int windowWidth, int windowHeight )
        {

            double worldX = worldBounds.X - viewport.X;
            double worldY = worldBounds.Y - viewport.Y;

            int windowBoundsX = (int)((worldX * windowWidth) / viewport.Width);
            int windowBoundsWidth = (int)((worldBounds.Width * windowWidth) / viewport.Width);
            
            int windowBoundsY = (int)((worldY * windowHeight) / viewport.Height);
            int windowBoundsHeight = (int)((worldBounds.Height * windowHeight) / viewport.Height);

            uBounds<int> windowBounds = new uBounds<int>(windowBoundsX, 
                windowBoundsY, windowBoundsWidth, windowBoundsHeight);

            return windowBounds;
        }

    }
}
