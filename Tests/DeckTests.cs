
using CribbageCountr;
using System.Collections.Generic;
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
        public void DeckSuitRankJokerMismatchThrowsExcept()
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
        public void DeckIndexerInvalidThrowsExcpt()
        {
            Deck deck = new Deck();
            Assert.Throws<System.ArgumentOutOfRangeException>(() => deck[-1]);
            Assert.Throws<System.ArgumentOutOfRangeException>(() => deck[deck.NumberOfCards+1]);
        }

        [Fact]
        public void DeckSliceOf5Returns5Cards()
        {
            const int NumCardsToRetrieve = 5;

            Deck deck = new Deck();
            Card[] cardsSlice = deck.Slice(NumCardsToRetrieve);

            Assert.True(cardsSlice.Length == NumCardsToRetrieve);
        }

        [Fact]
        public void DeckSliceNegativeNumThrowsExcept()
        {
            const int NegNumCardsToRetrieve = -1;
            Deck deck = new Deck();

            Assert.Throws<System.ArgumentOutOfRangeException>(() => deck.Slice(NegNumCardsToRetrieve));
        }

        [Fact]
        public void DeckSliceMoreThanAllGetsAll()
        {
            Deck deck = new Deck();

            int numTotalCards = deck.NumberOfCards;
            int numMoreThanTotal = deck.NumberOfCards + 1;

            Card[] cards = deck.Slice(numMoreThanTotal);
            Assert.True(cards.Length == numTotalCards);
        }

        // Disabled for now, because this doesn't really make sense as a unit test.
        // I could check to see if the deck changes, but a shuffled deck could result
        // in the deck ordered as it originally was (odds are 1 in 52! -- highly improbable, but possible).
        // http://stackoverflow.com/questions/1442622/testing-a-card-deck-shuffler
        // http://programmers.stackexchange.com/questions/147134/how-should-i-test-randomness
        // http://stackoverflow.com/questions/311807/unit-testing-with-functions-that-return-random-results
        /*
        [Fact]
        public void DeckShuffleDoesAShuffle()
        {
        }
        */
    }
}
