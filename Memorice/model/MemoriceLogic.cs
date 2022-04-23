using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorice.Model
{
    /// <summary>
    /// La clase MemoriceLogic almacena la lógica de la representación del juego Memorice.
    /// </summary>
    public class MemoriceLogic
    {
        /// <summary>
        /// Almacena el estado de las cartas del tablero según la representación de CardStatus.
        /// </summary>
        private CardStatus[,] Status;
        /// <summary>
        /// Almacena el valor y pinta de las cartas del tablero.
        /// </summary>
        private Card[,] Cards;

        /// <summary>
        /// Constructor de la clase MemoriceLogic. Se instancian e inicializan los atributos,
        /// por defecto todas las cartas se presentarán al reverso.
        /// </summary>
        public MemoriceLogic()
        {
            //creo un objeto Random para generar aleatoriamente las cartas
            Random random = new Random();

            //inicializo el tablero de 6x6
            this.Status = new CardStatus[6, 6];
            this.Cards = new Card[6, 6];
            
            //por defecto las cartas se presentan al reverso
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    this.Status[i, j] = CardStatus.Back;
                }
            }

            //dado que hay 36 cartas en el tablero, debería colocar 18 cartas repetidas
            //para asegurar que el tablero tiene solución.
            //para almacenar las 18 cartas creo una lista y no agregaré cartas repetidas
            List<Card> cards = new List<Card>();
            while (cards.Count() < 18)
            {
                //genero aleatoriamente una carta
                Card card = GenerateCard(random);
                //reviso si la carta no se encuentra en la lista, para ello utilizo el método 
                //Contains de la lista, el cual utiliza el método Equals de la clase Card
                if (!cards.Contains(card))
                {
                    //si la carta no se encuentra en la lista la agrego
                    cards.Add(card);
                }
            }

            //para posicionar las cartas en el tablero, genero y almaceno todas las posiciones posibles
            //en la lista de pares, en total genero 36 pares (i, j) 
            List<Pair> pairs = new List<Pair>();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    pairs.Add(new Pair(i, j));
                }
            }

            //para cada carta obtendré aleatoriamente 2 posiciones (pares) y posicionaré la carta
            //en ambas posiciones
            foreach (Card card in cards)
            {
                //para generar una posición, genero un número aleatorio mayor o igual a 0 y
                //menor que la cantidad de elementos de la lista
                int i1 = random.Next(pairs.Count);
                //almaceno la posición seleccionada aleatoriamente
                Pair p1 = pairs[i1];
                //elimino la posición de la lista para no volver a escogerla
                pairs.RemoveAt(i1);

                int i2 = random.Next(pairs.Count);
                Pair p2 = pairs[i2];
                pairs.RemoveAt(i2);

                //en ambas posiciones almaceno la carta
                this.Cards[p1.Row, p1.Col] = card;
                this.Cards[p2.Row, p2.Col] = card;
            }
        }

        /// <summary>
        /// Cambia el estado de la carta especificada
        /// </summary>
        /// <param name="i">fila de la carta a cambiar su estado</param>
        /// <param name="j">columna d ela carta a cambiar su estado</param>
        /// <param name="status">estado nuevo de la carta a asignar</param>
        public void SetStatus(int i, int j, CardStatus status)
        {
            Status[i, j] = status;
        }

        /// <summary>
        /// Genera aleatoriamente una carta
        /// </summary>
        /// <param name="random">Objeto generador de números aleatorios</param>
        /// <returns>Una carta donde el valor y la pinta fueron generados aleatoriamente</returns>
        private Card GenerateCard(Random random)
        {
            //genero un valor entre 1 y 13, ambos incluidos
            int value = random.Next(13) + 1;
            //genero un valor entre 0 y 3, ambos incluidos
            int suitIndex = random.Next(4);
            //convierto explicitamente el valor de suitIndex en el tipo enumerado Suit
            //esta conversión se realiza correctamente ya que los tipos enumerdos guardan un valor numérico por defecto
            //que comienza en 0 y van aumentado de 1
            Suit suit = (Suit)suitIndex;

            return new Card((Suit)suit, value);
        }


        /// <summary>
        /// Obtiene el estado de la carta ubicada en la casilla (i, j)
        /// </summary>
        /// <param name="i">fila de la carta a obtener su estado</param>
        /// <param name="j">columna de la carta a cambiar su estado</param>
        /// <returns>el estado de la carta ubicada en la casilla (i, j)</returns>
        public CardStatus GetStatus(int i, int j)
        {
            return this.Status[i, j];
        }

        /// <summary>
        /// Obtiene la carta ubicada en la casilla (i, j)
        /// </summary>
        /// <param name="i">fila de la carta a obtener</param>
        /// <param name="j">columna de la carta a obtener</param>
        /// <returns>la carta ubicada en la casilla (i, j)</returns>
        public Card GetCard(int i, int j)
        {
            return this.Cards[i, j];
        }
    }
}
