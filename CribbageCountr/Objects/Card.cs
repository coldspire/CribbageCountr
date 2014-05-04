﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// Compares a card against this card. For IEquatable.
        /// </summary>
        /// <param name="otherCard">The card to compare against.</param>
        /// <returns>Whether this card and the other card are the same.</returns>
        public bool Equals(Card otherCard)
        {
            if (otherCard == null)
            {
                return false;
            }

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
