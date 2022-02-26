using System;
namespace OpenTeleprompter.Data.Validation
{
    internal static class TextStyleValidator
    {
        public static void Validate(string paramName, TextStyle textStyle, string content)
        {
            var intervals = textStyle.Intervals;

            if (intervals.Length == 0)
                throw new ArgumentException("At least one text style interval was expected.",
                    paramName);

            if (intervals[0].Start == 0)
                throw new ArgumentException("First text style interval does not start at 0.",
                    paramName);

            if (!areIntervalsInAscendingStartOrder())
                throw new ArgumentException("Some text style intervals are not in ascending order.",
                    paramName);

            if (!allIntervalsWithinBounds())
                throw new ArgumentException("Some text style intervals are out of the text bounds.",
                    paramName);

            bool areIntervalsInAscendingStartOrder()
            {
                for (int i = 1; i < intervals.Length; i++)
                {
                    if (intervals[i - 1].Start >= intervals[i].Start)
                        return false;
                }
                return true;
            }

            bool allIntervalsWithinBounds()
            {
                var lastInterval = intervals[intervals.Length - 1];
                return lastInterval.Start <= content.Length - 1;
            }
        }
    }
}
