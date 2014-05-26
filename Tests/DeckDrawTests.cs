using CribbageCountr;
using System.Linq;
using Xunit;

namespace Tests
{
    public class DeckDrawTests
    {
        [Fact]
        public void DeckDrawOf5Returns5Cards()
        {
            const int NumCardsToRetrieve = 5;

            Deck deck = new Deck();
            Card[] cards = deck.Draw(NumCardsToRetrieve).ToArray();

            Assert.True(cards.Length == NumCardsToRetrieve);
        }

        [Fact]
        public void DeckDrawNegativeNumThrowsExcept()
        {
            const int NegNumCardsToRetrieve = -1;
            Deck deck = new Deck();

            Assert.Throws<System.ArgumentOutOfRangeException>(() => deck.Draw(NegNumCardsToRetrieve));
        }

        [Fact]
        public void DeckDrawMoreThanAllGetsAll()
        {
            Deck deck = new Deck();

            int numTotalCards = deck.NumberOfCards;
            int numMoreThanTotal = deck.NumberOfCards + 1;

            Card[] cards = deck.Draw(numMoreThanTotal).ToArray();
            Assert.True(cards.Count() == numTotalCards);
        }

        [Fact]
        public void DeckDrawZeroReturnsEmptyArray()
        {
            Deck deck = new Deck();
            Card[] cards = deck.Draw(0).ToArray();

            Assert.True(cards != null);
            Assert.True(cards.Length == 0);
        }

        [Fact]
        public void DeckDrawReturnsOnlyUnplayed()
        {
            const int CardsToLeaveNotPlayed = 3;

            Deck deck = new Deck();
            deck.Draw(deck.NumberOfCards - CardsToLeaveNotPlayed); // Draw most cards, i.e. mark most cards as Played

            Card[] cards = deck.Draw(CardsToLeaveNotPlayed + 1).ToArray(); // Intentionally draw more cards than are not Played
            Assert.True(cards.Length == CardsToLeaveNotPlayed);
        }

        [Fact]
        public void DeckDrawDrawingAllMarksAllAsPlayed()
        {
            Deck deck = new Deck();
            deck.Draw(deck.NumberOfCards - 1);
            Assert.True(!deck.AllPlayed); // Still have one unplayed card

            deck.Draw(1); // Draw the final unplayed card
            Assert.True(deck.Draw(1).Count() == 0);
            Assert.True(deck.AllPlayed);
        }
    }
}
