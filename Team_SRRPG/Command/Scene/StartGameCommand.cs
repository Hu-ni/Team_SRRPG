using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.Command.Interface;

namespace Team_SRRPG.Command.Scene
{
    public class StartGameCommand : IGameCommand
    {
        public string Name => "시작하기";

        private readonly Random _rng;
        private readonly double _chance;
        private readonly int _normalSceneId;
        private readonly IGameCommand _startFailCommand

        public StartGameCommand(Random rng, double chance, int normalSceneId, IGameCommand startFailCommand)
        {
            _rng = rng;
            _chance = chance;
            _normalSceneId = normalSceneId;
            _startFailCommand = startFailCommand;
        }

        public int? Execute()
        {
            // 확률 체크
            if (_rng.NextDouble() < _chance)
            {
                Console.WriteLine("게임 시작");
                return _normalSceneId;
            }
            else
            {
                Console.WriteLine("시작 실패 게임 종료");
                _startFailCommand.Execute();
                return null;
            }
        }
    }
}
