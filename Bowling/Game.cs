using System;

namespace Bowling
{
    public class Game
    {
        public int Score { get; private set; } = 0;

        public void Roll(int pins)
        {
            Score += pins;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
