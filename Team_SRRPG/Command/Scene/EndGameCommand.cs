using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.Command.Interface;
using Team_SRRPG.Event;

namespace Team_SRRPG.Command.Scene
{
    public class ExitGameCommand : ICommand
    {
        public string Name => "종료하기";
        private readonly Action<int> _onSceneChange;

        private readonly int _exitSceneId;
        public ExitGameCommand(int exitSceneId, Action<int> onSceneChange)
        {
            _exitSceneId = exitSceneId;
            _onSceneChange = onSceneChange;
        }

        public void Execute()
        {
            _onSceneChange(_exitSceneId);
        }
    }
}
