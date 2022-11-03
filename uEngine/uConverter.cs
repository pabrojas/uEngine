using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine
{
    public class uConverter
    {
        static public uBounds<int> Parse(uBounds<float> worldBounds)
        {
            uBounds<float> viewport = uGame.Viewport;
            int windowWidth = uGame.WindowWidth;
            int windowHeight = uGame.WindowHeight;

            float worldX = worldBounds.X - viewport.X;
            float worldY = worldBounds.Y - viewport.Y;

            int windowBoundsX = (int)Math.Round((worldX * windowWidth) / viewport.Width);
            int windowBoundsWidth = (int)Math.Round((worldBounds.Width * windowWidth) / viewport.Width);

            int windowBoundsY = (int)Math.Round((worldY * windowHeight) / viewport.Height);
            int windowBoundsHeight = (int)Math.Round((worldBounds.Height * windowHeight) / viewport.Height);

            uBounds<int> windowBounds = new uBounds<int>(windowBoundsX,
                windowBoundsY, windowBoundsWidth, windowBoundsHeight);

            return windowBounds;
        }
    }
}
