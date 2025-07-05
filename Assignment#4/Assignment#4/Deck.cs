using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Assignment_4
{
    internal class Deck
    { 
        public List<Card> Cards { get; }

    public Deck()
    {
        // Initialize the cards list
        Cards = new List<Card>();
    }

    // Method to shuffle deck
    public void Shuffle()
    {
        Random random = new Random();
        for (int i = Cards.Count - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            // Swapping based on tuple
            (Cards[j], Cards[i]) = (Cards[i], Cards[j]);
        }
    }

    // Method to deal or draw a card
    // If there is no card return null
    public Card Deal()
    {
        if (Cards.Count > 0)
        {
            Card dealtCard = Cards.First();
            Cards.RemoveAt(0);
            return dealtCard;
        }

        return null;
    }
}

    }
