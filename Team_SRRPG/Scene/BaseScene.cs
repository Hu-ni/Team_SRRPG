using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.Model;
using Team_SRRPG.Scene.Interface;
using Team_SRRPG.Service;

namespace Team_SRRPG.Scene
{
    /// <summary>
    /// 모든 씬(State)의 공통 기능을 제공하는 추상 클래스
    /// </summary>
    public abstract class BaseScene : IScene
    {
        // 씬 전환 요청 이벤트
        public event Action<int> SceneChangeRequested;

        // JSON으로부터 로드된 씬 데이터
        protected SceneData Data { get; }
        private bool _isRunning;

        /// <summary>
        /// 생성 시 SceneFactory에서 Data를 주입받음
        /// </summary>
        public BaseScene(SceneData data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        /// <summary>
        /// State 패턴 Enter 구현
        /// </summary>
        public void Enter()
        {
            _isRunning = true;
            // 무한 루프: 입력받고 처리
            while (_isRunning)
            {
                Console.Clear();
                Render();
                HandleInput();
            }
        }

        public virtual void Exit()
        {
            // 필요할 경우 오버라이드해서 사용.
        }

        /// <summary>
        /// 씬 전환을 외부에 알릴 때 사용.(ex: SceneManager)
        /// </summary>
        /// <param name="nextSceneId"></param>
        protected void RequestSceneChange(int nextSceneId)
        {
            // 씬 전환 요청이 들어오면 무한 루프 탈출
            _isRunning = false;
            SceneChangeRequested?.Invoke(nextSceneId);
        }

        public abstract void Render();
        public abstract void HandleInput();

    }
}
