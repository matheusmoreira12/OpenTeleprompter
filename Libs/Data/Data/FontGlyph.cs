namespace OpenTeleprompter.Data
{
    public sealed class FontGlyph
    {
        public FontGlyph(char character, FontGlyphArea[] areas, float width)
        {
            Character = character;
            Areas = areas;
            Width = width;
        }

        public readonly char Character;
        public readonly FontGlyphArea[] Areas;
        public readonly float Width;
    }
}