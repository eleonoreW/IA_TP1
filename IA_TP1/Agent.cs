using System;
using System.Collections;

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
        private Queue intentions;
        
        public Agent()
        {
            perf = 0;
            isAlive = true;
            initcroyance();
            setPosition(0,0);
        }

        public void setPosition(int i, int j) {
            posI = i;
            posJ = j;
        }

        public void initcroyance() {
            croyance = new int[10, 10];
			for (int i = 0; i< 10; i++)
			{
				for (int j = 0; j< 10; j++)
				{
					croyance[i, j] = 0;
				}
}
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
           /* functionAgent - But([etat_env, but])
                ActionsPossibles = actionDeclanchable(etat_env)
                for i = 1 to taille(ActionsPossibles){
                                if capable_atteindre(ActionsPossibles[i], but)
                                return ActionsPossibles[i];
            }
            returnsan action*/
        }

        private void act()
        {
            
        }

        

       
    }

}
