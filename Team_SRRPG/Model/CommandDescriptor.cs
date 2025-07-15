using System.Data;
using Team_SRRPG.Service;

namespace Team_SRRPG.Model
{
    public class CommandDescriptor
    {
        // 어떤 커맨드인지
        public GameCommandType Type { get; set; }

        // 이름 기반 컬렉션: itemId, nextSceneId, bonus 등 모든 파라미터를 여기에 담음
        public Dictionary<string, object> Args { get; set; } = new();
    }
}