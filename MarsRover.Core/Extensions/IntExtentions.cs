namespace MarsRover.Core.Extensions
{
    public static class IntExtentions
    {
        public static int Modulo(this int x, int N)
        {
            return (x % N + N) % N;
        }
    }
}
