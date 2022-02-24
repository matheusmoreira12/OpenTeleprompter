namespace OpenTeleprompter.Data
{
    public class TextFormatInterval
    {
        public TextFormatInterval(int start, TextFormatIntervalOptions options)
        {
            Start = start;
            Options = options;
        }

        public readonly int Start;
        public readonly TextFormatIntervalOptions Options;
    }
}