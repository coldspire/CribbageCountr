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

            OfKind2        = 2,
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
                    score += (int)PointsPer.OfKind2;
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
            if (hand.Count() != 5)
            {
                throw new System.ArgumentException("Hand of cards must be exactly 5 cards.");
            }

            System.Array.Sort(hand);

            int score;
            bool isRunOf5;  // Can only have one run of 5
            int numRunsOf4;
            int numRunsOf3;

            score = 0;

            isRunOf5 = true; // assume we have one, until we find that we don't
            for (int handIdx = 0; handIdx <= 3; handIdx++)
            {
                if ((int)hand[handIdx].Rank+1 != (int)hand[handIdx+1].Rank)
                {
                    // found a break in the run
                    isRunOf5 = false;
                    break;
                }
            }

            numRunsOf4 = 0;
            if (!isRunOf5)
            {
                foreach(List<Card> setOf4 in GetSets(4, hand))
                {
                    if ((int)setOf4[0].Rank+1 == (int)setOf4[0+1].Rank &&
                        (int)setOf4[1].Rank+1 == (int)setOf4[1+1].Rank &&
                        (int)setOf4[2].Rank+1 == (int)setOf4[2+1].Rank)
                    {
                        numRunsOf4 += 1;
                    }
                }
            }

            numRunsOf3 = 0;
            if (!isRunOf5 && numRunsOf4 == 0)
            {   
                foreach(List<Card> setOf3 in GetSets(3, hand))
                {
                    if ((int)setOf3[0].Rank+1 == (int)setOf3[0+1].Rank &&
                        (int)setOf3[1].Rank+1 == (int)setOf3[1+1].Rank)
                    {
                        numRunsOf3 += 1;
                    }
                }
            }

            if (isRunOf5)
            {
                score = (int)PointsPer.Run5;
            }
            else if (numRunsOf4 > 0)
            {
                score = (int)PointsPer.Run4 * numRunsOf4;
            }
            else if (numRunsOf3 > 0)
            {
                score = (int)PointsPer.Run3 * numRunsOf3;
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
