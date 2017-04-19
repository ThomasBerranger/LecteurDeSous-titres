using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Class2
{
    class Arguments_nommés_et_facultatifs
    {
        string s;


        public int Test (int a, string coucou = "coucou", int b = 1)
        {
            int c = a * b;
            Console.WriteLine(coucou);
            return 0;
        }

        public void Appel()
        {
            Console.WriteLine(Test(1));
            Console.WriteLine(Test(1, "Hey"));
            Console.WriteLine(Test(1, "Hey", 2));
            Console.WriteLine(Test(a : 1, b: 3));
            Console.WriteLine(Test(b : 3, a: 1));
            Console.WriteLine(Test(coucou : "Hey" ,b : 3, a: 1));
        }
    }
}
