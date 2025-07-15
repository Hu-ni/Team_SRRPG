using System;
using Team_SRRPG.Model;
using Team_SRRPG.Scene.Interface;
using Spartdungeon.Services;
using Team_SRRPG.Service;
using Team_SRRPG.Command.Factory;
using Team_SRRPG.Command.Interface;

namespace Team_SRRPG.Scene.Data
{
    public class DungeonScene : BaseScene
    {
        private Dungeon _dungeon;
        private int _currentRoom = 0;
        private const int MaxRooms = 3;
        public DungeonScene(SceneData data) : base(data)
        {
            _dungeon = GameState.Instance.SelectedDungeon;
        }
        public override void Render()
        {
            Console.Clear();
            ViewHelper.PrintTitle(_dungeon.Name);
            Console.WriteLine(_dungeon.Description + "\n");
            Console.WriteLine(" __________   __________   __________");
            Console.WriteLine("|          | |          | |          |");

            for (int i = 0; i < MaxRooms; i++)
            {
                if (i == _currentRoom)
                    Console.Write("|    O     |=");
                else
                    Console.Write("|          |=");
            }
            Console.WriteLine();
            Console.WriteLine("|__________|=|__________|=|__________|");

            Console.WriteLine("\n현재 방: {0} / {1}", _currentRoom + 1, MaxRooms);
            Console.WriteLine("1. 다음 방으로 이동");
            Console.WriteLine("2. 상태 보기");
            ViewHelper.PrintInput();
        }


        public override void HandleInput()
        {
            int choice = InputManager.Instance.ReadLineInt();

            switch (choice)
            {
                case 1:
                    if (_currentRoom < MaxRooms - 1)
                    {
                        _currentRoom++;
                        Console.WriteLine("다음 방으로 이동합니다...");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("마지막 방입니다. 전투를 시작합니다!");
                        Thread.Sleep(1000);
                        //RunCombat();
                    }
                    break;

                case 2:
                    //ShowStatus();
                    break;

                default:
                    ViewHelper.PrintInvalidInput();
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
}
