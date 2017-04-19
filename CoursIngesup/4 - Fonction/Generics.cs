using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Class
{
    class Generics
    {
        //https://msdn.microsoft.com/fr-fr/library/512aeb7t.aspx
        public static void Echanger<T>(ref T t1, ref T t2)
        {
            T temp = t1;
            t1 = t2;
            t2 = temp;

        }
    }
}
