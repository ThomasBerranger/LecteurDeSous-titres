using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;

namespace CoursIngesup.Projet2
{
    class Lecture
    {
        List<SousTitres> soustitres = new List<SousTitres>();

        Timer timer;

        string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public int DateTotaleDébut = 0;
        public int DateTotaleFin = 0;
        public string Text = "Lorem";
        public int TempsApparition = 0;
        public int TempsSéparation = 0;
        public int numéro = 0;
        public int NumeroTest = 1;

        public void RemplisListSousTitres()
        {
            try
            {
                using (StreamReader sr = new StreamReader(mydocpath + @"\text.srt"))
                {
                    string l;
                    while ((l = sr.ReadLine()) != null)
                    {
                        int useless = 0;
                        bool result = int.TryParse(l, out useless);
                        if (result == true)
                        {
                            numéro = Int32.Parse(l);
                            //System.Console.WriteLine("Numéro du sous titre"); // pour le moment on ne fai rien du n° de sous titre
                        }
                        else if (l.Contains(" --> "))
                        {
                            //Console.WriteLine("Timing : " + l); //ligne de time

                            char[] delimiterChars = { ' ', ':', ',' };
                            string[] words = l.Split(delimiterChars);
                            int DélimiteDébutFin = 0, Incremente = 0, Dheure = 0, Dminutes = 0, Dsecondes = 0, Dmilisecondes = 0, Fheure = 0, Fminutes = 0, Fsecondes = 0, Fmilisecondes = 0;

                            foreach (string s in words)
                            {
                                if (s == "-->")
                                {
                                    DélimiteDébutFin++;
                                }
                                else if(DélimiteDébutFin == 0)
                                {
                                    if(Incremente == 0)
                                    {
                                        Dheure = Int32.Parse(s);
                                    }
                                    else if (Incremente == 1)
                                    {
                                        Dminutes = Int32.Parse(s);
                                    }
                                    else if (Incremente == 2)
                                    {
                                        Dsecondes = Int32.Parse(s);
                                    }
                                    else if (Incremente == 3)
                                    {
                                        Dmilisecondes = Int32.Parse(s);
                                    }

                                    Incremente++;
                                }
                                else
                                {
                                    if (Incremente == 4)
                                    {
                                        Fheure = Int32.Parse(s);
                                    }
                                    else if (Incremente == 5)
                                    {
                                        Fminutes = Int32.Parse(s);
                                    }
                                    else if (Incremente == 6)
                                    {
                                        Fsecondes = Int32.Parse(s);
                                    }
                                    else if (Incremente == 7)
                                    {
                                        Fmilisecondes = Int32.Parse(s);
                                    }

                                    Incremente++;
                                }
                            }

                            //Console.WriteLine(Dheure + " " + Dminutes + " " + Dsecondes + " " + Dmilisecondes + " -- > " + Fheure + " " + Fminutes + " " + Fsecondes + " "+ Fmilisecondes);

                            DateTotaleDébut = 360000 * Dheure + 60000 * Dminutes + Dsecondes*1000 + Dmilisecondes;
                            DateTotaleFin = 360000 * Fheure + 60000 * Fminutes + Fsecondes*1000 + Fmilisecondes;
                            

                        }
                        else if(l.Length == 0)
                        {
                            //Console.WriteLine("Ligne vide -> fin du sous-titre. \n\n"); //ligne vide donc création d'un nouveau sous-titre
                            soustitres.Add(new SousTitres(DateTotaleDébut, DateTotaleFin, Text, numéro));
                        }
                        else
                        {
                            //Console.WriteLine("Text de la ligne : " + l); //text de la ligne en question ! ne peut lire qu'une foi
                            Text = l;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //Pour chaque ligne (l) :
        //Si l == nombre alors on s'en fiche
        //Si l contient --> alors on récupère les valeurs, ont fait des calculs et on a un date de début et de fin
        //Si l taille == 0 alors on balance les variables dans un nouveau sous-titre contenu dans la liste de sous-titres
        //Si rien de ces conditions ne sont remplies, alors le contenu (censé être du text) est contenu dans un variable


        public void LireSousTitre()
        {
            var LesSousTitres = from p in soustitres where p.numéro == 1 select new { p.datetotaledébut, p.datetotalefin, p.text, p.numéro };
            foreach (var v in LesSousTitres)
            {
                TempsApparition = v.datetotaledébut;
            }
            Timer(TempsApparition);
        }
        //Regarde le temps d'attente avant le premier sous-titre puis lance Timer()


        public void Timer(int millisecond)
        {
            timer = new Timer(millisecond);
            timer.Elapsed += HandleTimer;
            timer.Enabled = true;
        }
        
        private void HandleTimer(object o, EventArgs e) //Gère le temps d'apparition
        {
            Console.Clear();
            var LesSousTitres = from p in soustitres where p.numéro == NumeroTest select new { p.datetotaledébut, p.datetotalefin, p.text, p.numéro };
            foreach (var v in LesSousTitres)
            {

                TempsApparition = v.datetotalefin - v.datetotaledébut;
                Console.WriteLine("Sous-titre n° " + v.numéro + "\nDate de début : " + v.datetotaledébut + " --> Date de fin : " + v.datetotalefin + ", Temps d'apparition : " + TempsApparition + " millisecondes.");
                if(v.text.Contains("<i>") || v.text.Contains("</i>"))
                {
                    string TextSansBaliseI = v.text;
                    TextSansBaliseI = v.text.Replace("<i>", "").Replace("</i>", "");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n" + TextSansBaliseI + " (présence de balise <i> détéctée)");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine("\n" + v.text);
                }

            }
            timer.Enabled = false;
            NumeroTest++;
            Timer2(TempsApparition);
        }


        public void Timer2(int millisecond2)
        {
            timer = new Timer(millisecond2);
            timer.Elapsed += HandleTimer2;
            timer.Enabled = true;
        }

        private void HandleTimer2(object o, EventArgs e) //Gère le temps de séparation
        {
            Console.Clear();

            int TempsPremierFin =0;
            int TempsSecondDébut =0;

            var SousTitrePremier = from p in soustitres where p.numéro == NumeroTest select new { p.datetotaledébut, p.datetotalefin, p.text, p.numéro };
            foreach (var v in SousTitrePremier)
            {
                TempsPremierFin = v.datetotalefin;
                
            }
            var SousTitreSecond = from p in soustitres where p.numéro == NumeroTest+1 select new { p.datetotaledébut, p.datetotalefin, p.text, p.numéro };
            foreach (var v in SousTitreSecond)
            {
                TempsSecondDébut = v.datetotaledébut;
                
            }

            TempsSéparation = TempsSecondDébut - TempsPremierFin;

            Console.WriteLine("Attente : " + TempsSéparation + " millisecondes.");
            timer.Enabled = false;
            Timer(TempsSéparation);
        }
    }
}
