using System.Collections.Generic;

namespace Bowling
{
    public class Round
    {
        public int Score { get; set; }
        public Round Previous { get; private set; }

        private List<int> balls = new List<int>();
        public bool IsComplete { get; private set; }
        public bool LastRound { get; set; }
        private int bonusBalls;

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
            balls.Add(pins);

            if (IsComplete)
                bonusBalls++;

            if (balls.Count == 1)
            {
                IsComplete = IsStrike();

                if (Previous != null && Previous.IsSpare())
                {
                    Score += pins;
                    Previous.Score += pins;
                }
            }
            else
            {
                IsComplete = true;
            }

            if (bonusBalls < 2 && Previous != null && Previous.IsStrike())
            {
                Score += pins;
                Previous.Score += pins;

                if (bonusBalls == 0 && Previous.Previous != null && Previous.Previous.IsStrike())
                {
                    Score += pins;
                    Previous.Previous.Score += pins;
                }
            }
        }

        public bool IsSpare()
        {
            return balls.Count > 1 && balls[0] + balls[1] == 10;
        }

        public bool IsStrike()
        {
            return balls[0] == 10;
        }

        public override string ToString()
        {
            string total = balls.Count > 0 ? Score.ToString() : " ";
            string[] scores = {" ", " ", " "};

            for (int i = 0; i < balls.Count; i++)
            {
                if (IsStrike())
                    scores[i] = "X";
                else if (IsSpare() && i == 1)
                    scores[i] = "/";
                else if (LastRound && balls[i] == 10)
                    scores[i] = "X";
                else
                    scores[i] = balls[i].ToString();
            }

            if(LastRound)
                return $"[{scores[0]}][{scores[1]}][{scores[2]}] [{total}]";
            return $"[{scores[0]}][{scores[1]}] [{total}]";
        }
    }
}
