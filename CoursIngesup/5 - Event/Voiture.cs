using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup._5___Event
{
    class Voiture
    {

        public int essence;
        public int distance;
        public int conso;
        public int km;
        public EventHandler essenceVide;

        public Voiture()
        {
            essence = 20;
            distance = 300;
            conso = 2;
        }

        public void avancer(int km)
        {
            if (essence >= 0)
            {
                essence -= km * conso;
                distance += km;
            }
            else
            {
                OnEssenceVide(EventArgs.Empty);
            }

        }

        protected void OnEssenceVide(EventArgs e)
        {
            if (essenceVide != null)
            {
                essenceVide.Invoke(this, e);
            }
        }


        public void affichage()
        {
            Console.WriteLine("Cette voiture a " + essence + " litres d'essences \n");
            Console.WriteLine("Cette voiture a parcouru " + distance + " KMs \n");
            Console.WriteLine("Cette voiture consomme " + conso + " litres pour 100KMs \n");
        }

    }
}
