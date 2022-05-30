using MarsRover.Core.Enums;

namespace MarsRover.Core.Domain
{
    public class MoveAction : RoverAction
    {
        public Move Move { get; }

        public MoveAction(Move move)
        {
            Move = move;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            var action = obj as MoveAction;

            return action is not null
                && Move == action.Move;
        }
    }
}