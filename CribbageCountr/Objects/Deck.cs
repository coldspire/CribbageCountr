using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CribbageCountr
{
    class Deck
    {
        private List<Card> cards = new List<Card>();

        public bool IncludesJokers { get; private set; }
        public bool AllowsDuplicates { get; private set; }

        public void Shuffle()
        {
            // TODO: Shuffle this deck.
        }

        /// <summary>
        /// Adds a card to this deck.
        /// </summary>
        /// <param name="newCard">The card to add.</param>
        /// <returns>Whether the card was added.</returns>
        private bool AddCard(Card newCard)
        {
            if (!AllowsDuplicates && this.cards.Contains(newCard))
            {
                return (false);
            }

            cards.Add(newCard);
            return (true);
        }

        /// <summary>
        /// Initializes a standard 52- or 54-card (includes jokers) deck.
        /// </summary>
        private void Init()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    if (rank == Rank.Joker && !IncludesJokers)
                    {
                        continue;
                    }

                    AddCard(new Card(suit, rank));
                }
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
