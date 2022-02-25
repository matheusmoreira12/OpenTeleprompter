using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenTeleprompter.Data
{
    public sealed class Text
    {
        public readonly string Content;
        public readonly TextStyle Style;

        public Text(string content, TextStyle style)
        {
            Validation.TextStyleValidator.Validate(nameof(style), style, content);

            Content = content;
            Style = style;
        }

        public TextStyleOptions[] GetIndividualCharacterStyles()
        {
            IEnumerable<TextStyleOptions> reverseGetCharacterStyles() {
                var reversedIntervals = Style.Intervals.Reverse();
                var reversedIntervalsEnumerator = reversedIntervals.GetEnumerator();
                reversedIntervalsEnumerator.MoveNext();
                var interval = reversedIntervalsEnumerator.Current;
                int length = Content.Length;
                return Content.Reverse().Select((character, i) =>
                    {
                        int position = length - 1 - i;
                        if (position < interval.Start)
                            goToPreviousInterval();

                        return interval.Options;
                    });

                void goToPreviousInterval() {
                    if (reversedIntervalsEnumerator.MoveNext())
                        interval = reversedIntervalsEnumerator.Current;
                }
            }

            return reverseGetCharacterStyles().ToArray();
        }
    }
}