using CribbageCountr;
using Xunit;

namespace Tests
{
    public class CardTests
    {
        [Fact]
        public void CardSameRankAndSuitsMatch()
        {
            Card cardClubAce1 = new Card(Suit.Club, Rank.Ace);
            Card cardClubAce2 = new Card(Suit.Club, Rank.Ace);

            Assert.True(cardClubAce1.Equals(cardClubAce2));
        }

        [Fact]
        public void CardSwapActuallySwapsCards()
        {
            Card cardOneOrig = new Card(Suit.Club, Rank.Ace);
            Card cardTwoOrig = new Card(Suit.Spade, Rank.King);

            Card cardOneSwapper = new Card(cardOneOrig);
            Card cardTwoSwapper = new Card(cardTwoOrig);

            cardOneSwapper.Swap(cardTwoSwapper);
            Assert.True(cardOneOrig.Equals(cardTwoSwapper));
            Assert.True(cardTwoOrig.Equals(cardOneSwapper));
        }

        [Fact]
        public void CardDrawnMarksCardAsPlayed()
        {
            Deck deck = new Deck(false, false);
            deck.Draw(1);
            Assert.True(deck[0].Played);

            deck.Draw(4);
            Assert.True(deck[4].Played);

            // Five cards have been drawn, so the sixth shouldn't be Played yet.
            Assert.True(!deck[5].Played);
        }

        [Fact]
        public void CardSortCanSortByRank()
        {
            const int NumCards = 7;
            Card[] hand = new Card[NumCards] { 
                new Card(Suit.Club, Rank.Queen),
                new Card(Suit.Club, Rank.Six),
                new Card(Suit.Club, Rank.Ace),
                new Card(Suit.Club, Rank.Five),
                new Card(Suit.Club, Rank.King),
                new Card(Suit.Club, Rank.Two),
                new Card(Suit.Club, Rank.Ace),
            };

            System.Array.Sort(hand);

            // Go through all cards in the hand and check each card is
            // lower or equal rank as the succeeding card.
            for (short cardIdx = 0; cardIdx < NumCards - 1; cardIdx++)
            {
                Assert.True((int)hand[cardIdx].Rank <= (int)hand[cardIdx + 1].Rank);
            }
        }
    }
}
