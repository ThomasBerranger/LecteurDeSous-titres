using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup._3___Héritage
{
    class Patron : Salarié
    {
        public int Bonus;

        public Patron()
        {
            Bonus = 100;
        }

        public Patron(int Salaire, int Nbheures) : base(Salaire, Nbheures)
        {
            Bonus = 100;
        }

        #region Fonctions
        public virtual void CalculSalaire()
        {
            base.CalculSalaire();
            int SalaireparHeurePatron = Salaire * Nbheures + Bonus;
            Console.WriteLine("Salaire / heures du patron : " + SalaireparHeurePatron);
        }
        #endregion
    }
}
