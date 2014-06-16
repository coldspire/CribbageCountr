using CribbageCountr;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class ScorerTests
    {
        // Test that GetSets() asserts when width <= 0 is passed in

        [Fact]
        public void WidthOfOneReturnsSingleCardSets()
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
