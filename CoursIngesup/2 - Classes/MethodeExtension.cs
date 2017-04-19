using CoursIngesup.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Class
{
    //https://msdn.microsoft.com/fr-fr/library/bb383977.aspx
    public static class StringExtension
    {
        public static int WordCount(this String str)
        {
            return str.Split(' ').Length;
        }
    }
}

namespace Test
{
    class Program   
    {
        static void Coucou(string[] args)
        {
            string s = "Coucou je suis une phrase.";
            int i = s.WordCount();
            Console.WriteLine(i);
        }
    }
}