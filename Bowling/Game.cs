using System;

namespace Bowling
{
    public class Game
    {
        public int Score { get; private set; } = 0;
        Round[] rounds = new Round[10];
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
                Round round = rounds[roundIndex] = new Round();
                round.FirstBall = pins;
                firstBall = false;
            }
            else {
                Round round = rounds[roundIndex];
                round.SecondBall = pins;
                round.Score = Score;
                firstBall = true;
                roundIndex++;
            }
        }

        public Round Round(int round)
        {
            return rounds[round];
        }

        static void Main(string[] args)
        {
            Game game = new Game();
            for (int i = 0; i < 10; i++) {
                game.Roll(3);
                game.Roll(4);
                Round round = game.Round(i);
                Console.WriteLine(round.ToString());
            }
        }
    }
}
