using MarsRover.Core.Enums;

namespace MarsRover.Core.Domain
{
    public class RotateAction : RoverAction
    {
        public Rotation Rotation { get; }

        public RotateAction(Rotation rotation)
        {
            Rotation = rotation;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            var action = obj as RotateAction;

            return action is not null
                && Rotation == action.Rotation;
        }
    }
}