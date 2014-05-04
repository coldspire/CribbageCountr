﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CribbageCountr
{
    public class Deck
    {
        private List<Card> cards = new List<Card>();

        public bool IncludesJokers { get; private set; }
        public bool AllowsDuplicates { get; private set; }

        public int NumberOfCards
        {
            get { return cards.Count(); }
        }

        public void Shuffle()
        {
            // TODO: Shuffle this deck.
        }

        /// <summary>
        /// Adds a card to this deck.
        /// </summary>
        /// <param name="newCard">The card to add.</param>
        /// <returns>Whether the card was added.</returns>
        public bool AddCard(Card newCard)
        {
            bool isJokerAndAllowed = (IncludesJokers && newCard.IsJoker);

            if (!AllowsDuplicates
                && !isJokerAndAllowed
                && this.cards.Contains(newCard))
            {
                return (false);
            }

            cards.Add(newCard);
            return (true);
        }

        /// <summary>
        /// Initializes a standard 52- or 54-card deck.
        /// </summary>
        private void Init()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    if (suit == Suit.Joker || rank == Rank.Joker)
                    {
                        // adding jokers is handled below, with if-IncludeJokers
                        continue;
                    }

                    AddCard(new Card(suit, rank));
                }
            }

            if (IncludesJokers)
            {
                AddCard(new Card(Suit.Joker, Rank.Joker));
                AddCard(new Card(Suit.Joker, Rank.Joker));
            }
        }

        public Deck(bool includeJokers, bool allowDuplicates)
        {
            IncludesJokers = includeJokers;
            AllowsDuplicates = allowDuplicates;

            Init();
        }

        public Deck() : this(false, false)
        {
        }
    }
}
