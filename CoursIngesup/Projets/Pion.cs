using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Projets
{
    class Pion
    {
        public bool Blanc;
        public char joueur;

        List<Position> positions = new List<Position>();

        public Pion(bool blanc)
        {
            Blanc = blanc;

            if (Blanc)
                joueur = 'b';
            else
                joueur = 'r';
        }


        public List<Position> VerifieDeplacement(int xOr, int yOr, Pion[,] plateau, Joueur joueur)
        {
            Joueur JoueurEnQuestion = joueur;


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
                        Console.WriteLine("Vous pouvez déplacer vote pion : \nA la position : " + xAvantGauche + " " + yAvantGauche + ", en rentrant 0\nA la position : " + xAvantDroite + " " + yAvantDroite + ", en rentrant 1");
                        positions.Add(new Position(xAvantGauche, yAvantGauche));
                        positions.Add(new Position(xAvantDroite, yAvantDroite));

                    }
                    else
                    {
                        if (0 <= xAvantGauche && xAvantGauche < 8 && 0 <= yAvantGauche && yAvantGauche < 8 && plateau[xAvantGauche, yAvantGauche] == null)
                        {
                            positions.Add(new Position(xAvantGauche, yAvantGauche));
                            Console.WriteLine("Case(s) dispo : " + xAvantGauche + " " + yAvantGauche);
                        }
                        else
                        {
                            positions.Add(new Position(xAvantDroite, yAvantDroite));
                            Console.WriteLine("Case(s) dispo : " + xAvantGauche + " " + yAvantGauche);
                        }
                    }
                }
                else
                {
                    Console.Write("Vous ne pouvez pas déplacer ce pion, choisissez un autre pion. \n");
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
                            positions.Add(new Position(xAvantGauche, yAvantGauche));
                            positions.Add(new Position(xAvantDroite, yAvantDroite));

                        }
                        else
                        {
                            if (0 <= xAvantGauche && xAvantGauche < 8 && 0 <= yAvantGauche && yAvantGauche < 8 && plateau[xAvantGauche, yAvantGauche] == null)
                            {
                                positions.Add(new Position(xAvantGauche, yAvantGauche));
                            }
                            else
                            {
                                positions.Add(new Position(xAvantDroite, yAvantDroite));
                            }
                        }
                    }
                    else
                    {
                        Console.Write("Vous ne pouvez pas déplacer ce pion, choisissez un autre pion. \n");
                    }
                }
            }
            return positions;
        } 
        //Je n'ai pas eu le temps de terminer cette fonction, j'ai eu un accident le soir même
        //Actuellement elle retourne une liste de valeure possibles qui s'affichent
        //Le reste semble simple a réaliser afin que cette fonction est un réel impact sur le jeu


        public void VerifieManger()//Meme principe qu'au dessus, reprend la vérif actuellement dans plateau pour savoir quelles cases sont mangeables
        {
            
        }
    }
}
