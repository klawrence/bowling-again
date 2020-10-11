﻿using System;

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
            round.Roll(pins);
            Score += pins;

            if (round.Previous != null && round.Previous.IsStrike())
            {
                Score += pins;
                round.Previous.Score += pins;

                Round roundBeforeThat = round.Previous.Previous;
                if (roundBeforeThat != null && roundBeforeThat.IsStrike())
                {
                    Score += pins;
                    roundBeforeThat.Score += pins;
                }
            }


            if (round.IsComplete)
            {
                roundIndex++;

            }
            else {
                if (round.Previous != null && round.Previous.IsSpare())
                    Score += pins;
            }
        }

        public Round CurrentRound()
        {
            Round round = rounds[roundIndex];
            if (round == null)
            {
                if (roundIndex == 0)
                    round = new Round();
                else
                    round = new Round(rounds[roundIndex-1]);

                rounds[roundIndex] = round;
            }

            return rounds[roundIndex];
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
