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

        private readonly Random _rng;
        private readonly double _chance;
        private readonly int _normalSceneId;
        private readonly IGameCommand _endFailCommand;

        private readonly int _exitSceneId;
        public ExitGameCommand(Random rng, double chance, int exitSceneId, IGameCommand endFailCommand)
        {
            _rng = rng;
            _chance = chance;
            _exitSceneId = exitSceneId; 
            _endFailCommand = endFailCommand;
        }

        public int? Execute()
        {
            if (_rng.NextDouble() < _chance)
            {
                Console.WriteLine("게임 종료");
                return _exitSceneId;
            }
            else
            {
                Console.WriteLine("종료 실패 강제 시작");
                _endFailCommand.Execute();
                return null;
            }
        }
    }
}
