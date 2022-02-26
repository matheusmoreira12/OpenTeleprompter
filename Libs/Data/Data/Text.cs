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
            String = content;
            Style = style;
        }
    }
}