using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_TP1
{
    public class Rules
    {
		public static readonly int width = 10;
		public static readonly int height = 10;
		public static readonly float poussiereFrequency = 0.1f;
		public static readonly float bijouxFrequency = 0.1f;

		public static int gainRamasser(int objet)
        {
            if (objet == 1)
                return -5;
            else if (objet == 2)
                return +10;
            else if (objet == 3)
                return 5;
            return 0;
        }
        public static int gainAspirer(int objet)
        {
            if (objet == 1)
                return +10;
            else if (objet == 2)
                return -50;
            else if (objet == 3)
                return -40;
            return 0;
        }

        /** Objects on map :
        [0] - nothing
        [1] - poussière
        [2] - bijoux
        [3] - poussière et bijoux */
    }

}

