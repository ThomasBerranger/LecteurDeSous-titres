using CoursIngesup._2___Classes;
using CoursIngesup._3___Héritage;
using CoursIngesup._4___Fonction;
using CoursIngesup._5___Event;
using CoursIngesup.Class2;
using CoursIngesup.Projet2;
using CoursIngesup.Projets;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup._1___Variables
{
    class Prog
    {
        public static void Main()
        {

            //Exo_Date exo_date = new Exo_Date();
            //exo_date.Date();

            //Patron patron = new Patron();
            //patron.CalculSalaire();

            //Polygone1 polygone1 = new Polygone1();
            //polygone1.nbPoints();

            //Avion avion = new Avion();
            //avion.Affiche();

            //Arguments_nommés_et_facultatifs arg = new Arguments_nommés_et_facultatifs();
            //arg.Appel();

            //Ville ville = new Ville("Ville ");
            //ville.CreateVille();
            //ville.ListVille();


            //Plateau plateau = new Plateau();
            //plateau.Game();


            /*
            Voiture V = new Voiture();
            V.affichage();
            V.essenceVide += EventVoiture.KmParcourus;
            while (V.essence >= -3)
            {
                V.avancer(1);
            }
            */


            /*LectureText exo = new LectureText();
            exo.Lecture();
            exo.Read();*/


            Lecture lecture = new Lecture();
            lecture.RemplisListSousTitres();
            lecture.LireSousTitre();
            




            Console.ReadLine();
        }
    }
}
