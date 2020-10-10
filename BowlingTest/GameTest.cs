using NUnit.Framework;
using Bowling;

namespace BowlingTest
{
    public class GameTest
    {
        Game game = new Game();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddBallToScore()
        {
            game.Roll(3);
            Assert.AreEqual(3, game.Score);
        }

        [Test]
        public void RollFirstFrame()
        {
            game.Roll(3);
            game.Roll(4);
            Assert.AreEqual(7, game.Score);
        }

        [Test]
        public void ShowScoreForFirstFrame()
        {
            game.Roll(3);
            game.Roll(4);

            Round round = game.Round(0);

            Assert.AreEqual("[3][4][7]", round.ToString());
        }


        [Test]
        public void ShowScoreForLastFrame()
        {
            for (int i = 0; i < 10; i++)
            {
                game.Roll(3);
                game.Roll(4);
            }


            Round round = game.Round(9);
            Assert.AreEqual("[3][4][70]", round.ToString());
        }
    }
}
