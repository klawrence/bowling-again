using System;
namespace Bowling
{
    public class Round
    {
        public int FirstBall { get; set; }
        public int SecondBall { get; set; }
        public int Score { get; set; }
        public Round Previous { get; private set; }

        public bool IsFirstBall { get; private set; } = true;
        public bool IsComplete { get; private set; } = false;

        public Round(Round previousRound)
        {
            Previous = previousRound;
            Score = Previous.Score;
        }

        public Round()
        {
        }

        public void Roll(int pins)
        {
            Score += pins;

            if (IsFirstBall)
            {
                FirstBall = pins;
                IsFirstBall = false;

                IsComplete = IsStrike();

                if (Previous != null && Previous.IsSpare())
                {
                    Score += pins;
                    Previous.Score += pins;
                }
            }
            else
            {
                SecondBall = pins;
                IsComplete = true;
            }

            if (Previous != null && Previous.IsStrike())
            {
                Score += pins;
                Previous.Score += pins;

                if (Previous.Previous != null && Previous.Previous.IsStrike())
                {
                    Score += pins;
                    Previous.Previous.Score += pins;
                }
            }


        }

        public bool IsSpare()
        {
            return ! IsStrike() && FirstBall + SecondBall == 10;
        }

        public bool IsStrike()
        {
            return FirstBall == 10;
        }

        public override string ToString()
        {
            if (IsStrike())
                return $"[X][ ][{Score}]";

            if (IsSpare())
                return $"[{FirstBall}][/][{Score}]";

            return $"[{FirstBall}][{SecondBall}][{Score}]";
        }
    }
}
