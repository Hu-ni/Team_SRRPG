using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Team_SRRPG.Model
{
    // 데이터 저장될 그릇
    // 최소 단위 *
    public class Dungeon
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Difficulty { get; private set; }
        public List<Monster> Monsters { get; }
        // 던전 클리어 보상
        public int Gold { get; private set; }
        public List<int> ItemIds { get; private set; }

        public Dungeon(int id, string name, string description, int difficulty, int rewardGold)
        {
            Id = id;
            Name = name;
            Description = description;
            Difficulty = difficulty;
            Monsters = new List<Monster>();
            Gold = rewardGold;
            ItemIds = new List<int>();
        }
    }
    public class DungeonManager
    {
        public List<Dungeon> Dungeons { get; }
        public DungeonManager()
        {
            Dungeons = new List<Dungeon>();
            InitializeDungeon();
        }
        private void InitializeDungeon()
        {
            var easyDungeon = new Dungeon(1, "칼바람 나락", "너무나도 익숙한 곳", 1, 300);
            easyDungeon.Monsters.Add(new Monster("미니언", 1, 10, 3, 3, 3, 100, 10));
            easyDungeon.Monsters.Add(new Monster("포로", 1, 10, 3, 3, 3, 100, 10));
            easyDungeon.Monsters.Add(new Monster("슈퍼 미니언", 1, 10, 3, 3, 3, 100, 10));
        }
    }
}
