using AutoFixture.Kernel;
using MarsRover.Core.Domain;
using MarsRover.Core.Enums;

namespace MarsRover.Tests.Common
{
    internal partial class TestsBase
    {
        protected Fixture Fixture { get; }

        public TestsBase()
        {
            Fixture = new Fixture();

            Fixture.Customize<Coordinates>(c => c.FromFactory(
                    new MethodInvoker(new GreedyConstructorQuery())));
        }

        protected static int Random() => new Random().Next(150);

        protected static void Repeat(int count, Action action)
        {
            for (int x = 0; x < count; x++)
                action();
        }

        protected static string[] GenerateAllSubsets(string[] inputDataSet)
        {
            return PowerSet(inputDataSet);
        }

        private static string[] PowerSet(string[] set)
        {
            int setSize = set.Length;
            int powerSetSize = (int)Math.Pow(2, setSize);
            
            string[] subsets = new string[powerSetSize];

            for (int counter = 0; counter < powerSetSize; counter++)
            {
                for (int internalCounter = 0; internalCounter < setSize; internalCounter++)
                {
                    if ((counter & (1 << internalCounter)) > 0)
                        subsets[counter] += set[internalCounter];
                }
            }

            return subsets;
        }
    }
}
