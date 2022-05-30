using MarsRover.Core.Domain;

namespace MarsRover.Core.Services
{
    public interface ICommandTransformer
    {
        Queue<RoverAction> Transform(string commands);
    }
}