using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Projets
{
    class Dame : Pion
    {

        public bool Blanc;
        public char joueur;

        public Dame(bool blanc) : base(true)
        {
            Blanc = blanc;

            if (Blanc)
                joueur = 'B';
            else
                joueur = 'N';
        }
        
    }
}
