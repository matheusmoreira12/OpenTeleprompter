using System;

namespace OpenTeleprompter.Data
{
    public class TextStyle
    {
        public TextStyle(TextStyleInterval[] intervals)
        {
            ValidateIntervals(intervals);

            Intervals = intervals;
        }

        private void ValidateIntervals(TextStyleInterval[] intervals)
        {
            if (intervals.Length == 0)
                throw new ArgumentException("Style must contain at least one interval.",
                    nameof(intervals));

            if (!doesTheFirstIntervalStartAtZero())
                throw new ArgumentException("First style interval must start at character 0.",
                    nameof(intervals));

            if (!areIntervalsInAscendingStartOrder())
                throw new ArgumentException("Style intervals must come in ascending start order.",
                    nameof(intervals));

            bool doesTheFirstIntervalStartAtZero()
            {
                var first = intervals[0];
                return first.Start == 0;
            }

            bool areIntervalsInAscendingStartOrder()
            {
                TextStyleInterval lastChecked = null;
                foreach (var interval in intervals)
                {
                    if (lastChecked == null)
                        continue;
                    if (lastChecked.Start >= interval.Start)
                        return false;
                    lastChecked = interval;
                }
                return true;
            }
        }

        public readonly TextStyleInterval[] Intervals;
    }
}