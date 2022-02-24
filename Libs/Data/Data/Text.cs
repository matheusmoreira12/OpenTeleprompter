namespace OpenTeleprompter.Data
{
    public class Text
    {
        public readonly byte[] Characters;
        public readonly TextStyle Style;

        public Text(byte[] characters, TextStyle style)
        {
            Characters = characters;
            Style = style;
        }
    }
}