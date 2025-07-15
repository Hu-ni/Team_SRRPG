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

            #endregion


            #region 실행 코드
            // 1) JSON 로드
            var context = GameContext.Instance;

            // 2) 커맨드 등록
            Random rnd = new Random();

            var repo = CommandRepository.Instance;
            repo.Register(GameCommandType.StartGame, (scene, desc) =>
            {
                double chance = Convert.ToDouble(desc.Args["specialChance"]);
                int normalId = Convert.ToInt32(desc.Args["normalSceneId"]);

                return new StartGameCommand(
                      rng: rnd,
                      chance: DEFAULT_PROB,
                      normalSceneId: normalId // descriptor 내부에 Args 딕셔너리 가정
                  );
            });


            // 3) 씬 매니저 시작
            var manager = new SceneManager();
            manager.Start(initialIdx: 1);
            #endregion
        }
    }
}
