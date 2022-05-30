using MarsRover.Core.Enums;
using static System.String;

namespace MarsRover.Core.Domain
{
    public class Coordinates
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Direction Direction { get; private set; }

        public Coordinates(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public Coordinates(string coordinatesAsString)
        {
            if (IsNullOrWhiteSpace(coordinatesAsString))
                throw new ArgumentNullException(nameof(coordinatesAsString), "Coordinates must be in format: X,Y,Direction.");

            var parts = coordinatesAsString.Split(',');

            if (parts.Length != 3)
                throw new ArgumentException(nameof(coordinatesAsString), "Coordinates must be in format: X,Y,Direction.");

            if (!int.TryParse(parts[0], out var x)
                || !int.TryParse(parts[1], out var y)
                || !TryParseDirection(parts[2], out var direction))
                throw new ArgumentException(nameof(coordinatesAsString), "Coordinates must be in format: X,Y,Direction.");

            X = x;
            Y = y;
            Direction = (Direction)direction;
        }

        public void UpdateCoordinates(int x, int y) 
        {
            X += x;
            Y += y;
        }

        public void UpdateDirection(Direction direction)
        {
            Direction = direction;
        }

        public bool IsNorthSouthLine => Direction == Direction.North || Direction == Direction.South;

        public Coordinates Clone()
        {
            return new Coordinates(X, Y, Direction);
        }

        public override string ToString()
        {
            return $"X = {X}, Y = {Y}, {Direction}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;
            
            var coordinates = obj as Coordinates;

            return coordinates is not null
                && X == coordinates.X 
                && Y == coordinates.Y
                && Direction == coordinates.Direction;
        }

        private bool TryParseDirection(string direction, out object result)
        { 
            return Enum.TryParse(typeof(Direction), direction.Trim(), true, out result);
        }
    }
}
