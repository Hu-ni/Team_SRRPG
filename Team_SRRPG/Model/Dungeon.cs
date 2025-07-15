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
            easyDungeon.Monsters.Add(new Monster("미니언", 2, 15, 5, 2, 2, 100, 10));
            easyDungeon.Monsters.Add(new Monster("포로", 1, 10, 3, 1, 5, 100, 10));
            easyDungeon.Monsters.Add(new Monster("슈퍼 미니언", 5, 25, 8, 5, 2, 100, 10));
            Dungeons.Add(easyDungeon);

            var normalDungeon = new Dungeon(2, "수정의 상처", "협곡과는 다른 전략이 필요한 곳", 2, 500);
            normalDungeon.Monsters.Add(new Monster("돌거북", 8, 40, 12, 8, 1, 100, 10));
            normalDungeon.Monsters.Add(new Monster("심술 두꺼비", 10, 50, 15, 5, 5, 100, 10));
            normalDungeon.Monsters.Add(new Monster("칼날부리", 12, 30, 20, 3, 10, 100, 10));
            Dungeons.Add(normalDungeon);

            var hardDungeon = new Dungeon(3, "소환사의 협곡", "전장의 열기가 가득한 곳", 3, 1000);
            hardDungeon.Monsters.Add(new Monster("블루 골렘", 15, 70, 25, 15, 5, 100, 10));
            hardDungeon.Monsters.Add(new Monster("레드 리자드", 15, 70, 25, 15, 5, 100, 10));
            hardDungeon.Monsters.Add(new Monster("바론", 20, 100, 40, 20, 10, 100, 10));
            Dungeons.Add(hardDungeon);
        }
    }
}
