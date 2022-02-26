namespace OpenTeleprompter.Data
{
    public sealed class TextStyleInterval
    {
        public TextStyleInterval(int start, int end, TextStyleOptions options)
        {
            Start = start;
            End = end;
            Options = options;
        }

        public readonly int Start;
        public readonly int End;
        public readonly TextStyleOptions Options;
    }
}