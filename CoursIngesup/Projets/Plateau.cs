using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Projets
{
    class Plateau
    {

        Jeux jeux = new Jeux(); //Juste pour la fct qui lance le jeu

        Joueur joueur1 = new Joueur(true); //2 joueur diff
        Joueur joueur2 = new Joueur(false);

        int xmax = 8;
        int ymax = 8;

        int nbPionBlanc = 0;
        int nbPionNoir = 0;

        public Pion P = new Pion(true);

        public Pion[,] plateau; //Plateau de Pion
        public Pion PionBlanc = new Pion(true); //2 pions diff
        public Pion PionNoir = new Pion(false);

        public Plateau()
        {
            plateau = new Pion[xmax, ymax];
        } // Possiblité de mofifier les valeurs du plateau facilement

        #region Fonctions

        public void CreatePlateau()
        {
            for (int x = 0; x < xmax; x++)
            {
                for (int y = 0; y < ymax; y++)
                {
                    plateau[x, y] = null;
                }
            }
        } // Remplis le tableau de bull
        

        public void LirePlateau()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("              Game of Dames");
            Console.Write("\n");
            ListerPion();
            Console.ForegroundColor = ConsoleColor.White;

            for (int y = 0; y < ymax; y++)
            {
                Console.Write("    " + y + " ");
                for (int x = 0; x < xmax; x++)
                {
                    if (plateau[x,y] == null)
                        Console.Write(" |  ");
                    else
                    {
                        Console.Write(" | ");
                        if (plateau[x, y].joueur == PionBlanc.joueur)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(plateau[x, y].joueur);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(plateau[x, y].joueur);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        
                    }
                }
                Console.Write(" | \n         -   -   -   -   -   -   -   -\n");
            }
            Console.Write("      ");
            for (int i = 0; i < xmax; i++)
                Console.Write("   " + i);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n- Règles : Les minuscules sont des pions (b, r), les majuscules sont des dames (B, R).");
            Console.ForegroundColor = ConsoleColor.White;
        } //Lis le tableau en faisant attention entre les types Pion et null
        

        public void RemplirTableau()
        {
            int ligne = 7;

            if (ligne == 7)
            {
                for (int x = 0; x < xmax; x++)
                {
                    x++;
                    plateau[x, ligne] = new Pion(true);
                }
                ligne--;
            }
            if(ligne == 6)
            {
                for (int x = 0; x < xmax; x++)
                {
                    plateau[x, ligne] = new Pion(true);
                    x++;
                }
                ligne--;
            }
            if (ligne == 5)
            {
                for (int x = 0; x < xmax; x++)
                {
                    x++;
                    plateau[x, ligne] = new Pion(true);
                }
                ligne = 2;
            }
            if (ligne == 2)
            {
                for (int x = 0; x < xmax; x++)
                {
                    plateau[x, ligne] = new Pion(false);
                    x++;
                }
                ligne--;
            }
            if (ligne == 1)
            {
                for (int x = 0; x < xmax; x++)
                {
                    x++;
                    plateau[x, ligne] = new Pion(false);
                }
                ligne--;
            }
            if (ligne == 0)
            {
                for (int x = 0; x < xmax; x++)
                {
                    plateau[x, ligne] = new Pion(false);
                    x++;
                }
            }

            // Pour les test modifier ici comme ici
            //plateau[2, 4] = new Pion(false);

        } //Remplis le tableau comme il faut pour une nouvelle partie !!! Au fait pour te facilité les test, modifie ici ;)


        public void SelectPion(Joueur joueur)
        {
            int xOr = 0;
            int yOr = 0;
            
            int choix = 0;

            Joueur JoueurEnQuestion = new Joueur(true);

            if (joueur.joueur == 1)
                JoueurEnQuestion = new Joueur(true);
            else
                JoueurEnQuestion = new Joueur(false);


            if (JoueurEnQuestion.joueur == 1)
            {
                while (choix == 0)
                {
                    Console.WriteLine("Tour du joueur " + joueur.joueur + "\n Quel pion voulez-vous déplacer ? (entrez une abscisse, puis une ordonnée)");
                    xOr = (int.Parse(Console.ReadLine()));
                    yOr = (int.Parse(Console.ReadLine()));

                    Pion TestPion = plateau[xOr, yOr];

                    if (TestPion == null || TestPion.joueur == PionNoir.joueur)
                    {
                        Console.WriteLine("Tour du joueur " + joueur.joueur + "Vous n'avez pas de pion ici :c.");
                    }
                    else
                    {
                        choix = 1;
                    }
                }
            }
            else
            {
                while (choix == 0)
                {
                    Console.WriteLine("Tour du joueur " + joueur.joueur + "\n Quel pion voulez-vous déplacer ? (entrez une abscisse, puis une ordonnée)");
                    xOr = (int.Parse(Console.ReadLine()));
                    yOr = (int.Parse(Console.ReadLine()));

                    Pion TestPion = plateau[xOr, yOr];

                    if (TestPion == null || TestPion.joueur == PionBlanc.joueur)
                    {
                        Console.WriteLine("Vous n'avez pas de pion ici :c.");
                    }
                    else
                    {
                        choix = 1;
                    }
                }
            }
            Manger(xOr, yOr, JoueurEnQuestion, 0);
        } // Prend en compte les diff joueurs et s'adapte pour ne pas prendre de pion adverse ou de null

        
        public void Manger(int xOr, int yOr, Joueur joueur, int JaiMange) // Test si pion en question "est obliger de manger" puis propose les diff choix de manger et enfin mange le choix de l'utilisateur, possibilité de boucler de manger si c'est possible de REmanger
        {

            #region Variables
            Joueur JoueurEnQuestion = joueur;

            //varibles prenants la valeur des cases voisines diagonales (case du pion qui va être mangé)
            int xMangeHautGauche = 0;
            int yMangeHautGauche = 0;
            int xMangeHautDroite = 0;
            int yMangeHautDroite = 0;
            int xMangeBasGauche = 0;
            int yMangeBasGauche = 0;
            int xMangeBasDroite = 0;
            int yMangeBasDroite = 0;

            //varibles prenants la valeur des cases voisines+1 diagonales (case ou va arriver pion mangeur)
            int xAvanceHautGauche = 0;
            int yAvanceHautGauche = 0;
            int xAvanceHautDroite = 0;
            int yAvanceHautDroite = 0;
            int xAvanceBasGauche = 0;
            int yAvanceBasGauche = 0;
            int xAvanceBasDroite = 0;
            int yAvanceBasDroite = 0;

            //variables prévus pour re manger
            int xReMange = 0;
            int yReMange = 0;
            

            if (joueur.joueur == 1)
            {
                JoueurEnQuestion = new Joueur(true);
                //varibles prenants la valeur des cases voisines diagonales (case du pion qui va être mangé)
                 xMangeHautGauche = xOr - 1;
                 yMangeHautGauche = yOr - 1;
                 xMangeHautDroite = xOr + 1;
                 yMangeHautDroite = yOr - 1;
                 xMangeBasGauche = xOr - 1;
                 yMangeBasGauche = yOr + 1;
                 xMangeBasDroite = xOr + 1;
                 yMangeBasDroite = yOr + 1;

                //varibles prenants la valeur des cases voisines+1 diagonales (case ou va arriver pion mangeur)
                 xAvanceHautGauche = xOr - 2;
                 yAvanceHautGauche = yOr - 2;
                 xAvanceHautDroite = xOr + 2;
                 yAvanceHautDroite = yOr - 2;
                 xAvanceBasGauche = xOr - 2;
                 yAvanceBasGauche = yOr + 2;
                 xAvanceBasDroite = xOr + 2;
                 yAvanceBasDroite = yOr + 2;
            }
            
            else
            {
                JoueurEnQuestion = new Joueur(false);
                //varibles prenants la valeur des cases voisines diagonales (case du pion qui va être mangé)
                 xMangeHautGauche = xOr + 1;
                 yMangeHautGauche = yOr + 1;
                 xMangeHautDroite = xOr - 1;
                 yMangeHautDroite = yOr + 1;
                 xMangeBasGauche = xOr + 1;
                 yMangeBasGauche = yOr - 1;
                 xMangeBasDroite = xOr - 1;
                 yMangeBasDroite = yOr - 1;

                //varibles prenants la valeur des cases voisines+1 diagonales (case ou va arriver pion mangeur)
                 xAvanceHautGauche = xOr + 2;
                 yAvanceHautGauche = yOr + 2;
                 xAvanceHautDroite = xOr - 2;
                 yAvanceHautDroite = yOr + 2;
                 xAvanceBasGauche = xOr + 2;
                 yAvanceBasGauche = yOr - 2;
                 xAvanceBasDroite = xOr - 2;
                 yAvanceBasDroite = yOr - 2;
            }
                
            bool ObligerManger = false;
            bool option1 = false, option2 = false, option3 = false, option4 = false;
            int choix = 0;

            bool AManger = false;
            #endregion

            #region Obliger de Manger ??
            if(JoueurEnQuestion.joueur == 1)
            {
                if (0 <= xMangeHautGauche && xMangeHautGauche < 8 && 0 <= yMangeHautGauche && yMangeHautGauche < 8)
                {
                    if (plateau[xMangeHautGauche, yMangeHautGauche] == null) { }
                    else
                    {
                        if (plateau[xMangeHautGauche, yMangeHautGauche].joueur == PionNoir.joueur && 0 <= xAvanceHautGauche && xAvanceHautGauche < 8 && 0 <= yAvanceHautGauche && yAvanceHautGauche < 8 && plateau[xAvanceHautGauche, yAvanceHautGauche] == null)
                        {
                            ObligerManger = true;
                            option1 = true;
                        }
                    }
                }

                if (0 <= xMangeHautDroite && xMangeHautDroite < 8 && 0 <= yMangeHautDroite && yMangeHautDroite < 8)
                {
                    if (plateau[xMangeHautDroite, yMangeHautDroite] == null) { }
                    else
                    {
                        if (plateau[xMangeHautDroite, yMangeHautDroite].joueur == PionNoir.joueur && 0 <= xAvanceHautDroite && xAvanceHautDroite < 8 && 0 <= yAvanceHautDroite && yAvanceHautDroite < 8 && plateau[xAvanceHautDroite, yAvanceHautDroite] == null)
                        {
                            ObligerManger = true;
                            option2 = true;
                        }
                    }
                }

                if (0 <= xMangeBasGauche && xMangeBasGauche < 8 && 0 <= yMangeBasGauche && yMangeBasGauche < 8)
                {
                    if (plateau[xMangeBasGauche, yMangeBasGauche] == null) { }
                    else
                    {
                        if (plateau[xMangeBasGauche, yMangeBasGauche].joueur == PionNoir.joueur && 0 <= xAvanceBasGauche && xAvanceBasGauche < 8 && 0 <= yAvanceBasGauche && yAvanceBasGauche < 8 && plateau[xAvanceBasGauche, yAvanceBasGauche] == null)
                        {
                            ObligerManger = true;
                            option3 = true;
                        }
                    }
                }

                if (0 <= xMangeBasDroite && xMangeBasDroite < 8 && 0 <= yMangeBasDroite && yMangeBasDroite < 8)
                {
                    if (plateau[xMangeBasDroite, yMangeBasDroite] == null) { }
                    else
                    {
                        if (plateau[xMangeBasDroite, yMangeBasDroite].joueur == PionNoir.joueur && 0 <= xAvanceBasDroite && xAvanceBasDroite < 8 && 0 <= yAvanceBasDroite && yAvanceBasDroite < 8 && plateau[xAvanceBasDroite, yAvanceBasDroite] == null)
                        {
                            ObligerManger = true;
                            option4 = true;
                        }
                    }
                }
            }
            else
            {
                if (0 <= xMangeHautGauche && xMangeHautGauche < 8 && 0 <= yMangeHautGauche && yMangeHautGauche < 8)
                {
                    if (plateau[xMangeHautGauche, yMangeHautGauche] == null) { }
                    else
                    {
                        if (plateau[xMangeHautGauche, yMangeHautGauche].joueur == PionBlanc.joueur && 0 <= xAvanceHautGauche && xAvanceHautGauche < 8 && 0 <= yAvanceHautGauche && yAvanceHautGauche < 8 && plateau[xAvanceHautGauche, yAvanceHautGauche] == null)
                        {
                            ObligerManger = true;
                            option1 = true;
                        }
                    }
                }

                if (0 <= xMangeHautDroite && xMangeHautDroite < 8 && 0 <= yMangeHautDroite && yMangeHautDroite < 8)
                {
                    if (plateau[xMangeHautDroite, yMangeHautDroite] == null) { }
                    else
                    {
                        if (plateau[xMangeHautDroite, yMangeHautDroite].joueur == PionBlanc.joueur && 0 <= xAvanceHautDroite && xAvanceHautDroite < 8 && 0 <= yAvanceHautDroite && yAvanceHautDroite < 8 && plateau[xAvanceHautDroite, yAvanceHautDroite] == null)
                        {
                            ObligerManger = true;
                            option2 = true;
                        }
                    }
                }

                if (0 <= xMangeBasGauche && xMangeBasGauche < 8 && 0 <= yMangeBasGauche && yMangeBasGauche < 8)
                {
                    if (plateau[xMangeBasGauche, yMangeBasGauche] == null) { }
                    else
                    {
                        if (plateau[xMangeBasGauche, yMangeBasGauche].joueur == PionBlanc.joueur && 0 <= xAvanceBasGauche && xAvanceBasGauche < 8 && 0 <= yAvanceBasGauche && yAvanceBasGauche < 8 && plateau[xAvanceBasGauche, yAvanceBasGauche] == null)
                        {
                            ObligerManger = true;
                            option3 = true;
                        }
                    }
                }

                if (0 <= xMangeBasDroite && xMangeBasDroite < 8 && 0 <= yMangeBasDroite && yMangeBasDroite < 8)
                {
                    if (plateau[xMangeBasDroite, yMangeBasDroite] == null) { }
                    else
                    {
                        if (plateau[xMangeBasDroite, yMangeBasDroite].joueur == PionBlanc.joueur && 0 <= xAvanceBasDroite && xAvanceBasDroite < 8 && 0 <= yAvanceBasDroite && yAvanceBasDroite < 8 && plateau[xAvanceBasDroite, yAvanceBasDroite] == null)
                        {
                            ObligerManger = true;
                            option4 = true;
                        }
                    }
                }
            }

            #endregion

            while (ObligerManger == true)
            {
                #region Options de Manger possible
                Console.WriteLine("Vous devez manger :");
                if (option1 == true)
                {
                    Console.WriteLine("Rentrez 0 pour manger le pion en " + xMangeHautGauche + " " + yMangeHautGauche);
                }
                if (option2 == true)
                {
                    Console.WriteLine("Rentrez 1 pour manger le pion en " + xMangeHautDroite + " " + yMangeHautDroite);
                }
                if (option3 == true)
                {
                    Console.WriteLine("Rentrez 2 pour manger le pion en " + xMangeBasGauche + " " + yMangeBasGauche);
                }
                if (option4 == true)
                {
                    Console.WriteLine("Rentrez 3 pour manger le pion en " + xMangeBasDroite + " " + yMangeBasDroite);
                }
                

                int CaseChoisie = (int.Parse(Console.ReadLine()));
                #endregion

                #region ActionManger
                if (JoueurEnQuestion.joueur == 1)
                {
                    if (0 <= xMangeHautGauche && xMangeHautGauche < 8 && 0 <= yMangeHautGauche && yMangeHautGauche < 8 && CaseChoisie == 0)
                    {
                        if (plateau[xMangeHautGauche, yMangeHautGauche] == null) { }
                        else
                        {
                            if (plateau[xMangeHautGauche, yMangeHautGauche].joueur == PionNoir.joueur && 0 <= xAvanceHautGauche && xAvanceHautGauche < 8 && 0 <= yAvanceHautGauche && yAvanceHautGauche < 8 && plateau[xAvanceHautGauche, yAvanceHautGauche] == null)
                            {
                                plateau[xAvanceHautGauche, yAvanceHautGauche] = plateau[xOr, yOr];
                                plateau[xOr, yOr] = null;
                                plateau[xMangeHautGauche, yMangeHautGauche] = null;
                                ObligerManger = false;
                                AManger = true;
                                xReMange = xAvanceHautGauche;
                                yReMange = yAvanceHautGauche;
                            }
                        }
                    }

                    if (0 <= xMangeHautDroite && xMangeHautDroite < 8 && 0 <= yMangeHautDroite && yMangeHautDroite < 8 && CaseChoisie == 1)
                    {
                        if (plateau[xMangeHautDroite, yMangeHautDroite] == null) { }
                        else
                        {
                            if (plateau[xMangeHautDroite, yMangeHautDroite].joueur == PionNoir.joueur && 0 <= xAvanceHautDroite && xAvanceHautDroite < 8 && 0 <= yAvanceHautDroite && yAvanceHautDroite < 8 && plateau[xAvanceHautDroite, yAvanceHautDroite] == null)
                            {
                                plateau[xAvanceHautDroite, yAvanceHautDroite] = plateau[xOr, yOr];
                                plateau[xOr, yOr] = null;
                                plateau[xMangeHautDroite, yMangeHautDroite] = null;
                                ObligerManger = false;
                                AManger = true;
                                xReMange = xAvanceHautDroite;
                                yReMange = yAvanceHautDroite;
                            }
                        }
                    }

                    if (0 <= xMangeBasGauche && xMangeBasGauche < 8 && 0 <= yMangeBasGauche && yMangeBasGauche < 8 && CaseChoisie == 2)
                    {
                        if (plateau[xMangeBasGauche, yMangeBasGauche] == null) { }
                        else
                        {
                            if (plateau[xMangeBasGauche, yMangeBasGauche].joueur == PionNoir.joueur && 0 <= xAvanceBasGauche && xAvanceBasGauche < 8 && 0 <= yAvanceBasGauche && yAvanceBasGauche < 8 && plateau[xAvanceBasGauche, yAvanceBasGauche] == null)
                            {
                                plateau[xAvanceBasGauche, yAvanceBasGauche] = plateau[xOr, yOr];
                                plateau[xOr, yOr] = null;
                                plateau[xMangeBasGauche, yMangeBasGauche] = null;
                                ObligerManger = false;
                                AManger = true;
                                xReMange = xAvanceBasGauche;
                                yReMange = yAvanceBasGauche;
                            }
                        }
                    }

                    if (0 <= xMangeBasDroite && xMangeBasDroite < 8 && 0 <= yMangeBasDroite && yMangeBasDroite < 8 && CaseChoisie == 3)
                    {
                        if (plateau[xMangeBasDroite, yMangeBasDroite] == null) { }
                        else
                        {
                            if (plateau[xMangeBasDroite, yMangeBasDroite].joueur == PionNoir.joueur && 0 <= xAvanceBasDroite && xAvanceBasDroite < 8 && 0 <= yAvanceBasDroite && yAvanceBasDroite < 8 && plateau[xAvanceBasDroite, yAvanceBasDroite] == null)
                            {
                                plateau[xAvanceBasDroite, yAvanceBasDroite] = plateau[xOr, yOr];
                                plateau[xOr, yOr] = null;
                                plateau[xMangeBasDroite, yMangeBasDroite] = null;
                                ObligerManger = false;
                                AManger = true;
                                xReMange = xAvanceBasDroite;
                                yReMange = yAvanceBasDroite;
                            }
                        }
                    }
                }
                else
                {
                    if (0 <= xMangeHautGauche && xMangeHautGauche < 8 && 0 <= yMangeHautGauche && yMangeHautGauche < 8 && CaseChoisie == 0)
                    {
                        if (plateau[xMangeHautGauche, yMangeHautGauche] == null) { }
                        else
                        {
                            if (plateau[xMangeHautGauche, yMangeHautGauche].joueur == PionBlanc.joueur && 0 <= xAvanceHautGauche && xAvanceHautGauche < 8 && 0 <= yAvanceHautGauche && yAvanceHautGauche < 8 && plateau[xAvanceHautGauche, yAvanceHautGauche] == null)
                            {
                                plateau[xAvanceHautGauche, yAvanceHautGauche] = plateau[xOr, yOr];
                                plateau[xOr, yOr] = null;
                                plateau[xMangeHautGauche, yMangeHautGauche] = null;
                                ObligerManger = false;
                                AManger = true;
                                xReMange = xAvanceHautGauche;
                                yReMange = yAvanceHautGauche;
                            }
                        }
                    }

                    if (0 <= xMangeHautDroite && xMangeHautDroite < 8 && 0 <= yMangeHautDroite && yMangeHautDroite < 8 && CaseChoisie == 1)
                    {
                        if (plateau[xMangeHautDroite, yMangeHautDroite] == null) { }
                        else
                        {
                            if (plateau[xMangeHautDroite, yMangeHautDroite].joueur == PionBlanc.joueur && 0 <= xAvanceHautDroite && xAvanceHautDroite < 8 && 0 <= yAvanceHautDroite && yAvanceHautDroite < 8 && plateau[xAvanceHautDroite, yAvanceHautDroite] == null)
                            {
                                plateau[xAvanceHautDroite, yAvanceHautDroite] = plateau[xOr, yOr];
                                plateau[xOr, yOr] = null;
                                plateau[xMangeHautDroite, yMangeHautDroite] = null;
                                ObligerManger = false;
                                AManger = true;
                                xReMange = xAvanceHautDroite;
                                yReMange = yAvanceHautDroite;
                            }
                        }
                    }

                    if (0 <= xMangeBasGauche && xMangeBasGauche < 8 && 0 <= yMangeBasGauche && yMangeBasGauche < 8 && CaseChoisie == 2)
                    {
                        if (plateau[xMangeBasGauche, yMangeBasGauche] == null) { }
                        else
                        {
                            if (plateau[xMangeBasGauche, yMangeBasGauche].joueur == PionBlanc.joueur && 0 <= xAvanceBasGauche && xAvanceBasGauche < 8 && 0 <= yAvanceBasGauche && yAvanceBasGauche < 8 && plateau[xAvanceBasGauche, yAvanceBasGauche] == null)
                            {
                                plateau[xAvanceBasGauche, yAvanceBasGauche] = plateau[xOr, yOr];
                                plateau[xOr, yOr] = null;
                                plateau[xMangeBasGauche, yMangeBasGauche] = null;
                                ObligerManger = false;
                                AManger = true;
                                xReMange = xAvanceBasGauche;
                                yReMange = yAvanceBasGauche;
                            }
                        }
                    }

                    if (0 <= xMangeBasDroite && xMangeBasDroite < 8 && 0 <= yMangeBasDroite && yMangeBasDroite < 8 && CaseChoisie == 3)
                    {
                        if (plateau[xMangeBasDroite, yMangeBasDroite] == null) { }
                        else
                        {
                            if (plateau[xMangeBasDroite, yMangeBasDroite].joueur == PionBlanc.joueur && 0 <= xAvanceBasDroite && xAvanceBasDroite < 8 && 0 <= yAvanceBasDroite && yAvanceBasDroite < 8 && plateau[xAvanceBasDroite, yAvanceBasDroite] == null)
                            {
                                plateau[xAvanceBasDroite, yAvanceBasDroite] = plateau[xOr, yOr];
                                plateau[xOr, yOr] = null;
                                plateau[xMangeBasDroite, yMangeBasDroite] = null;
                                ObligerManger = false;
                                AManger = true;
                                xReMange = xAvanceBasDroite;
                                yReMange = yAvanceBasDroite;
                            }
                        }
                    }
                }
                #endregion
            }


            if (AManger == true)
            {
                Manger(xReMange, yReMange, JoueurEnQuestion, 1);
            }
            else
            {
                if(JaiMange == 0)
                    Deplacement(xOr, yOr, JoueurEnQuestion);
                else
                { }
            }
                
        }


        public void Deplacement(int xOr, int yOr, Joueur joueur)
        {

            Joueur JoueurEnQuestion = joueur;
            if (joueur.joueur == 1)
                JoueurEnQuestion = new Joueur(true);
            else
                JoueurEnQuestion = new Joueur(false);

            

            var PositionsPossibles = from p in P.VerifieDeplacement(xOr, yOr, plateau, JoueurEnQuestion) select new { p.xtest, p.ytest };
            foreach (var v in PositionsPossibles)
                Console.WriteLine("Position possible : " + v.xtest + " " + v.ytest + ". (D'après la liste de position)");




            if (JoueurEnQuestion.joueur == 1)
            {
                int xAvantGauche = xOr - 1;
                int yAvantGauche = yOr - 1;

                int xAvantDroite = xOr + 1;
                int yAvantDroite = yOr - 1;

                if (0 <= xAvantGauche && xAvantGauche < 8 && 0 <= yAvantGauche && yAvantGauche < 8 && plateau[xAvantGauche, yAvantGauche] == null || 0 <= xAvantDroite && xAvantDroite < 8 && 0 <= yAvantDroite && yAvantDroite < 8 && plateau[xAvantDroite, yAvantDroite] == null)
                {
                    if (0 <= xAvantGauche && xAvantGauche < 8 && 0 <= yAvantGauche && yAvantGauche < 8 && plateau[xAvantGauche, yAvantGauche] == null && 0 <= xAvantDroite && xAvantDroite < 8 && 0 <= yAvantDroite && yAvantDroite < 8 && plateau[xAvantDroite, yAvantDroite] == null)
                    {
                        int DeplacementNormal = (int.Parse(Console.ReadLine()));

                        if (DeplacementNormal == 0)
                        {
                            plateau[xAvantGauche, yAvantGauche] = plateau[xOr, yOr];
                            plateau[xOr, yOr] = null;
                        }
                        else
                        {
                            plateau[xAvantDroite, yAvantDroite] = plateau[xOr, yOr];
                            plateau[xOr, yOr] = null;
                        }
                    }
                    else
                    {
                        if (0 <= xAvantGauche && xAvantGauche < 8 && 0 <= yAvantGauche && yAvantGauche < 8 && plateau[xAvantGauche, yAvantGauche] == null)
                        {
                            plateau[xAvantGauche, yAvantGauche] = plateau[xOr, yOr];
                            plateau[xOr, yOr] = null;
                        }
                        else
                        {
                            plateau[xAvantDroite, yAvantDroite] = plateau[xOr, yOr];
                            plateau[xOr, yOr] = null;
                        }
                    }
                }
                else
                {
                    Console.Write("Vous ne pouvez pas déplacer ce pion, choisissez un autre pion. \n");
                    SelectPion(JoueurEnQuestion);
                }
            }
            else
            {
                {
                    int xAvantGauche = xOr + 1;
                    int yAvantGauche = yOr + 1;

                    int xAvantDroite = xOr - 1;
                    int yAvantDroite = yOr + 1;

                    if (0 <= xAvantGauche && xAvantGauche < 8 && 0 <= yAvantGauche && yAvantGauche < 8 && plateau[xAvantGauche, yAvantGauche] == null || 0 <= xAvantDroite && xAvantDroite < 8 && 0 <= yAvantDroite && yAvantDroite < 8 && plateau[xAvantDroite, yAvantDroite] == null)
                    {
                        if (0 <= xAvantGauche && xAvantGauche < 8 && 0 <= yAvantGauche && yAvantGauche < 8 && plateau[xAvantGauche, yAvantGauche] == null && 0 <= xAvantDroite && xAvantDroite < 8 && 0 <= yAvantDroite && yAvantDroite < 8 && plateau[xAvantDroite, yAvantDroite] == null)
                        {

                            Console.WriteLine("Vous pouvez déplacer vote pion : \nA la position : " + xAvantGauche + " " + yAvantGauche + ", en rentrant 0\nA la position : " + xAvantDroite + " " + yAvantDroite + ", en rentrant 1");

                            int DeplacementNormal = (int.Parse(Console.ReadLine()));

                            if (DeplacementNormal == 0)
                            {
                                plateau[xAvantGauche, yAvantGauche] = plateau[xOr, yOr];
                                plateau[xOr, yOr] = null;
                            }
                            else
                            {
                                plateau[xAvantDroite, yAvantDroite] = plateau[xOr, yOr];
                                plateau[xOr, yOr] = null;
                            }
                        }
                        else
                        {
                            if (0 <= xAvantGauche && xAvantGauche < 8 && 0 <= yAvantGauche && yAvantGauche < 8 && plateau[xAvantGauche, yAvantGauche] == null)
                            {
                                plateau[xAvantGauche, yAvantGauche] = plateau[xOr, yOr];
                                plateau[xOr, yOr] = null;
                            }
                            else
                            {
                                plateau[xAvantDroite, yAvantDroite] = plateau[xOr, yOr];
                                plateau[xOr, yOr] = null;
                            }
                        }

                    }
                    else
                    {
                        Console.Write("Vous ne pouvez pas déplacer ce pion, choisissez un autre pion. \n");
                        SelectPion(JoueurEnQuestion);
                    }
                }
            }
        } // Si Manger() n'a pas eu lieux, alors Avance() rentre en jeux !! Dans cette fonction du boulot restait à faire, la fct de Pion "VerifieDeplacement" retourne bien un liste de case atteignable via le constructeur de la classe Pion 
        //Mais c'est seulement pour afficher les cases possibles (pour le moment)


        public void PionDevientDame()
        {
            Console.Write("\nChoisissez un pion qui deviendra une dame ! (Rentrez une abscisse puis une ordonnée)\n");
            int xOr, yOr;
            xOr = (int.Parse(Console.ReadLine()));
            yOr = (int.Parse(Console.ReadLine()));

            plateau[xOr, yOr] = new Dame(true);
            Console.WriteLine("Votre pion a bien été transformé !");

        } // A TRAVAILLER
        

        public void ListerPion()
        {

            nbPionBlanc = 0;
            nbPionNoir = 0;
            for (int y = 0; y < ymax; y++)
            {
                for (int x = 0; x < xmax; x++)
                {
                    if (plateau[x, y] == null)
                    { }
                    else
                    {
                        if (plateau[x, y].joueur == PionBlanc.joueur)
                        {
                            nbPionBlanc++;
                        }
                        else
                        {
                            nbPionNoir++;
                        }
                    }
                }
            }
            Console.WriteLine("Il y a " + nbPionBlanc + " pions blancs en jeu et " + nbPionNoir + " pions noirs.\n");
            if (nbPionBlanc == 0)
            {
                Console.WriteLine("Le joueur 2 à gagné ! Félicitation\n");
            }
            if (nbPionNoir == 0)
            {
                Console.WriteLine("Le joueur 1 à gagné ! Félicitation\n");
            }

        } // Regarde qui a cb de pion et détermine la fin de la parti si par exemple plus de pion chez joueur2


        public void Game() // "Main" si l'on peut dire, propose au joueur de stoper la partie a chaque tours, lance toute les fonctions
        {
            int FinDuGame = 1;

            jeux.Menu();
            CreatePlateau();
            RemplirTableau();
            LirePlateau();

            while (FinDuGame != 0)
            {
                SelectPion(joueur1);
                LirePlateau();

                //PionDevientDame();
                
                SelectPion(joueur2);
                LirePlateau();

                Console.WriteLine("Fin du game ?\n 0 - Oui\n 1 - Non");
                FinDuGame = int.Parse(Console.ReadLine());
            }
        }
        #endregion

    }
}
