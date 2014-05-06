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
    }
}
