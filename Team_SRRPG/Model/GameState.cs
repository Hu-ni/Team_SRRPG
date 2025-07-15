using Team_SRRPG.Model;

namespace Team_SRRPG.Service
{
    public class GameState : Singleton<GameState>
    {
        public Dungeon? SelectedDungeon { get; set; }

        protected override void Initialize()
        {
            SelectedDungeon = null;
        }
    }
}