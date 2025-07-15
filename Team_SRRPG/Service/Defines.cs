using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_SRRPG.Service
{
    public static class Defines
    {
        #region 에러 코드
        public const int ERROR_INPUT_FORMATING = -1; // 입력 받는 형태 에러 발생
        public const int ERROR_OPTIONS_INPUT = -2; // 옵션 선택 중 또 다른 입력 시도
        #endregion

        #region 데이터 파일 위치
        public const string SAVE_DATA_FILE = "\\Data\\save.json";
        public const string ITEM_DATA_FILE = "\\Data\\items.json";
        public const string SCENE_DATA_FILE = "\\Data\\scen.json";
        public const string DUNGEON_DATA_FILE = "\\Data\\dungeon.json";
        #endregion

        #region 확률
        public const double DEFAULT_PROB = 0.0;
        #endregion
    }
}
