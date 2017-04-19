using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup._3___Héritage
{
    class Avion : Vehicule
    {

        public int nbMoteur;

        public Avion() : base()
        {
            nbMoteur = 8;
        }

        public Avion(int nbPassagers, int nbMoteur) : base(nbPassagers)
        {
            this.nbMoteur = nbMoteur;
        }

        public override string Affiche()
        {
            Console.WriteLine(base.Affiche() + " et " + nbMoteur + " moteurs.");
            return base.Affiche();
        }
    }
}
