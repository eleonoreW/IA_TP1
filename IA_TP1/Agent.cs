using System;
using System.Collections.Generic;

namespace IA_TP1
{
    class Agent
    {
        private int perf;
        private bool isAlive;
        public static int posI;
        public static int posJ;
        private int[,] croyance; // L'environnement qu'il peut observer
        private int desir; // gagner des points : faire une action rentable (score > 0)
        private Queue<Action> intentions; // listes d'actions que l'agent va effectuer
        private Capteur capteur;
        private Effecteur effecteur;
        private bool informe;
        public Agent()
        {
            perf = 0;
            isAlive = true;
            setPosition(4, 4);
            effecteur = new Effecteur();
            capteur = new Capteur();
            croyance = capteur.capterEnvironement();
            informe = false;
        }

        public void setPosition(int i, int j)
        {
            posI = i;
            posJ = j;
        }

        private void ramasser(int objet)
        {
            perf += Rules.gainRamasser(objet);
            removeObjectsOnActualPosition();

        }

        private void removeObjectsOnActualPosition()
        {
            croyance[posI, posJ] = 0;
        }

        private void aspirer(int objet)
        {
            perf += Rules.gainAspirer(objet);
            removeObjectsOnActualPosition();
        }

        public void cycle()
        {
            while (isAlive)
            {
                observerEnvironnement();
                updateState();
                if (intentions.Count > 0)
                {
                    chooseAction();
                }
                act();
            }

        }


        private void observerEnvironnement()
        {
            croyance = capteur.capterEnvironement();
        }


        private void updateState() // 2 scores différents, un pour l'aspi, un pour le manoir
        {

        }

        private void chooseAction()
        {
            if (isEnvironnementEmpty())
            {
                intentions.Enqueue(Action.ATTENDRE);
            }
            else if (informe)
            {//Exploration informée

            }
            else
            {//Exploration non informée

            }
            /* function AgentBut([etat_env, but])
                 ActionsPossibles = actionDeclanchable(etat_env)
                 for i = 1 to taille(ActionsPossibles){
                                 if capable_atteindre(ActionsPossibles[i], but)
                                 return ActionsPossibles[i];
             }
             returnsan action*/
        }

        private void act()
        {
            Action currentAction = intentions.Dequeue();
            switch (currentAction)
            {
                case Action.HAUT:
                    perf--;
                    if (posJ > 0)
                        posJ--;
                    break;
                case Action.BAS:
                    perf--;
                    if (posJ < Rules.height - 1)
                        posJ++;
                    break;
                case Action.GAUCHE:
                    perf--;
                    if (posI > 0)
                        posI--;
                    break;
                case Action.DROITE:
                    perf--;
                    if (posI < Rules.width - 1)
                        posI++;
                    break;
                case Action.ASPIRER:
                    perf += effecteur.faire(currentAction, posI, posJ) - 1;
                    croyance[posI, posJ] = 0;
                    break;
                case Action.RAMASSER:
                    perf += effecteur.faire(currentAction, posI, posJ) - 1;
                    croyance[posI, posJ] = 0;
                    break;
                case Action.ATTENDRE:
                default:
                    break;
            }



        }

        private Boolean isEnvironnementEmpty()
        {
            for (int i = 0; i < Rules.width; i = i + 1)
            {
                for (int j = 0; j < Rules.height; j = j + 1)
                {
                    if (croyance[i, j] != 0)
                        return false;
                }
            }
            return true;
        }



    }

}
