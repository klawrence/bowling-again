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
        public void ShowScorecard()
        {
            Assert.AreEqual("[ ][ ] [ ]", round.ToString());

            round.Roll(3);
            Assert.AreEqual("[3][ ] [3]", round.ToString());

            round.Roll(4);
            Assert.AreEqual("[3][4] [7]", round.ToString());
        }


        [Test]
        public void ShowScorecardForSpare()
        {
            round.Roll(3);
            round.Roll(7);
            Assert.AreEqual("[3][/] [10]", round.ToString());
        }

        [Test]
        public void ShowScorecardForStrike()
        {
            round.Roll(10);
            Assert.AreEqual("[X][ ] [10]", round.ToString());
        }

        [Test]
        public void ShowScorecardThreeStrikes()
        {
            round.LastRound = true;
            round.Roll(10);
            Assert.AreEqual("[X][ ][ ] [10]", round.ToString());
            round.Roll(10);
            Assert.AreEqual("[X][X][ ] [20]", round.ToString());
            round.Roll(10);
            Assert.AreEqual("[X][X][X] [30]", round.ToString());
        }

        [Test]
        public void ShowScorecardSpareInTheLastRound()
        {
            round.LastRound = true;
            round.Roll(5);
            Assert.AreEqual("[5][ ][ ] [5]", round.ToString());
            round.Roll(5);
            Assert.AreEqual("[5][/][ ] [10]", round.ToString());
            round.Roll(10);
            Assert.AreEqual("[5][/][X] [20]", round.ToString());
        }

    }
}
