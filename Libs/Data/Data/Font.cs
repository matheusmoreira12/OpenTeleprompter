namespace OpenTeleprompter.Data
{
    public class Font
    {
        public Font(FontGlyph[] glyph)
        {
            Glyph = glyph;
        }

        public readonly FontGlyph[] Glyph;
    }
}