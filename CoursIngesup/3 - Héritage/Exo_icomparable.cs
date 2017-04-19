using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup._3___Héritage
{
    class Exo_icomparable : IComparable
    {
        int chiffre;

        public Exo_icomparable()
        {

        }

        public int CompareTo(object obj)
        {
            Exo_icomparable p1 = (Exo_icomparable)obj;
            if ((p1.chiffre % 2 == 0 && chiffre % 2 == 0) || (p1.chiffre % 2 == 1 && chiffre % 2 == 1))
                return 0;
            else if (p1.chiffre % 2 == 1 && chiffre % 2 == 0)
                return 1;
            else
                return -1;
        }
    }
}
