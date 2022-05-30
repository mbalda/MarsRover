using MarsRover.Core.Enums;
using MarsRover.Core.Extensions;

namespace MarsRover.Core.Domain
{
    public class Rover
    {
        public Coordinates StartPosition { get; }
        public Coordinates CurrentPosition { get; }

        public Rover() 
            : this(new Coordinates(0, 0, Direction.North))
        {}

        public Rover(Coordinates startPosition)
        {
            StartPosition = startPosition.Clone();
            CurrentPosition = startPosition.Clone();
        }

        public void DoAction(RoverAction action)
        {
            switch (action) {
                case MoveAction m:
                    Move(m);
                    break;
                case RotateAction r:
                    Rotate(r);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), "Action must be type of MoveAction or RotateAction.");
            }
        }

        private void Rotate(RotateAction action)
        {
            var rotateValue = action.Rotation == Rotation.Right ? 1 : -1;

            CurrentPosition.UpdateDirection(CalculateRotation(rotateValue));
        }

        private Direction CalculateRotation(int rotateValue)
        {
            var direction = (int)CurrentPosition.Direction;
            var rotatedDirection = (direction + rotateValue).Modulo(4);

            return (Direction)rotatedDirection;
        }

        private void Move(MoveAction action)
        {
            if (CurrentPosition.IsNorthSouthLine)
                MoveTowardNorthSouthLine(action);
            else
                MoveTowardEastWestLine(action);
        }

        private void MoveTowardEastWestLine(MoveAction action)
        {
            if (CurrentPosition.Direction == Direction.East
                && action.Move == Enums.Move.Forward
                || CurrentPosition.Direction == Direction.West
                && action.Move == Enums.Move.Backward)

                CurrentPosition.UpdateCoordinates(1, 0);
            else
                CurrentPosition.UpdateCoordinates(-1, 0);
        }

        private void MoveTowardNorthSouthLine(MoveAction action)
        {
            if (CurrentPosition.Direction == Direction.North
                && action.Move == Enums.Move.Forward
                || CurrentPosition.Direction == Direction.South
                && action.Move == Enums.Move.Backward)

                CurrentPosition.UpdateCoordinates(0, 1);
            else 
                CurrentPosition.UpdateCoordinates(0, -1);
        }
    }
}