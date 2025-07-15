using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Team_SRRPG.Event;

namespace Team_SRRPG.Scene.Interface
{
    public interface IScene
    {
        /// <summary>씬 진입 시 호출됩니다.</summary>
        void Enter();

        /// <summary>씬에서 나갈 때 호출(optional)</summary>
        void Exit();
        /// <summary>
        /// 화면에 출력 한다.
        /// </summary>
        void Render();

        /// <summary>
        /// 유저 입력 받고 Command 실행만 한다.
        /// Command가 결과를 EventBus로 전달한다.
        /// </summary>
        void HandleInput();
        event EventHandler<SceneChangeEventArgs> SceneChangeRequested;
    }
}
