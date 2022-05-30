using MarsRover.Core.Domain;

namespace MarsRover.Core.Services
{
    public class RoverController : IRoverController
    {
        private Coordinates _startPosition;
        private Coordinates _endPosition;

        private readonly ICommandTransformer _commandTransformer;
        private readonly ICommandValidator _commandValidator;

        public RoverController(ICommandTransformer commandTransformer, ICommandValidator validator)
        {
            _commandTransformer = commandTransformer;
            _commandValidator = validator;
        }

        public void ExecuteCommands(string commands)
        {
            Rover rover = CreateNewRover();

            commands = PrepareCommands(commands);

            if (!AreCommandsValid(commands))
                throw new ArgumentOutOfRangeException(nameof(commands), "Commands must contain only letters: B, F, R, L.");

            var roverActions = TransformCommands(commands);

            foreach (var action in roverActions)
            {
                rover.DoAction(action);
            }

            _endPosition = rover.CurrentPosition;
        }

        public void SetStartPosition(string startPosition)
        {
            _startPosition = new Coordinates(startPosition);
            _endPosition = new Coordinates(startPosition);
        }

        public string? GetEndPosition() => _endPosition?.ToString();

        private bool AreCommandsValid(string commands) => _commandValidator.Validate(commands);

        private IEnumerable<RoverAction> TransformCommands(string commands) => _commandTransformer.Transform(commands);

        private Rover CreateNewRover() => _startPosition is null ? new Rover() : new Rover(_startPosition);

        private string? PrepareCommands(string commands) => commands?.Trim().ToUpper();
    }
}
