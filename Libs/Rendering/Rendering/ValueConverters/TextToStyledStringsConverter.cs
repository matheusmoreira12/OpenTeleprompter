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
            return generateStyledStrings().ToArray();

            IEnumerable<StyledString> generateStyledStrings()
            {
                var textAsString = value.String;
                var styleIntervals = value.Style.Intervals;
                for (int i = 0; i < styleIntervals.Length; i++)
                {
                    var interval = styleIntervals[i];
                    int start = interval.Start;
                    var nextInterval = i < styleIntervals.Length - 1 ? styleIntervals[i + 1] : null;
                    int end = nextInterval?.Start ?? textAsString.Length - 1;
                    string substring = textAsString.Substring(start, end - start);
                    yield return StyledString.FromString(substring, interval.Options);
                }
            }
        }

        public override StyledString[] ConvertBack(Text value)
        {
            throw new System.InvalidOperationException();
        }
    }
}