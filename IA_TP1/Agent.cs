using System;
using System.Collections.Generic;

namespace IA_TP1
{
    class Agent
    {
        private int perf;
        private Boolean isAlive;
        static int posI;
        static int posJ;
        private int[,] croyance; // L'environnement qu'il peut observer
        private int desir; // gagner des points : faire une action rentable (score > 0)
        private Queue<Action> intentions; // listes d'actions que l'agent va effectuer
        private Capteur capteur;
        private Effecteur effecteur;
        public Agent()
        {
            perf = 0;
            isAlive = true;
            setPosition(4,4);
            effecteur = new Effecteur();
            capteur = new Capteur();
            croyance = capteur.capterEnvironement();
        }
        
        public void setPosition(int i, int j) {
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

        public void cycle() {
            while (isAlive)
            {
                observerEnvironnement();
                updateState();
                chooseAction();
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
            if(currentAction != Action.ATTENDRE)
            {
                perf -= 1;
            }
            perf += effecteur.faire(currentAction, posI, posJ);
            
        }

        private Boolean isEnvironnementEmpty()
        {
            for(int i = 0; i < Rules.width; i = i + 1)
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
