using CribbageCountr;
using Xunit;

namespace Tests
{
    public class CardTests
    {
        [Fact]
        public void StubTest()
        {
            Card card = new Card(Suit.Club, Rank.Ace);
        }
    }
}
