using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.Model;

namespace Team_SRRPG.Service
{
    // 공용 데이터 
    public class GameContext : Singleton<GameContext>
    {
        public Player Player { get; set; }
        public List<Item> items { get; set; }       // 공용 아이템, 인벤토리 아님!!
        public List<SceneData> sceneData { get; set; }
        
    }
}
