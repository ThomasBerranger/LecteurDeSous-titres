using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup._1___Variables
{
    class Exo_Date
    {
        public int inutil; // Variable

        public Exo_Date() //Constructeur
        {

        }

        public void Date() //Fonctions
        {

            DateAuj();

            DateDem();

            DateSom();

            DatePJ();

            Console.ReadLine();
        }

        private void DateAuj()
        {

            Console.WriteLine(" Date d'aujourd'hui :");
            DateTime D = DateTime.Now;
            Console.WriteLine(D + "\n");
        }

        private void DateDem()
        {

            Console.WriteLine(" Date de demain :");
            DateTime D = DateTime.Now;
            TimeSpan t = new TimeSpan(1, 0, 0, 0);
            D = D.Add(t);
            Console.WriteLine(D + "\n");
        }

        private void DateSom()
        {
            Console.WriteLine(" Date d'aujourd'hui + demain : (addition des jours seulement)");
            DateTime D = DateTime.Now;
            DateTime D2 = DateTime.Now;
            TimeSpan t = new TimeSpan(1, 0, 0, 0);
            D2 = D2.Add(t);

            int D2d = D2.Day;

            DateTime DSom = D;
            TimeSpan t2 = new TimeSpan(D2d, 0, 0, 0);
            DSom = D.Add(t2);

            Console.WriteLine(D + " + " + D2 + " = " + DSom + "\n");
        }

        private void DatePJ()
        {

            Console.WriteLine(" Noms des 3 prochains jours :");
            DateTime D = DateTime.Now;

            DateTime D1 = D;
            DateTime D2 = D;
            DateTime D3 = D;

            TimeSpan t = new TimeSpan(1, 0, 0, 0);
            D1 = D.Add(t);
            TimeSpan t2 = new TimeSpan(2, 0, 0, 0);
            D2 = D.Add(t2);
            TimeSpan t3 = new TimeSpan(3, 0, 0, 0);
            D3 = D.Add(t3);

            String j = D.DayOfWeek.ToString();
            String j1 = D1.DayOfWeek.ToString();
            String j2 = D2.DayOfWeek.ToString();
            String j3 = D3.DayOfWeek.ToString();

            Console.WriteLine( "Aujourd'hui : " + j + " -> " + j1 + " -> " + j2 + " -> " +j3 + "\n");

        }

    }
}
