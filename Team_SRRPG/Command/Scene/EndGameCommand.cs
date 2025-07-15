using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.Command.Interface;

namespace Team_SRRPG.Command.Scene
{
    public class ExitGameCommand : IGameCommand
    {
        public string Name => "종료하기";

        private readonly int _exitSceneId;
        public ExitGameCommand(int exitSceneId)
        {
            _exitSceneId = exitSceneId;
        }

        public int? Execute()
        {
            return _exitSceneId;
        }
    }
}
