using System.Collections.Generic;
using System.Linq;

namespace Team_SRRPG.Model
{
    public class DungeonRepository
    {
        private static DungeonRepository? _instance;
        public static DungeonRepository Instance => _instance ??= new DungeonRepository();

        private List<Dungeon> _dungeons;

        private DungeonRepository()
        {
            var manager = new DungeonManager();
            _dungeons = manager.Dungeons;
        }

        public Dungeon GetDungeonById(int id)
        {
            var dungeon = _dungeons.FirstOrDefault(d => d.Id == id);
            if (dungeon == null)
                throw new KeyNotFoundException($"Dungeon with ID {id} not found.");
            return dungeon;
        }

        public List<Dungeon> GetAllDungeons()
        {
            return _dungeons;
        }
    }
}
