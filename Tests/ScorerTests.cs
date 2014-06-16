using CribbageCountr;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class ScorerTests
    {
        [Fact]
        public void GetSetsWidthOfZeroOrNegAsserts()
        {
            Card[] cards = { new Card(Suit.Club, Rank.Ace) };

            Assert.Throws(typeof(System.ArgumentOutOfRangeException),
                          () => { CribbageScorer.GetSets(0, cards); });

            Assert.Throws(typeof(System.ArgumentOutOfRangeException),
                          () => { CribbageScorer.GetSets(-1, cards); });
        }

        [Fact]
        public void GetSetsWidthOfOneReturnsSingleCardSets()
        {
            Card[] cards = 
            { 
                new Card(Suit.Club, Rank.Ace),
                new Card(Suit.Club, Rank.Two),
                new Card(Suit.Club, Rank.Three),
                new Card(Suit.Club, Rank.Four)
            };
            IEnumerable<List<Card>> sets = CribbageScorer.GetSets(1, cards);

            Assert.True(sets.Count() == 4);
            foreach (List<Card> set in sets)
            {
                Assert.True(set.Count == 1);
            }
        }
    }
}
