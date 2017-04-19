using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Projets
{
    class Joueur
    {
        public bool Blanc;
        public int joueur;


        public Joueur(bool blanc)
        {
            Blanc = blanc;

            if (Blanc)
                joueur = 1;
            else
                joueur = 2;
        }
    }
}
