using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup._5___Event
{
    class EventVoiture
    {
        public static void KmParcourus(object sender, EventArgs e)
        {
            Voiture tuture = (Voiture)sender;
            Console.WriteLine("nb de km parcourus : " + tuture.distance);
        }

        static void FauxMain()
        {
            Voiture test = new Voiture();
            test.essenceVide += KmParcourus;
            if (test.essence >= 0)
            {
                test.avancer(1);
            }
        }

    }
}
