using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.Model;

namespace Team_SRRPG.Service
{
    public class GameContext : Singleton<GameContext>
    {
        public Player Player { get; set; }
        public List<Item> items { get; set; }
        public List<SceneData> sceneData { get; set; }
    }
}
