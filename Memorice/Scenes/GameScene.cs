using Memorice.Controller;
using Memorice.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uEngine;

namespace Memorice.Scenes
{
    /// <summary>
    /// La clase GameScene es la encargada de pintar, procesar y actualizar el estado de la escena de juego.
    /// </summary>
    public class GameScene
    {
        /// <summary>
        /// Atributo encargado de mantener actualizada la información del juego y del estado de sus carta.
        /// </summary>
        private MemoriceLogic Logic;
        
        /// <summary>
        /// Atributo encargado de almacenar la primera carta que descubre el usuario.
        /// </summary>
        private Pair FirstSelection;
        
        /// <summary>
        /// Atributo encargado de alamacenar la segunda carta que descubre el usuario.
        /// </summary>
        private Pair SecondSelection;
        
        /// <summary>
        /// Atributo encargado de almacenar la última vez que se midió el tiempo, se utiliza para el caso en que
        /// se selecciona la segunda carta, ambas cartas permanezcan visibles en pantalla una cierta cantidad de tiempo.
        /// </summary>
        private long LastMeasuredTime;

        /// <summary>
        /// Atributo usado para almacenar el estado de termino de la escena, cuando esta variable almacena un false
        /// significa que la escena sigue funcionando, es decir, quedan cartas por descubrir. En el caso que se descubran todas
        /// las cartas, la escena debe terminar y esta variable almacena un valor true.
        /// </summary>
        private bool finished;

        /// <summary>
        /// Constructor de la clase GameScene.
        /// </summary>
        public GameScene()
        {
            Logic = new MemoriceLogic();

            //dado que no se han seleccionado cartas ambos elementos se inicializan en null
            FirstSelection = null;
            SecondSelection = null;

            //todavía no se ha medido el tiempo, por este motivo el valor por defecto es el menor valor posible,
            //de esta forma no entorpecerá los calculos que involucren este atributo
            LastMeasuredTime = long.MinValue;

            //al iniciar la escena marco que no ha terminado
            finished = false;
        }

        /// <summary>
        /// Retorna el tiempo transcurrido desde el Epoch Time hasta la fecha, este valor se representa mediante una 
        /// variable de tipo long.
        /// 
        /// En este link encontrarán información del Epoch Time <href>https://es.wikipedia.org/wiki/Tiempo_Unix</href>
        /// </summary>
        /// 
        /// <returns>la cantidad de milisegundos transcurridos desde el 1 de enero de 1970 a las 00:00 hasta la fecha actual</returns>
        public long GetTime()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            long millisecondsSinceEpoch = (long)t.TotalMilliseconds;

            return millisecondsSinceEpoch;
        }

        /// <summary>
        /// Método usado para consultar si la escena actual terminó su ejecución.
        /// </summary>
        /// <returns>true cuando el usuario descubrió todas las cartas de juego, false de lo contrario.</returns>
        public bool IsFinished()
        {
            return finished;
        }

        /// <summary>
        /// Definición del método GameUpdate para ser usado dentro del Game Loop de uGame.
        /// 
        /// Este método es el encargado de actualizar el estado del juego luego de procesar las entradas.
        /// </summary>
        public void GameUpdate()
        {
            //Consulto si se seleccionaron las dos cartas
            if (FirstSelection != null && SecondSelection != null)
            {
                //obtengo el tiempo actual 
                long currentTime = GetTime();
                
                //calculo la diferencia de tiempo entre el tiempo actual y la última vez que se selccionó una carta
                long diff = currentTime - LastMeasuredTime;
                
                //si la diferencia de los tiempos es mayor a 500ms (medio segundo) voy a verificar la acción que debo realizar
                if (diff > 500)
                {
                    //vuelvo a reiniciar el tiempo en que se seleccionaron las cartas al menor valor posible
                    LastMeasuredTime = long.MinValue;

                    //obtengo las cartas asociadas a las casillas seleccionadas
                    Card c1 = Logic.GetCard(FirstSelection.Row, FirstSelection.Col);
                    Card c2 = Logic.GetCard(SecondSelection.Row, SecondSelection.Col);

                    if (c1.Equals(c2))
                    {
                        //si ambas cartas son iguales, borro la información de las cartas solicitadas y continúo mostrando las cartas
                        FirstSelection = null;
                        SecondSelection = null;
                    }
                    else
                    {
                        //en el caso que las carta son distintas, cambio su estado para que muestre el reverso de las cartas 
                        //y borro la selección
                        Logic.SetStatus(FirstSelection.Row, FirstSelection.Col, CardStatus.Back);
                        Logic.SetStatus(SecondSelection.Row, SecondSelection.Col, CardStatus.Back);

                        FirstSelection = null;
                        SecondSelection = null;

                    }
                }

            }

            //voy a contar cuántas cartas se encuentran mostrandose
            int sum = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    CardStatus status = Logic.GetStatus(i, j);
                    if (status == CardStatus.Front)
                    {
                        sum++;
                    }
                }
            }

            //si el total de cartas que se están mostrando es 36 significa que el usuario descubrió todas las cartas
            //y e juego debe terminar
            if (sum == 36)
            {
                finished = true;
            }
        }

        /// <summary>
        /// Definicón del método ProcessInput para ser usado dentro del Game Loop de uGame.
        /// 
        /// Este método es el encargado de procesar los datos relacionados con las entradas.
        /// </summary>
        /// <param name="mouseLocation">corresponde a la ubicación del mouse dentro de la pantalla de juego</param>
        /// <param name="isMousePressed">corresponde al estado del botón del mouse</param>
        public void ProcessInput(Point mouseLocation, bool isMousePressed)
        {
            //recorro todas las casillas
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    //si la carta no se encuentra de frente voy a realizar alguna acción
                    CardStatus status = Logic.GetStatus(i, j);
                    if (status != CardStatus.Front)
                    {
                        //dado que no está boca arriba, la voy a marcar como que se encuentra boca abajo
                        Logic.SetStatus(i, j, CardStatus.Back);

                        if (!isMousePressed)
                        {
                            //si el mouse no se encuentra presionado y se encuentra dentro del rectángulo donde se pinta la carta
                            //actualizo su estado para que se muestre Highlighted
                            Rectangle rectangle = Parser.Get(i, j);
                            if (rectangle.Contains(mouseLocation))
                            {
                                Logic.SetStatus(i, j, CardStatus.Highlighted);
                            }
                        }
                        else
                        {
                            //si el mouse se encuentra presionado y se encuentra dentro del rectángulo donde se pinta la carta
                            //actualizo su estado a Front
                            Rectangle rectangle = Parser.Get(i, j);
                            if (rectangle.Contains(mouseLocation))
                            {
                                Logic.SetStatus(i, j, CardStatus.Front);

                                
                                if (FirstSelection == null)
                                {
                                    //adicionalmente si no se ha seleccionado la primera carta, guardo su ubicación para utilizarla posteriormente 
                                    //en el método GameUpdate
                                    FirstSelection = new Pair(i, j);

                                    //guardo el tiempo en que se presionó el mpuse sobre esta carta para utilizarlo posteriormente en el método GameUpdate
                                    LastMeasuredTime = GetTime();
                                }
                                else if (SecondSelection == null)
                                {
                                    //adicionalmente si no se ha seleccionado la segunda carta, guardo su ubicación para utilizarla posteriormente 
                                    //en el método GameUpdate
                                    SecondSelection = new Pair(i, j);

                                    //guardo el tiempo en que se presionó el mpuse sobre esta carta para utilizarlo posteriormente en el método GameUpdate
                                    LastMeasuredTime = GetTime();
                                }

                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Definicón del método render para ser usado dentro del Game Loop de uGame.
        /// 
        /// Este método es el encargado de pintar el estado actual del juego en el objeto Graphics pasado como parámetro.
        /// </summary>
        /// <param name="g">área de dibujo donde se mostrará el juego</param>
        public void Render(Graphics g)
        {
            //recorro todas las casillas del tablero
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    //obtengo la información de dónde se debe pintar la carta, su estado y su valor
                    Rectangle rectangle = Parser.Get(i, j);
                    CardStatus status = Logic.GetStatus(i, j);
                    Card card = Logic.GetCard(i, j);

                    //desde la carta obtengo el nombre del recurso gráfico asiciado para pintarlo
                    string assetName = card.ToString();

                    if (status == CardStatus.Back)
                    {
                        //si la carta no se encuentra descubierta asigno el nombre del recurso gráfico correspondiente
                        assetName = "back";
                    }
                    else if (status == CardStatus.Highlighted)
                    {
                        //si la carta no se encuentra descubierta y se encuentra Highlighted asigno el nombre del recurso gráfico correspondiente
                        assetName = "highlighted";
                    }

                    //obtengo el obgeto Image asociado al nombre del recurso gráfico
                    Image image = uImageManager.Get(assetName);

                    //pinto la imagen en la posición de la carta
                    g.DrawImage(image, rectangle);
                }
            }
        }
    }
}
