using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine;
using Memorice.Model;
using Memorice.Controller;

namespace Memorice
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Parser.Initialize();
            LoadResources();

            MemoriceGame game = new MemoriceGame(1024, 768, 30);
            game.Start();

            Application.Run();

        }

        static void LoadResources()
        {
            //Fuentes
            uFontManager.Load("Kenney Blocks.ttf", "blocks");


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
