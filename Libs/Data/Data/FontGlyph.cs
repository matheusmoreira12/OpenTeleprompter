namespace OpenTeleprompter.Data
{
    public class FontGlyph
    {
        public FontGlyph(char character, FontGlyphArea[] areas, Size size)
        {
            Character = character;
            Areas = areas;
            Size = size;
        }

        public readonly char Character;
        public readonly FontGlyphArea[] Areas;
        public readonly Size Size;
    }
}