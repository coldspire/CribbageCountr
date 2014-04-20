using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CribbageCountr
{
    class Card
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public Card(Suit suit, Rank rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }
    }
}
