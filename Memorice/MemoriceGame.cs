using System;
using System.Drawing;

using uEngine;
using Memorice.Scenes;

namespace Memorice
{
    /// <summary>
    /// La clase MemoriceGame extiende a la clase abstracta uGame de la librería uEngine.
    /// Esta clase se encarga de presentar el juego Memorice, para ello se presentan las
    /// escenas de juego (GameScene) y de selección de nuevo juego (NewGameScene). 
    /// Para presentar el juego las escenas implementan los métodos GameUpdate, ProcessInput
    /// y Render.
    /// </summary>
    public class MemoriceGame : uGame
    {
        private GameScene Scene1;
        private NewGameScene Scene2;

        /// <summary>
        /// Atributo usado para identificar la escena que se presenta y procesa
        /// </summary>
        private int Status;

        /// <summary>
        /// Constructor de MemoriceGame que inicializa los datos de la super clase uGame.
        /// </summary>
        /// <param name="windowWidth">Ancho del área de juego</param>
        /// <param name="windowHeight">Alto del área de juego</param>
        /// <param name="targetFPS">FPS que el juego intentará alcanzar</param>
        public MemoriceGame(int windowWidth, int windowHeight, int targetFPS) : base(windowWidth, windowHeight, targetFPS)
        {
            this.Scene1 = new GameScene();
            this.Scene2 = new NewGameScene();
            this.Status = 1;
        }

        /// <summary>
        /// Método encargado de realizar las tareas de actualización del juego
        /// </summary>
        public override void GameUpdate()
        {
            if (this.Status == 1)
            {
                this.Scene1.GameUpdate();
                //si la escena de juego ha terminado cambio el valor de Status
                //para que se presente u ejecute la siguiente escena
                if(this.Scene1.IsFinished())
                {
                    this.Status = 2;
                }
            }
            else if(this.Status == 2)
            {
                this.Scene2.GameUpdate();
                //si la escena de nuevo juego ha terminado, hay que verificar 
                //que acción realizar, terminar el juego o volver a jugar
                if(this.Scene2.IsFinished())
                {
                    if(this.Scene2.IsNewGameSelected())
                    {
                        //en caso de volver a jugar, vuelvo a crear los objetos de escenas
                        //y reestablezco el valor de Status
                        this.Scene1 = new GameScene();
                        this.Scene2 = new NewGameScene();
                        this.Status = 1;
                    }
                    else
                    {
                        //termino el juego, el valor 0 se refiere que el programa
                        //terminó de forma correcta tal cual cómo debió terminar
                        Environment.Exit(0);
                    }    
                }
            }
        }

        /// <summary>
        /// Método encargado de procesar las entradas y realizar las actualizaciones 
        /// relacionadas con los eventos de entrada.
        /// </summary>
        public override void ProcessInput()
        {
            //debido que para procesar las entradas es necesario utilizar propiedades 
            //y métodos de la clase base, los prototipos de los métodos de cada una de
            //las escenas solicitan como parámetros la ubicación del mouse y el estado 
            //del botón del mouse
            if (this.Status == 1)
            {
                this.Scene1.ProcessInput(base.MouseLocation, base.isMousePressed());
            }
            else if (Status == 2)
            {
                this.Scene2.ProcessInput(base.MouseLocation, base.isMousePressed());
            }

        }

        /// <summary>
        /// Método encargado de pintar en cada frame.
        /// </summary>
        /// <param name="g">Objeto Graphics donde se debe pintar el juego</param>
        public override void Render(Graphics g)
        {
            //pinto un rectángulo blanco que cubre toda el área visible de juego
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, 1024, 768);

            if (this.Status == 1)
            {
                this.Scene1.Render(g);
            }
            else if (this.Status == 2)
            {
                this.Scene2.Render(g);
            }

        }
    }
}
