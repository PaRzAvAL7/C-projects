using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_4
{
    public partial class Form1 : Form
    {
        private CustomDeck deck;
        private StandardDeck standardDeck;
        public Form1()
        {

            InitializeComponent();
            standardDeck = new StandardDeck();
            deck = new CustomDeck(standardDeck); 
            ViewDeck();
        }


        private void ViewDeck()
        {
            listView2.Items.Clear();
            foreach (Card card in deck.Cards)
            {
                listView2.Items.Add(card.ToString());
            }
        }


        private bool ValidategroupBox1(string suit, string rank)
        {
            if (string.IsNullOrWhiteSpace(suit))
            {
                MessageBox.Show("Please enter a valid suit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(rank))
            {
                MessageBox.Show("Please enter a valid rank.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

 
        private bool ValidatetextBox3(string drawCount)
        {
            if (!int.TryParse(drawCount, out int count) || count < 0 || count > deck.Cards.Count)
            {
                MessageBox.Show("Please enter a valid draw count.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private void ResetForm()
        {

            textBox1.Clear();
            textBox2.Clear();


            textBox3.Clear();

            // Clear Lists
            listView1.Items.Clear();
            listView2.Items.Clear();

            deck = new CustomDeck(standardDeck);
        }



        private void button3_Click(object sender, EventArgs e)
        {
            ViewDeck();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            deck.Shuffle();
            button3_Click(sender, e);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ResetForm();
            button3_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {

            ResetForm();
            this.Close();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string suit = textBox1.Text.Trim();
            string rank = textBox2.Text.Trim();

            if (ValidategroupBox1(suit, rank))
            {

                Card customCard = new Card(suit, rank);
                deck.AddCustomCard(customCard);

                listView2.Items.Add(customCard.ToString());

                textBox1.Clear();
                textBox2.Clear();
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string drawCount = textBox3.Text.Trim();

            if (ValidatetextBox3(drawCount))
            {

                for (int i = 0; i < int.Parse(drawCount); i++)
                {
                    Card dealtCard = deck.Deal();
                    if (dealtCard != null)
                    {

                        listView1.Items.Add(dealtCard.ToString());
                    }
                }
            }

            button3_Click(sender, e);

        }
    }
}
        

