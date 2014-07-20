using CribbageCountr;
using System.Linq;
using System.Collections.Generic;

namespace CribbageCountr
{
    public static class CribbageScorer
    {
        // TODO: Sum of 15 (2)

        // TODO: Run of 3 plus a pair  (run-3 double)
        // TODO: Run of 4, plus a pair (run-4 double)
        // TODO: Run of 3 with three of a kind (triple run)
        // TODO: Run of 3 with two pairs (run double double)

        // TODO: Flush of 4 (4)
        // TODO: Flush of 5 (5)

        // TODO: His Nobs (1: Jack is same suit as cut card)


        // TODO: Move this to its own static public class
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
            RunDouble   = 6,    // e.g. AA223
            RunTriple   = 9,    // e.g. AAA23
            RunDblDbl   = 12,   // e.g. AA223

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
            System.Array.Sort(hand);

            Rank highRank = hand[0].Rank;
            int lengthOfRun = 1;
            for (int cardIdx = 0; cardIdx < 5; cardIdx++)
            {
                Card nextCard = hand[cardIdx];

                if (highRank == nextCard.Rank)
                {
                    // TODO: If a run contains one or more pairs, multiple runs should be scored.
                    // E.g. if AAA23, then this has three runs: A23, A23, A23. (ScorePairs will score three pairs.)
                    // Or AA223, with runs of A23, A23. (ScorePairs will score two pairs.)

                    continue; // Found a pair -- keep going, since run may still continue
                }
                else if ((int)highRank == (int)nextCard.Rank - 1)
                {
                    lengthOfRun += 1; // The run continues
                }
                else
                {
                    // This card's rank doesn't match the previous card's (or cards') rank.

                    // One of three things could happen here:
                    // 1) We don't have a run yet, but a run could occur with remaining cards.
                    // ---- Occurs when the run is broken on cards 2 or 3.
                    // 2) We don't have a run yet, and we don't have enough cards to make one.
                    // ---- Occurs when the run is broken on cards 4 or 5.
                    // 3) We have a run, but we don't have enough cards to make a larger run.
                    // ---- Occurs when the run is broken on cards 4 or 5.

                    if (cardIdx == 3 || cardIdx == 4)
                    {
                        break; // We're done -- we can't start or extend a run with only 1-2 cards.
                    }
                    else // cardIdx is 1 or 2
                    {
                        lengthOfRun = 1; // Restart the counter, since we may yet find a run of 3.
                    }
                }

                highRank = nextCard.Rank;
            }

            int score;

            if (lengthOfRun == 3)
            {
                score = (int)PointsPer.Run3;
            }
            else if (lengthOfRun == 4)
            {
                score = (int)PointsPer.Run4;
            }
            else if (lengthOfRun == 5)
            {
                score = (int)PointsPer.Run5;
            }
            else
            {
                score = (int)PointsPer.None;
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
