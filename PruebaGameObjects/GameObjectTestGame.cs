using uEngine;

namespace PruebaGameObjects
{
    public class GameObjectTestGame : uGame
    {
        GameObjectTestScene scene;
        public GameObjectTestGame(uViewport viewport, int windowWidth, int windowHeight, int targetFPS) : base(viewport, windowWidth, windowHeight, targetFPS)
        {
            scene = new GameObjectTestScene(this);
            CurrentScene = scene;
        }

        public override void ProcessInput()
        {
            scene.ProcessInput();
        }

        public override void GameUpdate(int DeltaTime)
        {
            base.GameUpdate(DeltaTime);
            scene.GameUpdate(DeltaTime);
        }
    }
}