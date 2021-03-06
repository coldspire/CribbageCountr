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

        private bool m_allPlayed;
        public bool AllPlayed
        {
            get { return m_allPlayed; }
            private set
            {
                if (value && value != m_allPlayed)
                {
                    // AllPlayed just became true.
                    // TODO: Fire a Played event here
                }
                m_allPlayed = value;
            }
        }

        public Deck(bool includeJokers, bool allowDuplicates)
        {
            IncludesJokers = includeJokers;
            AllowsDuplicates = allowDuplicates;

            Init();
        }

        public Deck()
        {
            IncludesJokers = false;
            AllowsDuplicates = false;

            Init();
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
                AddJoker();
                AddJoker();
            }
        }

        #region Card retrievals

        /// <summary>
        /// Indexer to retrieve a single Card from the Deck.
        /// </summary>
        /// <param name="index">Index of the Card to retrieve.</param>
        /// <returns>A Card.</returns>
        public Card this[int index]
        {
            get
            {
                if (index < 0 || index > NumberOfCards-1)
                {
                    throw new ArgumentOutOfRangeException("Card Index doesn't exist in Deck.");
                }

                return cards[index];
            }
        }

        private Card[] GetCards(int numCardsToRetrieve, bool IncludePlayed = false)
        {
            if (numCardsToRetrieve < 0)
            {
                throw new ArgumentOutOfRangeException("Number of cards to draw cannot be negative");
            }

            var cardsQuery = cards.Select(card => card);
            if (!IncludePlayed)
            {
                cardsQuery = cardsQuery.Where(card => !card.Played);
            }

            Card[] cardsDrawn = cardsQuery.Take(numCardsToRetrieve).ToArray();

            foreach (Card card in cardsDrawn)
            {
                card.Played = true;
            }

            if (cards.All(card => card.Played))
            {
                AllPlayed = true;
            }

            return (cardsDrawn);
        }

        public IEnumerable<Card> Draw(int numToDraw)
        {
            return (GetCards(numToDraw, false).AsEnumerable<Card>());
        }

        #endregion

        #region Manipulations - Individual Cards
        /// <summary>
        /// Adds a joker card to this deck.
        /// </summary>
        public void AddJoker()
        {
            AddCard(new Card(Suit.Joker, Rank.Joker));
        }

        /// <summary>
        /// Adds a suit & rank card to this deck.
        /// </summary>
        /// <param name="newCard">The card to add.</param>
        /// <returns>Whether the card was added.</returns>
        public bool AddCard(Card newCard)
        {
            if ((newCard.Suit == Suit.Joker && newCard.Rank != Rank.Joker) ||
                (newCard.Suit != Suit.Joker && newCard.Rank == Rank.Joker))
            {
                throw new System.ArgumentException("AddCard card has suit and rank joker mismatch.");
            }

            bool isJokerAndAllowed = (IncludesJokers && newCard.IsJoker);

            if (!AllowsDuplicates && 
                !isJokerAndAllowed && // Two jokers can exist in a deck
                this.cards.Contains(newCard))
            {
                return (false);
            }

            cards.Add(newCard);
            return (true);
        }
        #endregion

        #region Manipulations - Entire deck
        /// <summary>
        /// Shuffle the cards using a Fisher-Yates/Knuth shuffle.
        /// </summary>
        public void Shuffle()
        {
            if (cards == null || cards.Count <= 1)
            {
                return;
            }

            Random random = new Random();
            for (int deckEnd = this.cards.Count - 1; deckEnd >= 1; deckEnd--)
            {
                int cardIdx = random.Next(0, deckEnd);
                cards[cardIdx].Swap(cards[deckEnd]);
            }

            AllPlayed = false;

            return;
        }
        #endregion
    }
}
