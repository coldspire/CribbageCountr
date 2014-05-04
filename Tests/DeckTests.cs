using CribbageCountr;
using Xunit;

namespace Tests
{
    public class DeckTests
    {
        [Fact]
        public void DeckDefaultHas52Cards()
        {
            Deck deck = new Deck();
            Assert.Equal(52, deck.NumberOfCards);
        }

        [Fact]
        public void DeckWithJokersHas54Cards()
        {
            Deck deck = new Deck(true, false);
            Assert.Equal(54, deck.NumberOfCards);
        }

        [Fact]
        public void DeckWithOneDupeHas53Cards()
        {
            Deck deck = new Deck(false, true);
            deck.AddCard(new Card(Suit.Club, Rank.Ace));
            
            Assert.Equal(53, deck.NumberOfCards);
        }

        [Fact]
        public void DeckWithJokersOneDupeHas55Cards()
        {
            Deck deck = new Deck(true, true);
            deck.AddCard(new Card(Suit.Club, Rank.Ace));

            Assert.Equal(55, deck.NumberOfCards);
        }
    }
}
