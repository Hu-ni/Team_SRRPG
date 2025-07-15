using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.Command.Interface;
using Team_SRRPG.Event;
using static System.Net.Mime.MediaTypeNames;

namespace Team_SRRPG.Command.Scene
{
    public class StartGameCommand : ICommand
    {
        public string Name => "시작하기";
        private readonly Action<int> _onSceneChange;    // 씬 전환 이벤트

        private readonly Random _rng;
        private readonly double _chance;
        private readonly int _normalSceneId;

        public StartGameCommand(Random rng, double chance, int normalSceneId, Action<int> onSceneChange)
        {
            _rng = rng;
            _chance = chance;
            _normalSceneId = normalSceneId;
            _onSceneChange = onSceneChange;
        }

        public void Execute()
        {
            // 확률 체크

            // 또는 다른 로직 적용.
            // ex) 플레이어 히든 직업 등등

            _onSceneChange(_normalSceneId);
        }
    }
}
