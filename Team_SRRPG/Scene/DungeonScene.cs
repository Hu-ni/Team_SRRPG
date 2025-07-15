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
            Console.Clear();
            Console.WriteLine($"Entering Dungeon: {dungeon.Name}");
            Console.WriteLine(dungeon.Description);
            Console.WriteLine($"Difficulty: {dungeon.Difficulty}");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            foreach (var monster in dungeon.Monsters)
            {
                Console.Clear();
                Console.WriteLine($"\nA wild {monster.Name} appears!");

                // Simple turn-based combat loop
                while (monster.Hp > 0 && _player.Hp > 0)
                {
                    Console.WriteLine($"\nYour HP: {_player.Hp} | {monster.Name} HP: {monster.Hp}");
                    Console.WriteLine($"You attack the {monster.Name}!");
                    monster.Hp -= _player.Attack; // Player's attack logic
                    Console.WriteLine($"{monster.Name} takes {_player.Attack} damage.");

                    if (monster.Hp <= 0)
                    {
                        Console.WriteLine($"{monster.Name} defeated!");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }

                    Console.WriteLine($"{monster.Name} attacks you!");
                    _player.Hp -= monster.Atk; // Monster's attack logic
                    Console.WriteLine($"You take {monster.Atk} damage.");

                    if (_player.Hp <= 0)
                    {
                        Console.WriteLine("\nYou were defeated!");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        // TODO: Add logic to handle player death (e.g., return to town)
                        return;
                    }
                    
                    Console.WriteLine("\nPress any key to continue to the next turn...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.Clear();
            Console.WriteLine($"\nDungeon Cleared! You earned {dungeon.Gold} Gold!");
            _player.Gold += dungeon.Gold;

            // Handle item rewards
            foreach (int itemId in dungeon.ItemIds)
            {
                Console.WriteLine($"You received item with ID: {itemId}");
                // You could fetch actual item object from item database here
            }
            
            Console.WriteLine("\nPress any key to return to the dungeon entrance...");
            Console.ReadKey();
        }
    }
}
