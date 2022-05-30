namespace MarsRover.Core.Services
{
    public interface ICommandValidator
    {
        bool Validate(string commands);
    }
}