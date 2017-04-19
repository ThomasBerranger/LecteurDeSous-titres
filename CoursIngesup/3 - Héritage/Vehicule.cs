using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup._3___Héritage
{
    abstract class Vehicule
    {
        public int nbPassagers;

        public Vehicule()
        {
            nbPassagers = 4;
        }

        public Vehicule(int nbPassagers)
        {
            nbPassagers = 4;
        }

        public string Passagers()
        {
            return nbPassagers.ToString();
        }

        public virtual string Affiche()
        {
            return "Il y a " + nbPassagers + " passagers dans cet avion";
        }
    }
}
