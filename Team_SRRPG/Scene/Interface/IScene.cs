using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.DTO;

namespace Team_SRRPG.Scene.Interface
{
    public interface IScene
    {
        /// <summary>
        /// DTO를 받아서 화면에 출력만 한다.
        /// </summary>
        void Render(IEmptyDTO dto);

        /// <summary>
        /// 유저 입력 받고 Command 실행만 한다.
        /// Command가 결과를 EventBus로 전달한다.
        /// </summary>
        void HandleInput();
    }
}
