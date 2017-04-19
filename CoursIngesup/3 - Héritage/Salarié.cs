using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup._3___Héritage
{
    abstract class Salarié
    {
        public int Salaire;
        public int Nbheures;

        public Salarié()
        {
            Salaire = 10;
            Nbheures = 5;
        }

        public Salarié(int Salaire, int Nbheures)
        {
            this.Salaire = Salaire;
            this.Nbheures = Nbheures;
        }

        public void CalculSalaire()
        {
            int SalaireparHeure = Salaire * Nbheures;
            Console.WriteLine("Salaire / heures : " + SalaireparHeure);
        }
    }
}
