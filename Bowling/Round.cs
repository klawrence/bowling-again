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

        public override string ToString()
        {
            return $"[{FirstBall}][{SecondBall}][{Score}]";
        }
    }
}
