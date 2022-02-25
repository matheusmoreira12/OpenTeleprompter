using System;

namespace OpenTeleprompter.Data
{
    public sealed class Font
    {
        public Font(FontGlyph[] glyphs)
        {
            Glyphs = glyphs;
        }

        public FontGlyph GetCharacterGlyph(char character)
        {
            foreach (var glyph in Glyphs)
                if (glyph.Character == character)
                    return glyph;

            throw new InvalidOperationException("Character glyph not found.");
        }

        public readonly FontGlyph[] Glyphs;
    }
}