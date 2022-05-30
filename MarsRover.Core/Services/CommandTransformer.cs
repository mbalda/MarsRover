using MarsRover.Core.Domain;
using MarsRover.Core.Enums;
using static System.String;

namespace MarsRover.Core.Services
{
    public class CommandTransformer : ICommandTransformer
    {
        private Dictionary<char, RoverAction> CommandToActionMapper { get; } 
            = new Dictionary<char, RoverAction>()
            {
                { 'F', new MoveAction(Move.Forward) },
                { 'B', new MoveAction(Move.Backward) },
                { 'R', new RotateAction(Rotation.Right) },
                { 'L', new RotateAction(Rotation.Left) }
            };

        public Queue<RoverAction> Transform(string commands)
        {
            if(IsNullOrWhiteSpace(commands))
                return new Queue<RoverAction>();

            var _roverActions = new Queue<RoverAction>(commands.Select(c => CommandToActionMapper[c]));

            return _roverActions;
        }
    }
}