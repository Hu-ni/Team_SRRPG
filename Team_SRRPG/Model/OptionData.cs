namespace Team_SRRPG.Model
{
    public class OptionData
    {
        public string Text { get; set; }

        // 이 옵션을 선택했을 때 실행할 커맨드 정보들
        public List<CommandDescriptor> Commands { get; set; }
    }
}