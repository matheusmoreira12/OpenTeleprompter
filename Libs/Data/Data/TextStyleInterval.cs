namespace OpenTeleprompter.Data
{
    public class TextStyleInterval
    {
        public TextStyleInterval(int start, TextStyleOptions options)
        {
            Start = start;
            Options = options;
        }

        public readonly int Start;
        public readonly TextStyleOptions Options;
    }
}