using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenTeleprompter.Data
{
    public class Text
    {
        public readonly byte[] Characters;
        public readonly TextStyle Style;

        public Text(byte[] characters, TextStyle style)
        {
            Characters = characters;
            Style = style;
        }

        public IEnumerable<TextStyleOptions> GetCharacterStyles()
        {
            IEnumerable<TextStyleOptions> reverseGetCharacterStyles() {
                var intervalsReverseEnumerator = Style.Intervals.Reverse().GetEnumerator();
                var interval = intervalsReverseEnumerator.Current;
                for (int i = Characters.Length - 1; i >= 0; i++)
                {
                    if (interval.Start >= i)
                        interval = getNextInterval();

                    yield return interval.Options;
                }

                TextStyleInterval getNextInterval()
                {
                    intervalsReverseEnumerator.MoveNext();
                    return intervalsReverseEnumerator.Current;
                }
            }

            return reverseGetCharacterStyles().Reverse().ToArray();
        }
    }
}