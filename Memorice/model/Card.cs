using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorice.Model
{
    /// <summary>
    /// La clase Card representa una carta, almacena una pinta (Suit) y su correspondiente
    /// valor numérico, del 2 al 10, su valor es el mismo, A vale 1, J vale 11, Q vale 12
    /// y K vale 13.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Pinta de la carta, una vez creado el objeto solamente se puede acceder a su pinta
        /// </summary>
        public Suit Suit { private set; get; }
        /// <summary>
        /// Valor de la carta, una vez creado el objeto solamente se puede acceder a su valor
        /// </summary>
        public int Value { private set; get; }

        /// <summary>
        /// Constructor de la clase Card.
        /// </summary>
        /// <param name="suit">la pinta de la carta</param>
        /// <param name="value">el valor de la carta</param>
        public Card(Suit suit, int value)
        {
            this.Suit = suit;
            this.Value = value;
        }

        /// <summary>
        /// Retorna la representación en string de la carta acorde con su recurso
        /// cargado en la clase Program.
        /// </summary>
        /// <returns>
        ///     representación en string de la carta que corresponde 
        ///     al identificador del recurso
        /// </returns>
        public override string ToString()
        {
            string suitName = "clubs";

            switch (this.Suit)
            {
                case Suit.Clubs: suitName = "clubs"; break;
                case Suit.Diamonds: suitName = "diamonds"; break;
                case Suit.Hearts: suitName = "hearts"; break;
                case Suit.Spades: suitName = "spades"; break;
            }

            return suitName + this.Value;
        }

        /// <summary>
        /// Metodo que compara si dos cartas son iguales. La comparación se realiza 
        /// según el valor de sus atributos.
        /// </summary>
        /// <param name="obj">Objeto a verificar si es carta y si su contenido es igual a esta instancia</param>
        /// <returns>
        ///     true si el objeto obj es del tipo Card y si su pinta y valor son iguales al de esta 
        ///     instancia, false de lo contrario.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Card)
            {
                Card card = (Card)obj;
                return this.Suit == card.Suit && this.Value == card.Value;
            }
            return false;
        }
    }
}
