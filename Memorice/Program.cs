using System;
using System.Windows.Forms;

using uEngine;
using Memorice.Controller;

/// <summary>
/// Para realizar una correcta documentación del código en C# es preferible utilizar las etiquetas
/// correspondientes que nos provee XmlDoc. La explicación de cada una de las etiquetas la podrán
/// encontrar en el siguiente link: 
/// <href>https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags</href>
/// 
/// El namespace Memorice contiene todas las clases de objetos relacionadas a la implementación
/// del juego Memorice, dentro de este namespece existen las siguientes subdivisiones:
/// 
/// <remarks>
/// Memorice.Model: namespace que contiene las clases de objetos relacionadas con la lógica 
/// del juego Memorice
/// </remarks>
/// 
/// <remarks>
/// Memorice.Controller: namespace que contiene las clases de objetos para convertir desde
/// los objetos de lógica a los objetos de vista
/// </remarks>
/// 
/// <remarks>
/// Memorice.Scenes: namespace que continen las clases de objetos de vista, en específico las 
/// diferentes escenas del juego.
/// </remarks>
/// 
/// </summary>

namespace Memorice
{
    /// <summary>
    /// Clase encargada de inicializar todos los recursos externos que se utilizarán
    /// y posteriormente lanzar la ventana de uGame
    /// </summary>
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Random random = new Random();

            string[] data = new string[1000];
            for (int i = 0; i < 1000; i++)
            {
                data[i] = random.Next(10000) + "";
            }

            System.IO.File.WriteAllLines("data.txt", data);



            //cargo los recursos externos a utilizar en el juego
            LoadResources();

            //el área visible de la ventana de juego será de 1024px de ancho y
            //768px de alto, el juego intentará llegar a 60FPS
            MemoriceGame game = new MemoriceGame(1024, 768, 30);
            game.Start();

            //necesario para que no se cierre la ejecución del programa
            Application.Run();

        }

        /// <summary>
        /// Método para cargar los recursos externos de imágenes y fuentes
        /// </summary>
        static void LoadResources()
        {
            //Fuentes
            uFontManager.Load("Kenney High Square.ttf", "high-square");

            //Imagenes para la escena de nuevo juego
            uImageManager.Load("NewGame/cinta-doblada.png", "cinta");
            uImageManager.Load("NewGame/tag.png", "tag-selected");
            uImageManager.Load("NewGame/tag-selected.png", "tag");
            uImageManager.Load("NewGame/pabrojas.png", "pabrojas");
            uImageManager.Load("NewGame/pabrojas2.png", "pabrojas2");


            //Cartas boca abajo
            uImageManager.Load("Cards/Back/cardBack_blue1.png", "back");
            uImageManager.Load("Cards/Back/cardBack_blue5.png", "highlighted");

            //Cartas boca arriba: Tréboles
            uImageManager.Load("Cards/Clubs/cardClubsA.png", "clubs1");
            uImageManager.Load("Cards/Clubs/cardClubs2.png", "clubs2");
            uImageManager.Load("Cards/Clubs/cardClubs3.png", "clubs3");
            uImageManager.Load("Cards/Clubs/cardClubs4.png", "clubs4");
            uImageManager.Load("Cards/Clubs/cardClubs5.png", "clubs5");
            uImageManager.Load("Cards/Clubs/cardClubs6.png", "clubs6");
            uImageManager.Load("Cards/Clubs/cardClubs7.png", "clubs7");
            uImageManager.Load("Cards/Clubs/cardClubs8.png", "clubs8");
            uImageManager.Load("Cards/Clubs/cardClubs9.png", "clubs9");
            uImageManager.Load("Cards/Clubs/cardClubs10.png", "clubs10");
            uImageManager.Load("Cards/Clubs/cardClubsJ.png", "clubs11");
            uImageManager.Load("Cards/Clubs/cardClubsQ.png", "clubs12");
            uImageManager.Load("Cards/Clubs/cardClubsK.png", "clubs13");

            //Cartas boca arriba: Diamantes
            uImageManager.Load("Cards/Diamonds/cardDiamondsA.png", "diamonds1");
            uImageManager.Load("Cards/Diamonds/cardDiamonds2.png", "diamonds2");
            uImageManager.Load("Cards/Diamonds/cardDiamonds3.png", "diamonds3");
            uImageManager.Load("Cards/Diamonds/cardDiamonds4.png", "diamonds4");
            uImageManager.Load("Cards/Diamonds/cardDiamonds5.png", "diamonds5");
            uImageManager.Load("Cards/Diamonds/cardDiamonds6.png", "diamonds6");
            uImageManager.Load("Cards/Diamonds/cardDiamonds7.png", "diamonds7");
            uImageManager.Load("Cards/Diamonds/cardDiamonds8.png", "diamonds8");
            uImageManager.Load("Cards/Diamonds/cardDiamonds9.png", "diamonds9");
            uImageManager.Load("Cards/Diamonds/cardDiamonds10.png", "diamonds10");
            uImageManager.Load("Cards/Diamonds/cardDiamondsJ.png", "diamonds11");
            uImageManager.Load("Cards/Diamonds/cardDiamondsQ.png", "diamonds12");
            uImageManager.Load("Cards/Diamonds/cardDiamondsK.png", "diamonds13");

            //Cartas boca arriba: Corazones
            uImageManager.Load("Cards/Hearts/cardHeartsA.png", "hearts1");
            uImageManager.Load("Cards/Hearts/cardHearts2.png", "hearts2");
            uImageManager.Load("Cards/Hearts/cardHearts3.png", "hearts3");
            uImageManager.Load("Cards/Hearts/cardHearts4.png", "hearts4");
            uImageManager.Load("Cards/Hearts/cardHearts5.png", "hearts5");
            uImageManager.Load("Cards/Hearts/cardHearts6.png", "hearts6");
            uImageManager.Load("Cards/Hearts/cardHearts7.png", "hearts7");
            uImageManager.Load("Cards/Hearts/cardHearts8.png", "hearts8");
            uImageManager.Load("Cards/Hearts/cardHearts9.png", "hearts9");
            uImageManager.Load("Cards/Hearts/cardHearts10.png", "hearts10");
            uImageManager.Load("Cards/Hearts/cardHeartsJ.png", "hearts11");
            uImageManager.Load("Cards/Hearts/cardHeartsQ.png", "hearts12");
            uImageManager.Load("Cards/Hearts/cardHeartsK.png", "hearts13");

            //Cartas boca arriba: Picas
            uImageManager.Load("Cards/Spades/cardSpadesA.png", "spades1");
            uImageManager.Load("Cards/Spades/cardSpades2.png", "spades2");
            uImageManager.Load("Cards/Spades/cardSpades3.png", "spades3");
            uImageManager.Load("Cards/Spades/cardSpades4.png", "spades4");
            uImageManager.Load("Cards/Spades/cardSpades5.png", "spades5");
            uImageManager.Load("Cards/Spades/cardSpades6.png", "spades6");
            uImageManager.Load("Cards/Spades/cardSpades7.png", "spades7");
            uImageManager.Load("Cards/Spades/cardSpades8.png", "spades8");
            uImageManager.Load("Cards/Spades/cardSpades9.png", "spades9");
            uImageManager.Load("Cards/Spades/cardSpades10.png", "spades10");
            uImageManager.Load("Cards/Spades/cardSpadesJ.png", "spades11");
            uImageManager.Load("Cards/Spades/cardSpadesQ.png", "spades12");
            uImageManager.Load("Cards/Spades/cardSpadesK.png", "spades13");
        }
    }
}
