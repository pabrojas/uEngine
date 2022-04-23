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
    /// La clase NewGameScene es la encargada de pintar y procesar la escena de selección de nuevo juego 
    /// </summary>
    public class NewGameScene
    {
        /// <summary>
        /// Atributo encargado de almacenar la ubicación en pantalla el botón de nuevo juego
        /// </summary>
        private Rectangle NewGameButton;

        /// <summary>
        /// Atributo encargado de almacenar la ubicación en pantalla el botón de salir
        /// </summary>
        private Rectangle QuitButton;

        /// <summary>
        /// Atributo encargado de almacenar la ubicación en pantalla el la imagen del profe pabrojas
        /// </summary>
        private Rectangle PabrojasImage;

        /// <summary>
        /// Atributo bool utilizado para pintar el botón de nuevo juego de forma normal (false) o Highlighted (true)
        /// </summary>
        private bool NewGameButtonHighlighted;

        /// <summary>
        /// Atributo bool utilizado para pintar el botón de salir de forma normal (false) o Highlighted (true)
        /// </summary>
        private bool QuitButtonHighlighted;

        /// <summary>
        /// Atributo bool utilizado para pintar uno de los 2 frames de la imagen del profe pabrojas 
        /// </summary>
        private bool PabrojasButtonHighlighted;

        /// <summary>
        /// Atributo usado para almacenar el estado de termino de la escena y del juego, cuando esta variable almacena un true
        /// significa que la escena debe terminar para que el juego termine, en cualquier otro case debe almacenar false.
        /// </summary>
        private bool EndedFlag;

        /// <summary>
        /// Atributo usado para almacenar el estado de termino de la escena y comenzar un nuevo juego, cuando esta variable almacena un true
        /// significa que la escena debe terminar para que inicie el nuevo juego, en cualquier otro case debe almacenar false.
        /// </summary>
        private bool NewGameFlag;


        /// <summary>
        /// Constructor de la calse NewGameScene.
        /// </summary>
        public NewGameScene()
        {
            //inicializo las ubicaciones de los botones y la imagen de profe pabrojas
            this.NewGameButton = new Rectangle(650, 450, 909 / 3, 306 / 3);
            this.QuitButton = new Rectangle(650, 570, 909 / 3, 306 / 3);
            this.PabrojasImage = new Rectangle(0, 368, 400, 400);

            //inicializo los estados de los botones y de la variable para la selección del frame de la imagen del profe pabrojas
            this.NewGameButtonHighlighted = false;
            this.QuitButtonHighlighted = false;
            this.PabrojasButtonHighlighted = false;

            //inicializo en false las variables para indicar el término de esta escena
            this.EndedFlag = false;
            this.NewGameFlag = false;
        }

        /// <summary>
        /// Este método indica si la escena ha terminado
        /// </summary>
        /// <returns>true cuando la escena ha terminado, false en caso contrario</returns>
        public bool IsFinished()
        {
            //si alguno de los estados asociados a los botones es verdadero, la escena rebe terminar
            return this.EndedFlag || this.NewGameFlag;
        }

        /// <summary>
        /// Este método indica si se seleccionó el botón de finalización del juego.
        /// </summary>
        /// <returns>true si el juego debe terminar, false de lo contrario.</returns>
        public bool IsEndedSelected()
        {
            return this.EndedFlag;
        }

        /// <summary>
        /// Este método indica si se seleccionó el botón de inicio de un nuevo juego.
        /// </summary>
        /// <returns>true si el juego debe volver a inciar, false de lo contrario</returns>
        public bool IsNewGameSelected()
        {
            return this.NewGameFlag;
        }

        /// <summary>
        /// Definición del método GameUpdate para ser usado dentro del Game Loop de uGame.
        /// </summary>
        public void GameUpdate()
        {
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
            //actualizo el estado de los botones y del frame a pintar del sprite del profe pabrojas
            //la actualización consiste en revisar si el rectángulo asiciado a los elementos contiene al punto de la ubicación del mouse
            this.NewGameButtonHighlighted = NewGameButton.Contains(mouseLocation);
            this.QuitButtonHighlighted = QuitButton.Contains(mouseLocation);
            this.PabrojasButtonHighlighted = PabrojasImage.Contains(mouseLocation);

            //si el estado del botón del nuevo juego es verdadero (el mouse se encuentra dentro del botón)
            //y el mouse se encuentra presionado
            if( NewGameButtonHighlighted && isMousePressed )
            {
                //actualizo los atributos de término de esta escena para iniciar un nuevo juego
                this.EndedFlag = false;
                this.NewGameFlag = true;
            }

            //si el estado del botón de término del juego es verdadero (el mouse se encuentra dentro del botón)
            //y el mouse se encuentra presionado
            if ( this.QuitButtonHighlighted && isMousePressed )
            {
                //actualizo los atributos de término de esta escena para terminar el juego
                this.EndedFlag = true;
                this.NewGameFlag = false;
            }
        }

        /// <summary>
        /// Definicón del método render para ser usado dentro del Game Loop de uGame.
        /// 
        /// Este método es el encargado de pintar el estado actual de la escena de nuevo juego en el objeto Graphics pasado como parámetro.
        /// </summary>
        /// <param name="g">área de dibujo donde se mostrará el juego</param>
        public void Render(Graphics g)
        {
            //pinto la cinta
            g.DrawImage(uImageManager.Get("cinta"), 62, 0, 900, 380);
            //sobre la cienta pinto el mensaje de felicitaciones con la fuente seleccionada
            g.DrawString("¡Felicitaciones!", uFontManager.Get("high-square", 102), new SolidBrush(Color.FromArgb(55, 55, 55)), 170, 120);

            //variables para pintar el texto de los botones
            Font font = new Font(uFontManager.Get("high-square", 36), FontStyle.Bold);
            int dx = 35;
            int dy = 28;

           
            if (this.NewGameButtonHighlighted)
            {
                //pinto el botón de nuevo juego cuando se encuentra seleccionado
                g.DrawImage(uImageManager.Get("tag"), this.NewGameButton);
                g.DrawString("Nuevo juego", font, new SolidBrush(Color.FromArgb(53, 53, 53)), this.NewGameButton.X + dx, this.NewGameButton.Y + dy);
            }
            else
            {
                //pinto el botón de nuevo juego cuando no se encuentra seleccionado
                g.DrawImage(uImageManager.Get("tag-selected"), this.NewGameButton);
                g.DrawString("Nuevo juego", font, new SolidBrush(Color.Black), this.NewGameButton.X + dx, this.NewGameButton.Y + dy);
            }

            if (this.QuitButtonHighlighted)
            {
                //pinto el botón de salir del juego cuando se encuentra seleccionado
                g.DrawImage(uImageManager.Get("tag"), this.QuitButton);
                g.DrawString("Salir", font, new SolidBrush(Color.FromArgb(53, 53, 53)), this.QuitButton.X + dx, this.QuitButton.Y + dy);
            }
            else
            {
                //pinto el botón de salir del juego cuando no se encuentra seleccionado
                g.DrawImage(uImageManager.Get("tag-selected"), this.QuitButton);
                g.DrawString("Salir", font, new SolidBrush(Color.Black), this.QuitButton.X + dx, this.QuitButton.Y + dy);
            }

            
            //pinto el frame correspondiente al sprite del profe pabrojas
            if (this.PabrojasButtonHighlighted)
            {
                g.DrawImage(uImageManager.Get("pabrojas2"), this.PabrojasImage);
            }
            else
            {
                g.DrawImage(uImageManager.Get("pabrojas"), this.PabrojasImage);
            }
        }
    }
}
