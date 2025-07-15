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
        public Player Player { get; private set; }
        public Dictionary<int, Item> Items { get; private set; }       // 공용 아이템, 인벤토리 아님!!
        public Dictionary<int, SceneData> Scenes { get; private set; }

        public GameContext() 
        {
            //Player = JsonSerializerHelper.Deserialize<Player>();
            Items = JsonSerializerHelper.Deserialize<List<Item>>(ITEM_DATA_FILE).ToDictionary(x => x.Id);
            Scenes = JsonSerializerHelper.Deserialize<List<SceneData>>(SCENE_DATA_FILE).ToDictionary(x => x.Id);

        }
        
    }
}
