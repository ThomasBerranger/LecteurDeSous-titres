using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup._2___Classes
{
    class Ville
    {

        public string nom;
        public int nbHabitants;
        public int superficie;
        
        List<Ville> ville = new List<Ville>();

        Random rmd = new Random();

        public Ville(string name/*, new Random*/)
        {
            nbHabitants = rmd.Next(0, 1000);
            superficie = rmd.Next(0, 1000);
            nom = name;
        }

        public void CreateVille()
        {
            for (int i = 0; i < 100; i++)
            {
                ville.Add(new Ville(nom + i));
            }
        }

        public void ListVille()
        {
            var VilleOver50 = from p in ville where p.nbHabitants >= 50 select new { p.nom, p.nbHabitants };
            foreach (var v in VilleOver50)
                Console.WriteLine(v.nom + " possède " + v.nbHabitants + " habitants.");
        }

    }
}
