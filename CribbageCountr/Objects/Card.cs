using System;

namespace CribbageCountr
{
    public class Card : IEquatable<Card>, IComparable
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public bool Played { get; set; }

        public bool IsJoker
        {
            get 
            { 
                return (this.Suit == Suit.Joker && this.Rank == Rank.Joker); 
            }
        }

        /// <summary>
        /// Checks if this card matches another card by 
        /// comparing suit and rank.
        /// </summary>
        /// <param name="otherCard">The card to compare against.</param>
        /// <returns>Whether this card and the other card have the same suit and rank.</returns>
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

        /// <summary>
        /// Checks if this card precedes, matches, or follows another card
        /// when compared
        /// </summary>
        /// <param name="objToCompare">The card to compare with.</param>
        /// <returns>Negative if this precedes the compared card, zero if matches, and positive if it follows.</returns>
        public int CompareTo(object objToCompare)
        {
            if (objToCompare is Card)
            {
                Card cardToCompare = objToCompare as Card;
                return this.Rank.CompareTo(cardToCompare.Rank);

                // TODO: Custom comparer for suits? There is no default suit comparer.
            }

            throw new System.ArgumentException("Object to compare is not a Card.");
        }

        public Card(Card cardToCopy) : this(cardToCopy.Suit, cardToCopy.Rank)
        {
        }

        public Card(Suit suit, Rank rank)
        {
            this.Suit = suit;
            this.Rank = rank;

            this.Played = false;
        }
    }
}
