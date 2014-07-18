using CribbageCountr;
using System.Linq;
using System.Collections.Generic;

namespace CribbageCountr
{
    public static class CribbageScorer
    {
        // TODO: Sum of 15 (2)

        // TODO: A sorted hand would be useful for the following three rules
        // TODO: Run of 3 (3)
        // TODO: Run of 4 (4)
        // TODO: Run of 5 (5)

        // TODO: Run of 3, plus a pair  (8: two run-of-threes, plus a pair)
        // TODO: Run of 4, plus a pair (10: two run-of-fours, plus a pair)
        // TODO: Triple run (15: three pairs, plus a run-of-three)

        // TODO: Flush of 4 (4)
        // TODO: Flush of 5 (5)

        // TODO: His Nobs (1: Jack is same suit as cut card)

        public enum PointsPer : int
        {
            None        = 0,

            Sum15       = 2,

            Pair        = 2,
            OfKind2     = 2,
            OfKind3     = 6,
            OfKind4     = 12,

            Run3        = 3,
            Run4        = 4,
            Run5        = 5,
            Run3Pair    = 8,
            Run4Pair    = 10,
            RunTriple   = 15,

            Flush4      = 4,
            Flush5      = 5,

            HisNobs     = 1,
        };

        /// <summary>
        /// Returns an IEnumerable of all unordered sets of a specified width from a hand of cards.
        /// </summary>
        /// <param name="setWidth">Width of the unordered sets</param>
        /// <param name="cards">Cards to make sets from</param>
        /// <returns>Sets of cards of a specified width</returns>
        public static IEnumerable<List<Card>> GetSets(int setWidth, Card[] cards)
        {
            if (setWidth <= 0)
            {
                throw new System.ArgumentOutOfRangeException("setWidth cannot be zero or negative.");
            }
            
            List<List<Card>> sets = new List<List<Card>>();

            if (setWidth == 1)
            {
                // Returns single-card sets.
                foreach (Card card in cards)
                {
                    List<Card> set = new List<Card>() { card };
                    sets.Add(set);
                }
                return (sets.AsEnumerable());
            }

            // For multi-card sets.
            for (int baseCard = 0; baseCard < cards.Length; baseCard++)
            {
                for (int nextCard = baseCard + 1; nextCard < cards.Length; nextCard++)
                {
                    List<Card> set = new List<Card>();
                    set.Add(cards[baseCard]);

                    int cardToAdd = nextCard;
                    while (set.Count() < setWidth && cardToAdd < cards.Length)
                    {
                        set.Add(cards[cardToAdd]);
                        cardToAdd++;
                    }

                    if (set.Count() < setWidth)
                    {
                        // Set is too small to include. Discard.
                        continue;
                    }

                    sets.Add(set);
                }
            }

            return (sets.AsEnumerable());
        }

        /// <summary>
        /// Finds if a five-card hand contains and pairs and scores the pairs.
        /// </summary>
        /// <param name="hand">A five-card cribbage hand.</param>
        /// <returns>Score (if any) for any pairs in the hand.</returns>
        public static int ScorePairs(Card[] hand)
        {
            int score = 0;

            foreach (List<Card> set in GetSets(2, hand))
            {
                if (set[0].Rank == set[1].Rank)
                {
                    score += (int)PointsPer.Pair;
                }
            }

            return (score);
        }

        /// <summary>
        /// Finds if a five-card hand has any runs and scores the run.
        /// </summary>
        /// <param name="hand">A five-card cribbage hand.</param>
        /// <returns>Score (if any) for any runs in the hand.</returns>
        public static int ScoreRuns(Card[] hand)
        {
            int score = 0;
            System.Array.Sort(hand);

            if ((int)hand[0].Rank == (int)hand[1].Rank-1 &&
                (int)hand[1].Rank == (int)hand[2].Rank-1 &&
                (int)hand[2].Rank == (int)hand[3].Rank-1 &&
                (int)hand[3].Rank == (int)hand[4].Rank-1)
            {
                score += (int)PointsPer.Run5;
            }
            else if ((int)hand[0].Rank == (int)hand[1].Rank-1 &&
                     (int)hand[1].Rank == (int)hand[2].Rank-1 &&
                     (int)hand[2].Rank == (int)hand[3].Rank-1)
            {
                // Run of the first four cards.
                score += (int)PointsPer.Run4;
            }
            else if ((int)hand[1].Rank == (int)hand[2].Rank-1 &&
                     (int)hand[2].Rank == (int)hand[3].Rank-1 &&
                     (int)hand[3].Rank == (int)hand[4].Rank-1)
            {
                // Run of the last four cards.
                score += (int)PointsPer.Run4;
            }
            else if ((int)hand[0].Rank == (int)hand[1].Rank-1 &&
                     (int)hand[1].Rank == (int)hand[2].Rank-1)
            {
                // Run of the first three cards
                score += (int)PointsPer.Run3;
            }
            else if ((int)hand[1].Rank == (int)hand[2].Rank-1 &&
                     (int)hand[2].Rank == (int)hand[3].Rank-1)
            {
                // Run of the middle three cards
                score += (int)PointsPer.Run3;
            }
            else if ((int)hand[2].Rank == (int)hand[3].Rank-1 &&
                     (int)hand[3].Rank == (int)hand[4].Rank-1)
            {
                // Run of the last three cards
                score += (int)PointsPer.Run3;
            }
            
            return (score);
        }

        /// <summary>
        /// Returns the score of a single cribbage hand of 5 cards.
        /// </summary>
        /// <param name="hand">All cards in the hand to be scored.</param>
        /// <param name="cutCard">A card in the hand that is the cut card.</param>
        /// <returns>Number of scored points.</returns>
        public static int ScoreHand(Card[] hand, Card cutCard)
        {
            if (hand.Count() != 5)
            {
                // Gotta have five cards in a hand for correct scoring.
                throw new System.ArgumentException("Hand of cards must be exactly five cards.");
            }

            int pointsTotal = 0;

            return (pointsTotal);
        }
    }
}
