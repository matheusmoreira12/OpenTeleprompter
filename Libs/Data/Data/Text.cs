using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenTeleprompter.Data
{
    public sealed class Text
    {
        public readonly string String;
        public readonly TextStyle Style;

        public Text(string content, TextStyle style)
        {
            Validation.TextStyleValidator.Validate(nameof(style), style, content);

            String = content;
            Style = style;
        }
    }
}