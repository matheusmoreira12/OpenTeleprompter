namespace OpenTeleprompter.Data
{
    public class Text
    {
        public readonly byte[] Characters;
        public readonly TextFormat Format;

        public Text(byte[] characters, TextFormat format)
        {
            Characters = characters;
            Format = format;
        }
    }
}