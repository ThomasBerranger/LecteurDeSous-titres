using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup._3___Héritage
{
    class Polygone1 : Polygone
    {
        public Polygone1() : base()
        {
            points.Add(new Point());
            points.Add(new Point());
        }


        public override int nbPoints()
        {
            Console.WriteLine("Nombre de points : " + base.nbPoints());
            return base.nbPoints();
        }

    }
}
