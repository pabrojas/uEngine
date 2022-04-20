using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorice.Model
{
    public class MemoriceLogic
    {
        private CardStatus[,] cards;
        private Card[,] values;

        private Random random;

        public MemoriceLogic()
        {
            this.random = new Random();
            Initialize();
        }

        private void Initialize()
        {
            this.cards = new CardStatus[6, 6];
            this.values = new Card[6, 6];
            
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    this.cards[i, j] = CardStatus.Back;
                }
            }


            List<Card> cards = new List<Card>();
            while (cards.Count() < 18)
            {
                Card card = GenerateCard();
                if (!cards.Contains(card))
                {
                    cards.Add(card);
                }
            }

            List<Pair> pairs = new List<Pair>();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    pairs.Add(new Pair(i, j));
                }
            }

            int c = 0;
            foreach (Card card in cards)
            {
                int i1 = random.Next(pairs.Count);
                Pair p1 = pairs[i1];
                pairs.RemoveAt(i1);

                int i2 = random.Next(pairs.Count);
                Pair p2 = pairs[i2];
                pairs.RemoveAt(i2);

                this.values[p1.i, p1.j] = card;
                this.values[p2.i, p2.j] = card;

                if( c < 16 )
                {
                    this.cards[p1.i, p1.j] = CardStatus.Front;
                    this.cards[p2.i, p2.j] = CardStatus.Front;
                }

                c++;

            }
        }

        public void SetStatus(int i, int j, CardStatus status)
        {
            cards[i, j] = status;
        }

        public Card GenerateCard()
        {
            int suit = this.random.Next(4);
            int value = this.random.Next(13) + 1;

            return new Card((Suits)suit, value);
        }

        public CardStatus GetStatus(int i, int j)
        {
            return this.cards[i, j];
        }

        public Card GetCard(int i, int j)
        {
            return this.values[i, j];
        }



    }
}
