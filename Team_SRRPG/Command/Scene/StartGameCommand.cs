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

        public StartGameCommand(Random rng, double chance, int normalSceneId)
        {
            _rng = rng;
            _chance = chance;
            _normalSceneId = normalSceneId;
        }

        public int? Execute()
        {
            // 확률 체크
            if (_chance < _rng.NextDouble()) ;
            // 또는 다른 로직 적용.
            // ex) 플레이어 히든 직업 등등
            return _normalSceneId;
        }
    }
}
