using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Projet2
{
    class SousTitres
    {

        public int datetotaledébut=0;
        public int datetotalefin=0;
        public string text;
        public int numéro;
        

        public SousTitres(int DateTotalDébut, int DateTotalFin, string Text, int Numéro)
        {
            datetotaledébut = DateTotalDébut;
            datetotalefin = DateTotalFin;
            text = Text;
            numéro = Numéro;
        }

    }
}
