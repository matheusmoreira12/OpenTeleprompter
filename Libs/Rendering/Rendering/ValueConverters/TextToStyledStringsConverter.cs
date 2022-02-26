using System.Collections.Generic;
using System.Linq;
using OpenTeleprompter.Data;
using Rendering.StyledText;

namespace OpenTeleprompter.Rendering.ValueConverters
{
    public sealed class TextToStyledStringsConverter : ValueConverter<Text, StyledString[]>
    {
        public override StyledString[] Convert(Text value)
        {
            var textAsString = value.String;
            var styleIntervals = value.Style.Intervals;
            return styleIntervals.Select((interval) =>
                {
                    string str = textAsString.Substring(interval.Start,
                        interval.End - interval.Start + 1);
                    return StyledString.FromString(str, interval.Options);
                }).ToArray();
        }

        public override StyledString[] ConvertBack(Text value)
        {
            throw new System.InvalidOperationException();
        }
    }
}