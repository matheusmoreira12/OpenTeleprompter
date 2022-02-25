using System;

namespace OpenTeleprompter.Data
{
    public sealed class TextStyleOptions
    {
        public TextStyleOptions(
            bool isBold, 
            bool isItalic, 
            bool isUnderlined, 
            bool isHighlighed, 
            bool isBlinking, 
            Color textColor, 
            Color highlightColor,
            Font font,
            float fontHeight,
            float baselineShift,
            float lineSpacing
            )
        {
            IsBold = isBold;
            IsItalic = isItalic;
            IsUnderlined = isUnderlined;
            IsHighlighed = isHighlighed;
            IsBlinking = isBlinking;
            TextColor = textColor;
            HighlightColor = highlightColor;
            Font = font;
            FontHeight = fontHeight;
            BaselineShift = baselineShift;
            LineSpacing = lineSpacing;
        }

        public readonly bool IsBold;
        public readonly bool IsItalic;
        public readonly bool IsUnderlined;
        public readonly bool IsHighlighed;
        public readonly bool IsBlinking;
        public readonly Color TextColor;
        public readonly Color HighlightColor;
        public readonly Font Font;
        public readonly float FontHeight;
        public readonly float BaselineShift;
        public readonly float LineSpacing;
    }
}