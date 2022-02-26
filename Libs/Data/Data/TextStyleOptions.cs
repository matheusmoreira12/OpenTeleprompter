using System;

namespace OpenTeleprompter.Data
{
    public sealed class TextStyleOptions
    {
        public TextStyleOptions(
            Font font,
            Color textColor
            )
        {
            Font = font;
            TextColor = textColor;
        }

        public readonly Font Font;
        public readonly Color TextColor;
    }
}