using static System.String;

namespace MarsRover.Core.Services
{
    public class CommandValidator : ICommandValidator
    {
        private string[] AllowedCommands = new[] { "F", "B", "L", "R" };   

        public bool Validate(string commands)
        {
            if(IsNullOrWhiteSpace(commands))
                return false;

            return commands.All(c => AllowedCommands.Any(a => a == c.ToString()));
        }
    }
}