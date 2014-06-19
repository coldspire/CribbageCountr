﻿using CribbageCountr;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class ScorerTests
    {
        private Card[] cards1 = 
        { 
            new Card(Suit.Club, Rank.Ace) 
        };

        Card[] cards4 = 
        { 
            new Card(Suit.Club, Rank.Ace),
            new Card(Suit.Club, Rank.Two),
            new Card(Suit.Club, Rank.Three),
            new Card(Suit.Club, Rank.Four)
        };

        [Fact]
        public void GetSetsWidthOfZeroOrNegAsserts()
        {
            Assert.Throws(typeof(System.ArgumentOutOfRangeException),
                          () => { CribbageScorer.GetSets(0, cards1); });

            Assert.Throws(typeof(System.ArgumentOutOfRangeException),
                          () => { CribbageScorer.GetSets(-1, cards1); });
        }

        [Fact]
        public void GetSets_Width1_Cards4_Returns4Sets()
        {
            const int Width = 1;
            IEnumerable<List<Card>> sets = CribbageScorer.GetSets(Width, cards4);

            Assert.True(sets.Count() == 4);
            foreach (List<Card> set in sets)
            {
                Assert.True(set.Count == Width);
            }
        }

        [Fact]
        public void GetSets_Width2_Cards4_Returns6Sets()
        {
            const int Width = 2;
            IEnumerable<List<Card>> sets = CribbageScorer.GetSets(Width, cards4);

            Assert.True(sets.Count() == 6);
            foreach (List<Card> set in sets)
            {
                Assert.True(set.Count() == Width);
            }
        }
    }
}
