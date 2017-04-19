using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Class.Variables
{
    class Date
    {

        //https://msdn.microsoft.com/fr-fr/library/system.datetime(v=vs.110).aspx

        public DateTime D;

        public Date()
        {
            D = DateTime.Now;
            TimeSpan t = new TimeSpan(10, 10, 10, 10);
            D = D.Add(t);


            //https://msdn.microsoft.com/fr-fr/library/system.globalization.cultureinfo(v=vs.110).aspx
            //Changer le format de la date
            CultureInfo CultureInfoUS = new CultureInfo("en-US");
            DateTime DateUS = DateTime.Parse(D.ToString(), CultureInfoUS);
            Console.WriteLine(DateUS);

            string format1 =  "yyyyMMdd";
            string format2 =  "yyyy-MM-dd";
            string DateFormated = D.ToString(format1);

            string DateString = "20161010";
            DateTime DateFromString = DateTime.Parse(DateString);
        }
    }
}
