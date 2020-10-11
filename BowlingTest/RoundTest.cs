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
            round.Roll(3);
            round.Roll(4);
            Assert.IsFalse(round.IsSpare());
            Assert.IsFalse(round.IsStrike());
        }

        [Test]
        public void SpareRound()
        {
            round.Roll(3);
            round.Roll(7);
            Assert.IsTrue(round.IsSpare());
            Assert.IsFalse(round.IsStrike());
        }

        [Test]
        public void StrikeRound()
        {
            round.Roll(10);
            Assert.IsFalse(round.IsSpare());
            Assert.IsTrue(round.IsStrike());
        }

        [Test]
        public void ShowScoreCard()
        {
            Assert.AreEqual("[ ][ ] [ ]", round.ToString());

            round.Roll(3);
            Assert.AreEqual("[3][ ] [3]", round.ToString());

            round.Roll(4);
            Assert.AreEqual("[3][4] [7]", round.ToString());
        }


        [Test]
        public void ShowScoreCardForSpare()
        {
            round.Roll(3);
            round.Roll(7);
            Assert.AreEqual("[3][/] [10]", round.ToString());
        }

    }
}
