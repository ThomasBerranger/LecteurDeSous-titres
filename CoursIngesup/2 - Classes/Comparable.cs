using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Class.Variables
{
    class Comparable : IComparable
    {
        public int a;

        public Comparable()
        {
            a = new Random().Next(50);
        }

        public int CompareTo(object obj)
        {
            Collections coll = obj as Collections;
            if (a > coll.a)
                return 1;
            else if (a == coll.a)
                return 0;
            else
                return -1;
        }

        //https://msdn.microsoft.com/fr-fr/library/system.icomparable(v=vs.110).aspx

    }

    class testComparable
    {
        public void test()
        {
            List<Comparable> ListC = new List<Comparable>();
            ListC.Add(new Comparable());
            ListC.Add(new Comparable());
            ListC.Add(new Comparable());
            ListC.Add(new Comparable());
            ListC.Add(new Comparable());

            ListC.Sort();
        }
    }

    
}
