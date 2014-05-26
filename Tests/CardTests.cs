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
        }
    }
}
