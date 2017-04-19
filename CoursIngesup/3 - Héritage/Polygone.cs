using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup._3___Héritage
{
    abstract class Polygone
    {
        #region variable
        public List<Point> points;
        #endregion


        #region constructeur
        public Polygone()
        {
            points = new List<Point>();
        }
        #endregion


        #region fonction
        public virtual int nbPoints()
        {
            return points.Count();
        }
        #endregion
    }
}
