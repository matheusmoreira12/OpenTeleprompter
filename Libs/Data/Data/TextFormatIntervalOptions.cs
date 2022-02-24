using System;

namespace OpenTeleprompter.Data
{
    public class TextFormatIntervalOptions
    {
        public TextFormatIntervalOptions(
            bool isBold, 
            bool isItalic, 
            bool isUnderline, 
            bool isHighlighed, 
            bool isBlinking, 
            Color textColor, 
            Color highlightColor,
            Font font,
            float fontSize,
            float baselineShift
            )
        {
            IsBold = isBold;
            IsItalic = isItalic;
            IsUnderline = isUnderline;
            IsHighlighed = isHighlighed;
            IsBlinking = isBlinking;
            TextColor = textColor;
            HighlightColor = highlightColor;
            Font = font;
            FontSize = fontSize;
            BaselineShift = baselineShift;
        }

        public readonly bool IsBold;
        public readonly bool IsItalic;
        public readonly bool IsUnderline;
        public readonly bool IsHighlighed;
        public readonly bool IsBlinking;
        public readonly Color TextColor;
        public readonly Color HighlightColor;
        public readonly Font Font;
        public readonly float FontSize;
        public readonly float BaselineShift;
    }
}