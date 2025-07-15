using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.Model;
using Team_SRRPG.Service.Provider;

namespace Team_SRRPG.Service
{
    // 공용 데이터 
    public class GameContext : Singleton<GameContext>
    {
        public Player Player { get; private set; }
        public Dictionary<int, Item> Items { get; private set; }       // 공용 아이템, 인벤토리 아님!!
        public Dictionary<int, SceneData> Scenes { get; private set; }
        public Dictionary<int, Dungeon> Dungeons { get; private set; }
        public GameContext()
        {
            if (File.Exists(SAVE_DATA_FILE))
                Player = JsonSerializerHelper.Deserialize<Player>(SAVE_DATA_FILE);
            if (File.Exists(ITEM_DATA_FILE))
                Items = JsonSerializerHelper.Deserialize<List<Item>>(ITEM_DATA_FILE).ToDictionary(x => x.Id);
            else
                ;
            if (File.Exists(SCENE_DATA_FILE))
            {

                Scenes = JsonSerializerHelper.Deserialize<List<SceneData>>(SCENE_DATA_FILE).ToDictionary(x => x.Id);
            }
            else
            {
                List<SceneData> provider = SceneDataProvider.GetHardCodedScenes();
                JsonSerializerHelper.Serialize(provider, SCENE_DATA_FILE);

            }
            if (File.Exists(DUNGEON_DATA_FILE))
                Dungeons = JsonSerializerHelper.Deserialize<List<Dungeon>>(DUNGEON_DATA_FILE).ToDictionary(x => x.Id);
            else
                ;
        }
        
    }
}
