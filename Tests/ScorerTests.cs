using CribbageCountr;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class ScorerTests
    {
        [Fact]
        public void PairsTests()
        {
            Card[] cardsOnePair = 
            {
                new Card(Suit.Club,  Rank.Ace),
                new Card(Suit.Club,  Rank.Two),
                new Card(Suit.Club,  Rank.Three),
                new Card(Suit.Club,  Rank.Four),
                new Card(Suit.Spade, Rank.Four)
            };
            Assert.Equal((int)CribbageScorer.PointsPer.Pair, 
                         CribbageScorer.ScorePairs(cardsOnePair));

            Card[] cardsTwoDiffPair = 
            {
                new Card(Suit.Club,  Rank.Ace),
                new Card(Suit.Club,  Rank.Two),
                new Card(Suit.Spade, Rank.Two),
                new Card(Suit.Club,  Rank.Four),
                new Card(Suit.Spade, Rank.Four)
            };
            Assert.Equal((int)CribbageScorer.PointsPer.Pair * 2,
                         CribbageScorer.ScorePairs(cardsTwoDiffPair));

            Card[] cardsThreeOfKind = 
            {
                new Card(Suit.Club,  Rank.Ace),
                new Card(Suit.Club,  Rank.Two),
                new Card(Suit.Club,  Rank.Four),
                new Card(Suit.Spade, Rank.Four),
                new Card(Suit.Heart, Rank.Four)
            };
            Assert.Equal((int)CribbageScorer.PointsPer.OfKind3, 
                         CribbageScorer.ScorePairs(cardsThreeOfKind));

            Card[] cardsOneAndThreePairs =
            {
                new Card(Suit.Club,  Rank.Ace),
                new Card(Suit.Spade, Rank.Ace),
                new Card(Suit.Club,  Rank.Four),
                new Card(Suit.Spade, Rank.Four),
                new Card(Suit.Heart, Rank.Four)
            };
            const int ExpectedScore =
                (int)CribbageScorer.PointsPer.Pair +    // Pair of aces
                (int)CribbageScorer.PointsPer.OfKind3;  // Three pairs of fours
            Assert.Equal(ExpectedScore, CribbageScorer.ScorePairs(cardsOneAndThreePairs));

            Card[] cardsFourOfKind =
            {
                new Card(Suit.Club,    Rank.Ace),
                new Card(Suit.Diamond, Rank.Four),
                new Card(Suit.Club,    Rank.Four),
                new Card(Suit.Spade,   Rank.Four),
                new Card(Suit.Heart,   Rank.Four)
            };
            Assert.Equal((int)CribbageScorer.PointsPer.OfKind4,
                         CribbageScorer.ScorePairs(cardsFourOfKind));
        }
        
        [Fact]
        public void RunsOf3Tests()
        {
            Card[] runOf3First3 =
            {
                new Card(Suit.Club,    Rank.Ace),
                new Card(Suit.Club,    Rank.Two),
                new Card(Suit.Club,    Rank.Three),
                new Card(Suit.Club,    Rank.Queen),
                new Card(Suit.Club,    Rank.King)
            };

            Assert.Equal((int)CribbageScorer.PointsPer.Run3,
                          CribbageScorer.ScoreRuns(runOf3First3));

            Card[] runOf3middle3 =
            {
                new Card(Suit.Club,    Rank.King),
                new Card(Suit.Club,    Rank.Two),
                new Card(Suit.Club,    Rank.Three),
                new Card(Suit.Club,    Rank.Four),
                new Card(Suit.Club,    Rank.Queen)
            };

            Assert.Equal((int)CribbageScorer.PointsPer.Run3,
                         CribbageScorer.ScoreRuns(runOf3middle3));

            Card[] runOf3Last3 =
            {
                new Card(Suit.Club,    Rank.King),
                new Card(Suit.Club,    Rank.Queen),
                new Card(Suit.Club,    Rank.Three),
                new Card(Suit.Club,    Rank.Four),
                new Card(Suit.Club,    Rank.Five)
            };

            Assert.Equal((int)CribbageScorer.PointsPer.Run3,
                         CribbageScorer.ScoreRuns(runOf3Last3));
        }

        [Fact]
        public void RunsOf4Tests()
        {
            Card[] runOf4First4 =
            {
                new Card(Suit.Club,    Rank.Ace),
                new Card(Suit.Club,    Rank.Two),
                new Card(Suit.Club,    Rank.Three),
                new Card(Suit.Club,    Rank.Four),
                new Card(Suit.Club,    Rank.King)
            };

            Assert.Equal((int)CribbageScorer.PointsPer.Run4,
                          CribbageScorer.ScoreRuns(runOf4First4));

            Card[] runOf4Last4 = 
            {
                new Card(Suit.Club,    Rank.Queen),
                new Card(Suit.Club,    Rank.Ace),
                new Card(Suit.Club,    Rank.Two),
                new Card(Suit.Club,    Rank.Three),
                new Card(Suit.Club,    Rank.Four)
            };

            Assert.Equal((int)CribbageScorer.PointsPer.Run4,
                         CribbageScorer.ScoreRuns(runOf4Last4));

            // TODO: Runs of 4 with a pair in the middle
        }

        [Fact]
        public void RunsOf5Tests()
        {
            Card[] runOf5All5 =
            {
                new Card(Suit.Club,    Rank.Ace),
                new Card(Suit.Club,    Rank.Two),
                new Card(Suit.Club,    Rank.Three),
                new Card(Suit.Club,    Rank.Four),
                new Card(Suit.Club,    Rank.Five)
            };

            Assert.Equal((int)CribbageScorer.PointsPer.Run5,
                          CribbageScorer.ScoreRuns(runOf5All5));
        }

        [Fact]
        public void RunsOf3Double()
        {
            Card[] runOf3TwoPairsFirst =
            {
                new Card(Suit.Club,    Rank.Ace),
                new Card(Suit.Club,    Rank.Ace),
                new Card(Suit.Club,    Rank.Two),
                new Card(Suit.Club,    Rank.Two),
                new Card(Suit.Club,    Rank.Three)
            };

            Assert.True(0 == 1);
        }

        [Fact]
        public void RunsOf3Triple()
        {
            Card[] runOf3TwoPairsFirst =
            {
                new Card(Suit.Club,    Rank.Ace),
                new Card(Suit.Club,    Rank.Ace),
                new Card(Suit.Club,    Rank.Ace),
                new Card(Suit.Club,    Rank.Two),
                new Card(Suit.Club,    Rank.Three)
            };

            Assert.True(0 == 1);
        }

        [Fact]
        public void RunsOf3DoubleDouble()
        {
            Card[] runOf3TwoPairsFirst =
            {
                new Card(Suit.Club,    Rank.Ace),
                new Card(Suit.Club,    Rank.Ace),
                new Card(Suit.Club,    Rank.Two),
                new Card(Suit.Club,    Rank.Two),
                new Card(Suit.Club,    Rank.Three)
            };

            Assert.True(0 == 1);
        }
    }
}
