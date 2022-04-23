
namespace Memorice.Model
{
    /// <summary>
    /// La clase Pair sirve para representar una casilla (i, j) del tablero de juego
    /// </summary>
    public class Pair
    {
        /// <summary>
        /// Representa la fila de la casilla dentro del tablero.
        /// </summary>
        public int Row { private set; get; }
        /// <summary>
        /// Representa la columna de la casilla dentro del tablero.
        /// </summary>
        public int Col { private set; get; }

        /// <summary>
        /// Constructor de la clase Pair que representa una casilla del tablero de juego
        /// </summary>
        /// <param name="row">corresponde  a la fila de la casilla dentro del tablero</param>
        /// <param name="col">corresponde  a la columna de la casilla dentro del tablero</param>
        public Pair(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }
}
