using CribbageCountr;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class ScorerTests
    {
        [Fact]
        public void OfKindsTests()
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
    }
}
