using CribbageCountr;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class ScorerTests
    {
        [Fact]
        public void TwoOfKindTests()
        {
            Card[] cardsOnePair = 
            {
                new Card(Suit.Club,  Rank.Five),
                new Card(Suit.Spade, Rank.Five)
            };
            Assert.Equal(2, CribbageScorer.ScoreOfKind2(cardsOnePair));

            Card[] cardsThreePair = 
            {
                new Card(Suit.Club,  Rank.Five),
                new Card(Suit.Spade, Rank.Five),
                new Card(Suit.Heart, Rank.Five)
            };
            Assert.Equal(6, CribbageScorer.ScoreOfKind2(cardsThreePair));

            Card[] cardsNoPair =
            {
                new Card(Suit.Club,  Rank.Ace),
                new Card(Suit.Spade, Rank.Two)
            };
            Assert.Equal(0, CribbageScorer.ScoreOfKind2(cardsNoPair));
        }
    }
}
