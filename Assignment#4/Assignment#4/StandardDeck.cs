using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    internal class StandardDeck : Deck
    {
        public StandardDeck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

            // For each suit set different ranks
            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    Cards.Add(new Card(suit, rank));
                }
            }
        }
    }
}
