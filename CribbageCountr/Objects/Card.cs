using System;

namespace CribbageCountr
{
    public class Card : IEquatable<Card>
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public bool IsJoker
        {
            get 
            { 
                return (this.Suit == Suit.Joker && this.Rank == Rank.Joker); 
            }
        }

        /// <summary>
        /// Compares a card against this card.
        /// </summary>
        /// <param name="otherCard">The card to compare against.</param>
        /// <returns>Whether this card and the other card are the same.</returns>
        /// Needed for IEquatable.
        public bool Equals(Card otherCard)
        {
            if (otherCard == null)
            {
                return false;
            }

            return (this.Suit == otherCard.Suit &&
                    this.Rank == otherCard.Rank);
        }

        public Card(Card cardToCopy) : this(cardToCopy.Suit, cardToCopy.Rank)
        {
        }

        public Card(Suit suit, Rank rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }
    }
}
