using System;
using RobotWars.Battle;

namespace RobotWars.InputParsers
{
    public class GridSizeParser : IGridSizeParser
    {
        public GridSize Parse(String text)
        {
            if (text == null)
                throw new ArgumentNullException("text");
            if (String.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Parameter cannot be empty or whitespace", "text");

            var segments = text.Split(' ');
            if (segments.Length < 2)
                throw new TooFewSegmentsException();
            if (segments.Length > 2)
                throw new TooManySegmentsException();

            var width = GetDimensionValue(segments[0], s => new InvalidWidthException(s));
            var height = GetDimensionValue(segments[1], s => new InvalidHeightException(s));
            return GridSize.From(width, height);
        }

        private static int GetDimensionValue(String segment, Func<String, Exception> exceptionProvider)
        {
            Int32 dimensionValue;
            if (!Int32.TryParse(segment, out dimensionValue))
                throw exceptionProvider(segment);

            return dimensionValue;
        }
    }
}