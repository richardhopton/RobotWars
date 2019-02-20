using System;
using System.Collections.Generic;
using System.Linq;
using RobotWars.Battle;

namespace RobotWars.InputParsers
{
    public class PositionParser : IPositionParser
    {
        private readonly IEnumerable<ICardinalCompassPointResolver> _cardinalCompassPointResolvers;

        public PositionParser(IEnumerable<ICardinalCompassPointResolver> cardinalCompassPointResolvers)
        {
            _cardinalCompassPointResolvers = cardinalCompassPointResolvers;
        }

        public Position Parse(String text)
        {
            if (text == null)
                throw new ArgumentNullException("text");
            if (String.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Parameter cannot be empty or whitespace", "text");

            var segments = text.Split(' ');
            if (segments.Length < 3)
                throw new TooFewSegmentsException();
            if (segments.Length > 3)
                throw new TooManySegmentsException();

            var xCoordinate = GetCoordinateValue(segments[0], s => new InvalidXCoordinateException(s));
            var yCoordinate = GetCoordinateValue(segments[1], s => new InvalidYCoordinateException(s));
            var cardinalCompassPoint = Resolve(segments[2]);
            return Position.From(xCoordinate, yCoordinate, cardinalCompassPoint);
        }

        private static int GetCoordinateValue(String segment, Func<String, Exception> exceptionProvider)
        {
            Int32 coordinateValue;
            if (!Int32.TryParse(segment, out coordinateValue))
                throw exceptionProvider(segment);

            return coordinateValue;
        }

        private CardinalCompassPoint Resolve(String input)
        {
            if(input.Length>1)
                throw new ArgumentOutOfRangeException("input", input, "Parameter too long");

            return Resolve(input[0]);
        }
            
        private CardinalCompassPoint Resolve(Char input)
        {
            var cardinalCompassPoint = _cardinalCompassPointResolvers
                .Select(rsr => rsr.Resolve(input))
                .FirstOrDefault(rs => rs != null);

            if (cardinalCompassPoint == null)
                throw new UnableToResolveCardinalCompassPointException(input);

            return cardinalCompassPoint;
        }
    }
}