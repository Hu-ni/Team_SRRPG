global using static Team_SRRPG.Service.Defines;
using System.Threading.Channels;
using Team_SRRPG.Command.Factory;
using Team_SRRPG.Command.Scene;
using Team_SRRPG.Model;
using Team_SRRPG.Scene;
using Team_SRRPG.Service;

namespace Team_SRRPG
{

    public class Program
    {
        public static void Main(string[] args)
        {

            #region Json 파일 생성
            //SceneData data = new SceneData();
            //data.Id = 1;
            //data.Title = "시작화면";
            //data.Description = "시작화면입니다.";
            //data.Options = new List<OptionData>
            //{
            //    new OptionData
            //    {
            //        Text = "시작하기",
            //        Commands = new List<CommandDescriptor>
            //        {
            //            new CommandDescriptor
            //            {
            //                Type = GameCommandType.StartGame,
            //                Args = new Dictionary<string, object>
            //                {
            //                    ["nextSceneId"] = 0
            //                }
            //            }
            //        }
            //    }
            //};


            //JsonSerializerHelper.Serialize(new List<SceneData> { data }, SCENE_DATA_FILE);
            //return;
            #endregion


            #region 실행 코드
            // 1) JSON 로드
            var context = GameContext.Instance;

            // 2) 커맨드 등록
            Random rnd = new Random();

            var repo = CommandRepository.Instance;
            repo.Register(GameCommandType.StartGame, (scene, desc) =>
            {
                //double chance = Convert.ToDouble(desc.Args["specialChance"]);
                int nextSceneId = Convert.ToInt32(desc.Args["nextSceneId"]);

                return new StartGameCommand(
                      rng: rnd,
                      chance: DEFAULT_PROB,
                      normalSceneId: nextSceneId // descriptor 내부에 Args 딕셔너리 가정
                  );
            });


            // 3) 씬 매니저 시작
            var manager = new SceneManager();
            manager.Start(initialIdx: 1);
            #endregion
        }
    }
}
