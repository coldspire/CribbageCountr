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
        public void GetSets_Width1_Cards4_Returns4Sets()
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

        [Fact]
        public void GetSets_Width2_Cards4_Returns6Sets()
        {
            const int Width = 2;
            Card[] cards = 
            { 
                new Card(Suit.Club, Rank.Ace),
                new Card(Suit.Club, Rank.Two),
                new Card(Suit.Club, Rank.Three),
                new Card(Suit.Club, Rank.Four)
            };
            IEnumerable<List<Card>> sets = CribbageScorer.GetSets(Width, cards);

            Assert.True(sets.Count() == 6);
            foreach (List<Card> set in sets)
            {
                Assert.True(set.Count() == Width);
            }
        }
    }
}
