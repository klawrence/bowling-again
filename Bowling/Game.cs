using System;

namespace Bowling
{
    public class Game
    {
        public int Score { get; private set; } = 0;
        int[][] rounds = new int[10][];
        bool firstBall = true;
        int roundIndex = 0;

        public Game()
        {
        }

        public void Roll(int pins)
        {
            Score += pins;
            if (firstBall)
            {
                int[] round = rounds[roundIndex] = new int[3];
                round[0] = pins;
                firstBall = false;
            }
            else {
                int[] round = rounds[roundIndex];
                round[1] = pins;
                round[2] = round[0] + round[1];
            }
        }

        public int[] Round(int round)
        {
            return rounds[round];
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
