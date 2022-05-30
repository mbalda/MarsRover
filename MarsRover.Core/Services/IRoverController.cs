namespace MarsRover.Core.Services
{
    public interface IRoverController
    {
        void ExecuteCommands(string commands);
        void SetStartPosition(string startPosition);
        string? GetEndPosition();
    }
}