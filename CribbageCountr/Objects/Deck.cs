using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CribbageCountr
{
    class Deck
    {
        private List<Card> cards = new List<Card>();

        public void Shuffle()
        {
            // TODO: Shuffle this deck.
        }

        /// <summary>
        /// Adds a card to this deck.
        /// </summary>
        /// <param name="newCard">The card to add.</param>
        /// <returns>Whether the card was added.</returns>
        private bool AddCard(Card newCard, bool NoDuplicates = true)
        {
            // TODO: Check for duplicates, and return false if one is found.
            // if (NoDuplicates && found-a-duplicate)
            // { return (false); }

            cards.Add(newCard);
            return (true);
        }

        /// <summary>
        /// Initializes a standard 52- or 54-card deck for playing. 
        /// </summary>
        /// <param name="IncludeJokers">Whether to include the two jokers in the deck.</param>
        private void Init(bool IncludeJokers = false)
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    if (rank == Rank.Joker && !IncludeJokers)
                    {
                        continue;
                    }

                    AddCard(new Card(suit, rank));
                }
            }
        }

        public Deck(bool IncludeJokers = false)
        {
            Init(IncludeJokers);
        }
    }
}
