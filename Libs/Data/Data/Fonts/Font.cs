using System;

namespace OpenTeleprompter.Data.Fonts
{
    public sealed class Font
    {
        public Font(FontGlyph[] glyphs, float height)
        {
            Glyphs = glyphs;
            Height = height;
        }

        public FontGlyph GetCharacterGlyph(char character)
        {
            foreach (var glyph in Glyphs)
                if (glyph.Character == character)
                    return glyph;

            throw new InvalidOperationException("Character glyph not found.");
        }

        public readonly FontGlyph[] Glyphs;

        public readonly float Height;
    }
}