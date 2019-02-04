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
        private int desir; // gagner des points
        private Queue<Action> intentions; // listes d'actions que l'agent va effectuer
        
        public Agent()
        {
            perf = 0;
            isAlive = true;
            Capteur.capterEnvironement(this);
            setPosition(4,4);
        }

        public void setCroyance(int[,] env)
        {
            Capteur.capterEnvironement(this);
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
                observecroyanceironnement();
                updateState();
                chooseAction();
                act();
            }

        }

        private void observecroyanceironnement()
        {
            croyance = Environment.grid;
        }

        private void updateState()
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
            
        }

        

       
    }

}
