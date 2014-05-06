
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

        [Fact]
        public void SuitRankJokerMismatchThrowsExcept()
        {
            Card mismatched;
            Deck deck = new Deck(true, true);

            mismatched = new Card (Suit.Joker, Rank.Ace);
            Assert.Throws<System.ArgumentException>(() => deck.AddCard(mismatched));

            mismatched = new Card(Suit.Club, Rank.Joker);
            Assert.Throws<System.ArgumentException>(() => deck.AddCard(mismatched));
        }

        [Fact]
        public void DeckIndexerReturnsACard()
        {
            Deck deck = new Deck();
            Card indexedCard = deck[0];
            Assert.IsType(typeof(Card), indexedCard);
            Assert.NotNull(indexedCard);
        }

        [Fact]
        public void DeckInvalidIndexesThrowsExcpt()
        {
            Deck deck = new Deck();
            Assert.Throws<System.ArgumentOutOfRangeException>(() => deck[-1]);
            Assert.Throws<System.ArgumentOutOfRangeException>(() => deck[99]);
        }

        [Fact]
        public void ShuffleDoesAShuffle()
        {
            // TODO: Implement this test.
            // Need to make an unshuffled deck, and then a shuffled deck.
            // And then compare the two collections of cards.
            // The problem currently is that the cards are not exposed,
            // and I don't want to expose them just for the sake of a test.
        }
    }
}
