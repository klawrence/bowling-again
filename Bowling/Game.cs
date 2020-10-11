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
            Round round = CurrentRound();            
            if (round.Previous != null && round.Previous.IsStrike())
            {
                Score += pins;
                round.Previous.Score += pins;

                if (roundIndex > 1 && roundIndex < 11) {
                    Round roundBeforeThat = rounds[roundIndex - 2];
                    if (roundBeforeThat.IsStrike())
                    {
                        Score += pins;
                        roundBeforeThat.Score += pins;
                    }
                }
            }

            Score += pins;

            if (firstBall)
            {
                round.FirstBall = pins;
                round.Score += pins;

                if (round.IsStrike())
                    roundIndex++;
                else
                    firstBall = false;

                if (round.Previous != null && round.Previous.IsSpare())
                {
                    Score += pins;
                    round.Previous.Score += pins;
                }
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
                rounds[roundIndex] = new Round(PreviousRound());
            return rounds[roundIndex];
        }

        public Round PreviousRound()
        {
            if (roundIndex == 0 || roundIndex > rounds.Length)
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
