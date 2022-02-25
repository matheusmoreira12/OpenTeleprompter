using System;

namespace OpenTeleprompter.Data
{
    public sealed class TextStyle
    {
        public TextStyle(TextStyleInterval[] intervals)
        {
            Intervals = intervals;
        }

        public readonly TextStyleInterval[] Intervals;
    }
}