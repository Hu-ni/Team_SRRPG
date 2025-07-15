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
        private Player _player;

        public DungeonScene(Player player)
        {
            _dungeonManager = new DungeonManager();
            _player = player;
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
            int input = InputManager.Instance.ReadLineIntInRange(0, _dungeonManager.Dungeons.Count);
            switch (input)
            {
                case 0:
                    //나가기
                    // TODO: Add logic to return to the previous scene
                    break;
                default:
                    // 던전 입장
                    RunDungeon(_dungeonManager.Dungeons[input - 1]);
                    break;
            }
        }

        private void RunDungeon(Dungeon dungeon)
        {
            int currentRoom = 0;
            int maxRooms = 3;
            while (currentRoom < maxRooms)
            {
                Console.Clear();
                Console.WriteLine($"현재 던전: {dungeon.Name}");
                Console.WriteLine(dungeon.Description);
                Console.WriteLine($"난이도: {dungeon.Difficulty}");
                Console.WriteLine(" __________   __________   __________");
                Console.WriteLine("|          | |          | |          |");

                for (int i = 0; i < maxRooms; i++)
                {
                    if (i == currentRoom)
                        Console.Write("|    O     |=");
                    else
                        Console.Write("|          |=");
                }
                Console.WriteLine();
                Console.WriteLine("|__________|=|__________|=|__________|");
                Console.WriteLine("\n\n던전에 오신걸 환영합니다");
                Console.WriteLine("1.다음 방으로 이동하기\n2.상태보기\n3.아이템 사용하기");
                Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");
            }

        }
    }
}
