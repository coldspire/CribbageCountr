using CribbageCountr;
using System.Linq;
using System.Collections.Generic;

namespace CribbageCountr
{
    public static class CribbageScorer
    {
        // TODO: Sum of 15 (2)

        // TODO: 2-of-a-kind, pair (2)
        // TODO: 3-of-a-kind (6, three pairs)
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
        
        public static IEnumerable<List<Card>> GetSets(int setWidth, Card[] cards)
        {
            if (setWidth <= 0)
            {
                throw new System.ArgumentOutOfRangeException("setWidth cannot be zero or negative.");
            }
            
            List<List<Card>> sets = new List<List<Card>>();

            if (setWidth == 1)
            {
                // You get back a bunch of single-card sets.
                foreach (Card card in cards)
                {
                    List<Card> set = new List<Card>() { card };
                    sets.Add(set);
                }
                return (sets.AsEnumerable());
            }

            return (sets.AsEnumerable());
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
