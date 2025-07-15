using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Team_SRRPG.Command.Factory;
using Team_SRRPG.Command.Interface;
using Team_SRRPG.Model;
using Team_SRRPG.Service;

namespace Team_SRRPG.Scene.Data
{

    public class UserScene : BaseScene
    {
        private Dictionary<int, List<IGameCommand>> _commands;
        public UserScene(SceneData data) : base(data)
        {
            _commands = new Dictionary<int, List<IGameCommand>>();

            for (int i = 0; i < data.Options.Count; i++)
            {
                var opt = data.Options[i];
                var cmds = new List<IGameCommand>();

                foreach (var desc in opt.Commands)
                {
                    // Registry에서 뽑아내기만 하면 끝!
                    cmds.Add(CommandRepository.Instance.Create(this, desc));
                }

                // 메뉴 키는 1부터
                _commands.Add(i + 1, cmds);
            }
        }

        public override void HandleInput()
        {
            //InputManager.Instance.SelectOptionAsync(new List<string> { "시작하기", "종료하기" });
            int choice = InputManager.Instance.ReadLineInt();

            var descs = Data.Options[choice - 1].Commands;
            foreach (var desc in descs)
            {
                var cmd = CommandRepository.Instance.Create(this, desc);
                var result = cmd.Execute(); // 전환할 씬 ID 받음.
                if (result.HasValue) // 전환할 씬 ID가 있다면
                    RequestSceneChange(result.Value);   //씬 전환
            }
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }
    }
}
