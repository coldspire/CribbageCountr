using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CribbageCountr
{
    static public class CardExtensions
    {
        static public void Swap(this Card thisCard, Card anotherCard)
        {
            if (thisCard == null || anotherCard == null)
            {
                throw new ArgumentNullException("Can't swap null Cards.");
            }

            Card thisCardTemp = new Card(thisCard);

            thisCard.Suit = anotherCard.Suit;
            thisCard.Rank = anotherCard.Rank;

            anotherCard.Suit = thisCardTemp.Suit;
            anotherCard.Rank = thisCardTemp.Rank;

            return;
        }
    }
}
