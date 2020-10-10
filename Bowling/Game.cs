using System;

namespace Bowling
{
    public class Game
    {
        public int Score { get; private set; } = 0;
        Round[] rounds = new Round[10];
        int roundIndex = 0;
        bool firstBall = true;

        public Game()
        {
        }

        public void Roll(int pins)
        {
            Score += pins;
            Round round = CurrentRound();

            Round previousRound = PreviousRound();
            if (previousRound != null && previousRound.IsStrike())
            {
                Score += pins;
                previousRound.Score += pins;

                if (roundIndex > 1) {
                    Round roundBeforeThat = rounds[roundIndex - 2];
                    if (roundBeforeThat.IsStrike())
                    {
                        Score += pins;
                        roundBeforeThat.Score += pins;
                    }
                }
            }

            if (firstBall)
            {
                round.FirstBall = pins;
                round.Score += pins;

                if (previousRound != null && previousRound.IsSpare())
                {
                    Score += pins;
                    previousRound.Score += pins;
                }

                if (round.IsStrike())
                    roundIndex++;
                else
                    firstBall = false;
            }
            else {
                round.SecondBall = pins;
                round.Score = Score;
                firstBall = true;
                roundIndex++;
            }
        }

        public Round CurrentRound()
        {
            if (rounds[roundIndex] == null)
                rounds[roundIndex] = new Round();
            return rounds[roundIndex];
        }

        public Round PreviousRound()
        {
            if (roundIndex == 0)
                return null;
            return rounds[roundIndex-1];
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
