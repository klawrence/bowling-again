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
    }
}