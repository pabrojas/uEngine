
using System.Drawing;

namespace Memorice.Controller
{
    /// <summary>
    /// La clase Parser es la encargada de convertir una casilla (i, j) del tablero
    /// de juego en un objeto del tipo Rectangle el cual almacena la posición en pantalla
    /// del lugar donde se presenta.
    /// </summary>
    static public class Parser
    {
        /// <summary>
        /// El arreglo Locations almacena la información de los objetos Rectangle asociados
        /// a cada cailla (i, j) del tablero de juego.
        /// </summary>
        static private Rectangle[,] Locations;

        /// <summary>
        /// Debido a que la clase Parser es estática, para inicializar los datos del atributo 
        /// de clase Locations, el constructor de la clase Parser es estático, esto significa
        /// que al inicio de la ejecución del programa, 
        /// </summary>
        static Parser()
        {
            Locations = new Rectangle[6, 6]; 

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    //la esquina inicial de la primera carta es (243, 34). Cada carta tiene
                    //un ancho y alto de (73, 100) y una separación horizontal de 20 unidades
                    //y una separación vertical de 10 unidades
                    Rectangle rectangle = new Rectangle(243 + i * 93, 34 + j * 120, 73, 100);
                    Locations[i, j] = rectangle;
                }
            }
        }

        /// <summary>
        /// El método Get obtiene el objeto Rectangle asociado a la casilla (i, j).
        /// </summary>
        /// <param name="i">Corresponde a la fila de la cassilla</param>
        /// <param name="j">Corresponde a la columna de la casilla</param>
        /// <returns>El rectángulo que contiene la información de dónde 
        /// dibujar la carta asociado la casilla (i, j)</returns>
        static public Rectangle Get(int i, int j)
        {
            return Locations[i, j];
        }
    }
}
