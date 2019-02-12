namespace IA_TP1
{
	public class Rules
	{
		public static readonly int width = 10;
		public static readonly int height = 10;
		public static readonly float poussiereFrequency = 0.1f;
		public static readonly float bijouxFrequency = 0.1f;
		public static readonly int maxSearchDepth = 7;

		public static int GainRamasser(int objet)
		{
			if (objet == 1) {
				return -5;
			} else if (objet == 2) {
				return +10;
			} else if (objet == 3) {
				return 5;
			}

			return 0;
		}

		public static int GainAspirer(int objet)
		{
			if (objet == 1) {
				return +10;
			} else if (objet == 2) {
				return -50;
			} else if (objet == 3) {
				return -40;
			}

			return 0;
		}

		/** Grille / Manoir :
        [0] - vide
        [1] - poussière
        [2] - bijoux
        [3] - poussière et bijoux */
	}

}

