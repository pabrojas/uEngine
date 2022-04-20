using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorice.Model
{
    public class Card
    {
        public Suits suit { private set; get; }
        public int value { private set; get; }

        public Card(Suits suit, int value)
        {
            this.suit = suit;
            this.value = value;
        }

        public override string ToString()
        {
            string suitName = "clubs";

            switch (suit)
            {
                case Suits.Clubs: suitName = "clubs"; break;
                case Suits.Diamonds: suitName = "diamonds"; break;
                case Suits.Hearts: suitName = "hearts"; break;
                case Suits.Spades: suitName = "spades"; break;
            }

            return suitName + value;
        }

        public override bool Equals(object obj)
        {
            if (obj is Card)
            {
                Card card = (Card)obj;
                return this.suit == card.suit && this.value == card.value;
            }
            return false;
        }
    }
}
