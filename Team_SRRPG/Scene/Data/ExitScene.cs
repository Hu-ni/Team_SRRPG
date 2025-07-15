using Team_SRRPG.Event;
using Team_SRRPG.Model;
using Team_SRRPG.Scene.Interface;

namespace Team_SRRPG.Scene.Data
{
    public class ExitScene : IScene
    {
        private SceneData _sceneData;

        public event EventHandler<SceneChangeEventArgs> SceneChangeRequested;

        public void HandleInput()
        {
            throw new NotImplementedException();
        }

        public void Render()
        {
            throw new NotImplementedException();
        }
    }
}