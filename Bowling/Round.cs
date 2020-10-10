using System;
namespace Bowling
{
    public class Round
    {
        public int FirstBall { get; set; }
        public int SecondBall { get; set; }
        public int Score { get; set; }

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
            return $"[{FirstBall}][{SecondBall}][{Score}]";
        }
    }
}
