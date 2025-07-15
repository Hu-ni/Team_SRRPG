using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.Model;
using Team_SRRPG.Scene.Data;
using Team_SRRPG.Scene.Factory;
using Team_SRRPG.Scene.Interface;
using Team_SRRPG.Service;

namespace Team_SRRPG.Scene
{
    public class SceneManager
    {
        private IScene _currentScene;

        public void Start(int initialIdx)
        {
            var scene = CreateScene(initialIdx);
            ChangeState(scene);
        }

        private IScene CreateScene(int id)
        {
            var scene = SceneFactory.Instance.Create(id);
            scene.SceneChangeRequested += OnSceneChange;
            return scene;
        }

        private void ChangeState(IScene next)
        {
            // 이전 씬 정리
            if(_currentScene != null && OnSceneChange != null)
            {
                _currentScene.SceneChangeRequested -= OnSceneChange;
                _currentScene.Exit();
            }

            _currentScene = next;

            _currentScene.Enter();
        }

        private void OnSceneChange(int nextId)
        {
            // 새로운 씬 로드
            ChangeState(CreateScene(nextId));
        }

        // Enter() -> 입력/출력 -> 씬 전환 이벤트 호출 -> Enter() 로 무한루프 흐름 되기 때문에 주석처리
        ///// <summary>
        ///// 메인 루프
        ///// </summary>
        //public void Run()
        //{
        //    while (true)
        //    {
        //        Console.Clear();
        //        _current.Render();
        //        _current.HandleInput();

        //        // 종료 조건 예시: ExitScene이면 break
        //        if (_current is ExitScene) break;
        //    }
        //}
    }
}
