using Team_SRRPG.Model;
using Team_SRRPG.Scene.Interface;
using Spartdungeon.Services;
using Team_SRRPG.Service;
using System;

namespace Team_SRRPG.Scene.Data
{
    public class DungeonSelectScene : BaseScene
    {
        private List<Dungeon> _dungeons;

        public DungeonSelectScene(SceneData data) : base(data)
        {
            _dungeons = DungeonRepository.Instance.GetAllDungeons();
        }

        public override void Render()
        {
            Console.Clear();
            ViewHelper.PrintTitle("던전 입장");

            foreach (var dungeon in _dungeons)
            {
                Console.WriteLine($"{dungeon.Id}. {dungeon.Name} - {dungeon.Description}");
            }

            Console.WriteLine("\n0. 나가기");
            ViewHelper.PrintInput();
        }

        public override void HandleInput()
        {
            int choice = InputManager.Instance.ReadLineInt();

            if (choice == 0)
            {
                RequestSceneChange(0);
                return;
            }

            var selectedDungeon = DungeonRepository.Instance.GetDungeonById(choice);

            if (selectedDungeon == null)
            {
                ViewHelper.PrintInvalidInput();
                Thread.Sleep(1000);
                return;
            }
            GameState.Instance.SelectedDungeon = selectedDungeon;
            RequestSceneChange(3); //Dungeon Scene
        }
    }
}
