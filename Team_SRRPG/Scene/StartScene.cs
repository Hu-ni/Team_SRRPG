using Spartdungeon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Team_SRRPG.DTO;
using Team_SRRPG.Scene.Interface;
using Team_SRRPG.Service;

namespace Team_SRRPG.Scene
{
    public class StartScene : IScene
    {
        private ICommand command;

        private IEmptyDTO data;

        public StartScene(IEmptyDTO data)
        {
            this.data = data;
        }

        public void Render(IEmptyDTO dto)
        {
            Console.WriteLine("===== Start Scene =====");
            Console.WriteLine("1. 게임 시작하기");
            Console.WriteLine("2. 종료하기");
        }

        public void HandleInput()
        {
            InputManager.Instance.SelectOptionAsync(new List<string> { "시작하기", "종료하기" });
            int input = InputManager.Instance.ReadLineIntInRange(1, 2); // 입력을 받음.
            switch (input)
            {
                case 1:
                    //command.Execute();
                    // 커맨드가 실행
                    break;
                case 2:
                    // 커맨드가 실행
                    break;
            }
        }
    }
}
