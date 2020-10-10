using NUnit.Framework;
using Bowling;

namespace BowlingTest
{
    public class RoundTest
    {
        Round round;

        [SetUp]
        public void Setup()
        {
            round = new Round();
        }

        [Test]
        public void NormalRound()
        {
            round.FirstBall = 3;
            round.SecondBall = 4;
            Assert.IsFalse(round.IsSpare());
            Assert.IsFalse(round.IsStrike());
        }

        [Test]
        public void SpareRound()
        {
            round.FirstBall = 3;
            round.SecondBall = 7;
            Assert.IsTrue(round.IsSpare());
            Assert.IsFalse(round.IsStrike());
        }

        [Test]
        public void StrikeRound()
        {
            round.FirstBall = 10;
            Assert.IsFalse(round.IsSpare());
            Assert.IsTrue(round.IsStrike());
        }

    }
}
