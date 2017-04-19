using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Class
{

    //https://msdn.microsoft.com/fr-fr/library/wa80x488.aspx

    partial class PartialClass
    {
        partial void Fct(string s);
    }

    partial class PartialClass
    {
        partial void Fct(string s)
        {
            Console.WriteLine("Coucou");
        }
    }

}
