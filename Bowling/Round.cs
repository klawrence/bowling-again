using System;
namespace Bowling
{
    public class Round
    {
        public int FirstBall { get; set; }
        public int SecondBall { get; set; }
        public int Score { get; set; }
        public Round Previous { get; private set; }

        public Round(Round previousRound)
        {
            Previous = previousRound;
        }

        public Round()
        {
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
