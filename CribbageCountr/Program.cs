﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CribbageCountr
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck(true, true);
            deck.Shuffle();
        }
    }
}
