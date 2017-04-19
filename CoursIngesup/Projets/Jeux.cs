using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Projets
{
    class Jeux
    {

        int choix = -1;

        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("              Game of Dames");
            Console.Write("\n");
            Console.Write("Bienvenue dans Game of Dames\n" +
                "Ceci est une version pro du jeux classique de Dame. \n" +
                "Le jeux ne vous indequera jamais quel pion jouer. \n" +
                "Tapez :\n" +
                " 0 - Débuter la partie.\n" +
                " 1 - Fuir comme un lâche.\n");
            choix = (int.Parse(Console.ReadLine()));

            if (choix == 1)
                Environment.Exit(0);
            else
                Console.Clear();
        } //Menu fun avant de lancer la partie

    }
}
