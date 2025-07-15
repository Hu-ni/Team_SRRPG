using Spartdungeon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Team_SRRPG.DTO;
using Team_SRRPG.Model;
using Team_SRRPG.Scene.Interface;
using Team_SRRPG.Service;

namespace Team_SRRPG.Scene
{
    public class StartScene : SceneData, IScene
    {
        
        private Dictionary<int, ICommand> _commands;
        private Random _rand = new Random();

        public StartScene(IEmptyDTO data, Dictionary<int, ICommand> commands)
        { 
            StartSceneDTO dto = data as StartSceneDTO;
            base(dto);
            _commands = commands;
        }

        public void Render(IEmptyDTO dto)
        {
            Console.WriteLine("===== Start Scene =====");
            Console.WriteLine("1. 게임 시작하기");
            Console.WriteLine("2. 종료하기");
        }

        public void HandleInput()
        {
            //InputManager.Instance.SelectOptionAsync(new List<string> { "시작하기", "종료하기" });
            int input = InputManager.Instance.ReadLineIntInRange(1, 2); // 입력을 받음.

            switch (input)
            {
                case 1:
                    if (_rand.NextDouble() < 0.5f)
                    {
                        Console.WriteLine("게임 시작");
                        if (_commands != null && _commands.ContainsKey(1))
                        {
                            _commands[1].Execute(null);
                        }
                    }
                    else
                    {
                        Console.WriteLine("게임 시작 실패");
                        if (_commands != null && _commands.ContainsKey(2))
                        {
                            _commands[2].Execute(null);
                        }
                    }
                    break;

                case 2:
                    if (_rand.NextDouble() < 0.5f)
                    {
                        Console.WriteLine("게임 종료");
                        if (_commands != null && _commands.Contains(2))
                        {
                            _commands[2].Execute(null);
                        }
                    }
                    else
                    {
                        Console.WriteLine("종료 실패 강제 시작");
                        if (_commands != null && _commands.Contains(1))
                        {
                            _commands[1].Execute(null);
                        }
                    }
                    break;
            }
        }
    }
}
