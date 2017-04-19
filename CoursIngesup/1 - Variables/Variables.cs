using CoursIngesup.Class;
using CoursIngesup.Class.Interface;
using System;

namespace CoursIngesup
{
    class Variables
    {
        static void Test(string[] args)
        {
            #region Variables

            int a = 2;
            float b = 2.7f;
            double d = 3.65d;
            char c = 'G';

            string Surname = "Nobert";
            string Name = "Dragonneau";
            string NameSurname = Name + " " + Surname;

            int h = (int)1.2f;

            #endregion

            #region Opérations arithmétiques
            int add = 2 + a;
            float sub = b - 5;
            float div = 2 / 5;

            a++;
            a--;
            a += 10;
            a -= 10;
            a /= 2;

            char ch = Console.ReadKey().KeyChar;
            Console.WriteLine(ch);

            #endregion

            #region Les conditions

            if (a > 2)
                Console.WriteLine(a + " Supérieur à 2");
            else
                Console.WriteLine(a + " Inférieur ou égal à 2");

            //Egalité
            if (a == 1)
            { }
            // et 
            if (a > 2 && a <= 4)
            { }
            // ou
            if (a > 2 || a <= 4)
            { }
            // Negation
            if (!(a>=1 || a<=0))
            { }


            switch (a)
            {
                case 1:
                    Console.WriteLine(a + " égal à 1");
                    break;
                case 2:
                    Console.WriteLine(a + " égal à 2");
                    break;
                case 3:
                    Console.WriteLine(a + " égal à 3");
                    break;
                default:
                    break;
            }
            #endregion

            #region Les boucles
            while (a <= 1)
                a++;

            do
            {
                a++;
            }
            while (a < 0);

            for (int i = 0; i < 10; i++)
                a++;

            int[] tab = new int[10];
            for (int i = 0; i < tab.Length; i++)
                tab[i] = i;

            int somme = 0;
            foreach (int i in tab)
                somme+=i;

            #endregion

            /*
            Console.ReadLine();

            string a1 = "azeaze";
            string a2 = "aaaaae";

            Generics.Echanger<string>(ref a1, ref a2);

            Random r = new Random(132456798);
            double m = r.NextDouble();*/
        }
    }
}
