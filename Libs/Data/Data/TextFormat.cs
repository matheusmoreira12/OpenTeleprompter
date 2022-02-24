namespace OpenTeleprompter.Data
{
    public class TextFormat
    {
        public TextFormat(TextFormatInterval[] intervals)
        {
            Intervals = intervals;
        }

        public readonly TextFormatInterval[] Intervals;
    }
}