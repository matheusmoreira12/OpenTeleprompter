namespace OpenTeleprompter.Data
{
    public class FontGlyph
    {
        public FontGlyph(FontGlyphArea[] areas, Size size)
        {
            Areas = areas;
            Size = size;
        }

        public readonly FontGlyphArea[] Areas;
        public readonly Size Size;
    }
}