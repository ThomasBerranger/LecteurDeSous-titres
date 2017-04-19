using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup._1___Variables
{
    class Strings
    {
        public void StringsExemple()
        {

            //https://msdn.microsoft.com/fr-fr/library/system.string(v=vs.110).aspx

            string s = "azerzer";

            //concaténation
            string s2 = s + "coucou";
            s2 += "aaaa";

            //Recupération du premier et dernier charactère 
            char first = s[0];
            char last = s[s.Length - 1];

            //Couper un string
            string[] split = s.Split('z');  // a, er, er

            //String litteral 
            string path = @"c:\Docs\Source\a.txt";

            //String contenue dans une autre
            string s3 = "Hello world";
            string s4 = "world";
            bool b = s3.Contains(s4); //true

            //Recherche de la place d'un char
            string s5 = "azertyui";
            int PlaceLettreT = s5.IndexOf('t');

            //transformation d'un tableau en string
            int[] values = { 1, 5, 4189, 11434, 366 };
            Console.WriteLine(String.Join("|", values));//"1|5|4189|11434|366"

            //retirer et ou remplacer des parties d'un string
            string s6 = "aaazzzaaa";
            s6.Remove(3, 3); //"aaaaaa"
            s6.Replace("zzz", "hhh"); //"aaahhhaaa"
            s6.Substring(3);//"zzzaaa"

            //Changement de case
            string s7 = "AaAa";
            s7.ToLower();//"aaaa"
            s7.ToUpper();//"AAAA"
        }

    }
}
