using System;
using System.Collections.Generic;
using Team_SRRPG.DTO;
using Team_SRRPG.Model;
using Team_SRRPG.Scene.Interface;
using Team_SRRPG.Service;

namespace Team_SRRPG.Scene
{
    public class DungeonScene : IScene
    {
        private DungeonManager _dungeonManager;
        //Player 데이터 필요

        public DungeonScene()
        {
            _dungeonManager = new DungeonManager();
            //Player 데이터 필요
        }
        public void Render(IEmptyDTO dto)
        {
            Console.Clear();
            Console.WriteLine("■던전입장■");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            for (int i = 0; i < _dungeonManager.Dungeons.Count; i++)
            {
                var dungeon = _dungeonManager.Dungeons[i];
                Console.WriteLine($"{i + 1}. {dungeon.Name} | {dungeon.Description}");
            }
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
        }

        public void HandleInput()
        {
            int input = InputManager.Instance.ReadLineIntInRange(0, 1);
            switch (input)
            {
                case 1:
                    //입장
                    break;
                case 0:
                    //나가기
                    break;
            }
        }
    }
}
