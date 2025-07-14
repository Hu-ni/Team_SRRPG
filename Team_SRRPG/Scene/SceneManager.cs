using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.DTO;
using Team_SRRPG.Event;
using Team_SRRPG.Scene.Interface;

namespace Team_SRRPG.Scene
{
    public class SceneManager
    {
        // 씬마다 나누면
        // 각자 씬 만들고 필요한 필요한 커맨드 
        // 기능마다 나눌꺼면 누구는 커맨드 제작
        // 누구는 씬 제작, 누구는 인벤토리 제작하면서 
        // PH_InventoryScene
        // PH_Command
        private readonly ISceneEventBus _eventBus;

        private IScene _currentScene;
        private IEmptyDTO _currentDto;

        public SceneManager(ISceneEventBus eventBus, int startSceneIndex, IEmptyDTO startDto)
        {
            _eventBus = eventBus;

            // 초기 씬/DTO 설정
            _currentDto = startDto;
            _currentScene = SceneFactory.Instance.Create(startSceneIndex, _currentDto);

            // 이벤트 구독
            _eventBus.OnSceneChange += OnSceneChange;
        }

        /// <summary>
        /// 이벤트가 발행되면 새 씬으로 교체
        /// </summary>
        private void OnSceneChange(int nextSceneIndex, IEmptyDTO nextDto)
        {
            _currentScene = SceneFactory.Instance.Create(nextSceneIndex, nextDto);
            _currentDto = nextDto;
        }

        /// <summary>
        /// 메인 루프
        /// </summary>
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                _currentScene.Render(_currentDto);

                _currentScene.HandleInput();

                // 종료 조건 예시: ExitScene이면 break
                //if (_currentScene is ExitScene) break;
            }
        }
    }
}
