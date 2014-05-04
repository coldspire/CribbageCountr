using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CribbageCountr
{
    class Card : IEquatable<Card>
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public bool Equals(Card otherCard)
        {
            return (this.Suit == otherCard.Suit &&
                    this.Rank == otherCard.Rank);
        }

        public Card(Suit suit, Rank rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }
    }
}
