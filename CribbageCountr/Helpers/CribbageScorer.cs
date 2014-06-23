using CribbageCountr;
using System.Linq;
using System.Collections.Generic;

namespace CribbageCountr
{
    public static class CribbageScorer
    {
        // TODO: Sum of 15 (2)

        // TODO: 4-of-a-kind (12, six pairs)

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

        public static int ScoreOfKind2(Card[] hand)
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

        public static int ScoreOfKind3(Card[] hand)
        {
            int score = 0;

            foreach (List<Card> set in GetSets(3, hand))
            {
                if (set[0].Rank == set[1].Rank &&
                    set[0].Rank == set[2].Rank)
                {
                    score += (int)PointsPer.OfKind3;
                }
            }

            return (score);
        }

        /// <summary>
        /// Returns the score of a single cribbage hand.
        /// </summary>
        /// <param name="hand">All cards in the hand to be scored.</param>
        /// <param name="cutCard">A card in the hand that is the cut card.</param>
        /// <returns>Number of scored points.</returns>
        public static int ScoreHand(Card[] hand, Card cutCard)
        {
            int pointsTotal = 0;



            return (pointsTotal);
        }
    }
}
