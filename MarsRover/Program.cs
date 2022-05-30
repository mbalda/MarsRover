using MarsRover.Core.Services;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            IRoverController _roverController = ServiceConfiguration.GetRoverController;
            var startCoordinates = string.Empty;
            var commands = string.Empty;

            if (_roverController is null)
                Console.WriteLine("Rover controller not initialized!.");
            else
            {
                Console.WriteLine("Hello on Mars!");
                Console.WriteLine();

                if (args.Any() && args[0] is not null)
                {
                    startCoordinates = args[0];

                    if (args[1] is not null)
                    {
                        commands = args[1];
                    }
                }

                if (string.IsNullOrWhiteSpace(startCoordinates))
                {
                    Console.WriteLine("Provide start coordinates for Mars Rover!");
                    Console.WriteLine("Coordinates should be in format of two integer numbers separated by ',' and starting direction: North,East,South,West");

                    startCoordinates = Console.ReadLine();
                }

                _roverController.SetStartPosition(startCoordinates);

                if (string.IsNullOrWhiteSpace(commands))
                {
                    Console.WriteLine("Provide commands for Mars Rover!");
                    commands = Console.ReadLine();
                }

                _roverController.ExecuteCommands(commands);
                var endPosition = _roverController.GetEndPosition();

                Console.WriteLine($"Current position of Mars Rover is: {endPosition}");
                Console.ReadKey();
            }
        }
    }
}