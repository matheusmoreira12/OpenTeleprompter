namespace OpenTeleprompter.Data
{
    public class Font
    {
        public Font(FontGlyph[] glyphs)
        {
            Glyphs = glyphs;
        }

        public readonly FontGlyph[] Glyphs;
    }
}