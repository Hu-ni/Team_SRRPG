using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.Event;
using Team_SRRPG.Model;
using Team_SRRPG.Scene.Data;
using Team_SRRPG.Scene.Interface;
using Team_SRRPG.Service;

namespace Team_SRRPG.Scene.Factory
{
    /// <summary>
    /// 모든 씬과 커맨드를 생성하는 싱글톤 팩토리
    /// </summary>
    public class SceneFactory : Singleton<SceneFactory>
    {
        /// <summary>
        /// 씬 ID로부터 SceneData를 조회한 뒤, 구체적인 IScene 구현체를 반환
        /// </summary>
        public IScene Create(int sceneId)
        {
            var data = GameContext.Instance.Scenes[sceneId];  // 전역 JSON 데이터 :contentReference[oaicite:0]{index=0}
            return Create(data);
        }

        /// <summary>
        /// SceneData 기반으로 알맞은 Scene 클래스 인스턴스 생성
        /// </summary>
        public IScene Create(SceneData data)
        {
            switch (data.Id)
            {
                case 0:
                    return new StartScene(data);
                case 1:
                    return new ExitScene(data);
                // 새 씬 추가 시 여기에 case 문으로 확장
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(data.Id),
                        $"Unknown scene ID: {data.Id}"
                    );
            }
        }
    }
}
