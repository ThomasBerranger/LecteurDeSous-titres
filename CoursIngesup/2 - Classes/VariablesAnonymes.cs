using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Class.Variables
{
    class VariablesAnonymes
    {
        public string name;
        public string adress;
        public string town;

        public void TestVariablesAnonymes()
        {
            //https://msdn.microsoft.com/fr-fr/library/bb397696.aspx
            var ex = new { Amount = 108, Message = "Hello" };
            Console.WriteLine(ex.Amount);


            List<VariablesAnonymes> variables = new List<VariablesAnonymes>();

            var adressOfToto = from v in variables
                               where v.name == "Toto"
                               select new { v.adress, v.town };

            foreach (var v in adressOfToto)
            {
                Console.WriteLine(v.adress+" "+v.town);
            }
        }
    }
}
