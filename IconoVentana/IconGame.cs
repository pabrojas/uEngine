
using uEngine;

namespace IconoVentana
{
    public class IconGame : uGame
    {
        public IconGame(uViewport viewport, int windowWidth, int windowHeight, int targetFPS) : base(viewport, windowWidth, windowHeight, targetFPS)
        {
            SetIcon(uImageManager.Get("icono"));
        }

        public override void GameUpdate(int DeltaTime)
        {
        }

        public override void ProcessInput()
        {
        }
    }
}