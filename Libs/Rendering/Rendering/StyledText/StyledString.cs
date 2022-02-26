using System;
using OpenTeleprompter.Data;

namespace Rendering.StyledText
{
    public class StyledString
    {
        public static StyledString FromString(string text,
            TextStyleOptions style) => new StyledString(text, style);

        private StyledString(string @base, TextStyleOptions style)
        {
            Base = @base;
            Style = style;
        }

        public override string ToString() => Base;

        private readonly string Base;
        public readonly TextStyleOptions Style;
    }
}
