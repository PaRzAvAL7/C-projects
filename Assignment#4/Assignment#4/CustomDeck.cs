using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    internal class CustomDeck :Deck
    {
        public CustomDeck(StandardDeck standardDeck)
        {
            foreach (Card card in standardDeck.Cards)
            {
                AddCustomCard(card);
            }
        }

        // Method to add custom card to deck list
        public void AddCustomCard(Card customCard)
        {
            Cards.Add(customCard);
        }
    }
}
