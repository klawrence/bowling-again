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

            int[] round = game.Round(0);

            Assert.AreEqual(3, round[0]);
            Assert.AreEqual(4, round[1]);
            Assert.AreEqual(7, round[2]);
        }


        [Test]
        public void ShowScoreForLastFrame()
        {
            for (int i = 0; i < 10; i++)
            {
                game.Roll(3);
                game.Roll(4);
            }


            int[] round = game.Round(9);

            Assert.AreEqual(3, round[0]);
            Assert.AreEqual(4, round[1]);
            Assert.AreEqual(70, round[2]);

        }
    }
}
