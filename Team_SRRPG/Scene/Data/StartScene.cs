using Spartdungeon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.Command.Interface;
using Team_SRRPG.Command.Scene;
using Team_SRRPG.Model;
using Team_SRRPG.Scene.Interface;
using Team_SRRPG.Service;

namespace Team_SRRPG.Scene.Data
{
    public class StartScene : BaseScene
    {
        private Dictionary<int, ICommand> _commands;
        private readonly Random _rng = new Random();

        public StartScene(SceneData data) : base(data)
        {
            _commands = new Dictionary<int, ICommand>   // 보여줄 순서대로 추가하면 됨.
            {
                // 1번 메뉴: 시작하기 커맨드
                {
                    1,  // 메뉴 번호 (선택지 번호)
                    new StartGameCommand(
                        rng:            _rng,
                        chance:         DEFAULT_PROB,   // 0.00 임시로 지정.
                        normalSceneId:  ,
                        onSceneChange:  nextId => RequestSceneChange(nextId)
                    )
                },
                // 2번 메뉴: 종료하기 커맨드
                {
                    2,
                    new ExitGameCommand(
                        exitSceneId:   ,
                        onSceneChange: nextId => RequestSceneChange(nextId)
                    )
                }
            };
        }

        public override void Render()
        {
            ViewHelper.PrintTitle(Data.Title);

            foreach (var kvp in _commands)
            {
                int menuKey = kvp.Key;
                string menuName = kvp.Value.Name;
                Console.WriteLine($"{menuKey}. {menuName}");
            }
        }

        public override void HandleInput()
        {
            //InputManager.Instance.SelectOptionAsync(new List<string> { "시작하기", "종료하기" });
            int choice = InputManager.Instance.ReadLineInt();

            if (_commands.TryGetValue(choice, out var cmd))
            {
                cmd.Execute();
            }
            else
            {
                ViewHelper.PrintNotification("잘못된 입력입니다.");
            }
        }
    }
}
