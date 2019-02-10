using System;
using System.Threading;


namespace IA_TP1
{
	class Environment
	{
		/** Grille / Manoir :
		[0] - vide
		[1] - poussière
		[2] - bijoux
		[3] - poussière et bijoux */


		public bool alive; // Contrôle de l'execution du thread
		private readonly int frequency; // Taux de rafraichissement du thread (en ms)
		public static int[,] grid; // Pieces du manoir (10 x 10)

		public Environment(int freq)
		{
			// Initialisation de l'environnement vide
			grid = new int[Rules.width, Rules.height];
			for (int i = 0; i < Rules.width; i++)
				for (int j = 0; j < Rules.height; j++)
					grid[i, j] = 0;

			alive = true;
			frequency = freq;
		}


		public void Run()
		{
			Random r = new Random();
			while (alive)
			{
				// Génération de poussière et de bijoux
				GeneratePoussiere(r);
				GenerateBijoux(r);

				Thread.Sleep(frequency);
			}
		}


		private void GeneratePoussiere(Random r)
		{
			if (r.NextDouble() < Rules.poussiereFrequency)
			{
				int randI = r.Next(0, Rules.width);
				int randJ = r.Next(0, Rules.height);
				if (grid[randI, randJ] == 0 || grid[randI, randJ] == 2)
					grid[randI, randJ] += 1;
			}
		}

		private void GenerateBijoux(Random r)
		{
			if (r.NextDouble() < Rules.bijouxFrequency)
			{
				int randI = r.Next(0, Rules.width);
				int randJ = r.Next(0, Rules.height);
				if (grid[randI, randJ] == 0 || grid[randI, randJ] == 1)
					grid[randI, randJ] += 2;
			}
		}

		static public int ProcessAction(Action a, int posI, int posJ)
		{
			int agentScore = 0;

			// Agir sur l'environnement et donner un score selon l'action
			switch (a)
			{
				case Action.ASPIRER:
					agentScore += Rules.GainAspirer(grid[posI, posJ]);
					grid[posI, posJ] = 0;
					break;
				case Action.RAMASSER:
					agentScore += Rules.GainRamasser(grid[posI, posJ]);
					grid[posI, posJ] = 0;
					break;
				default:
					break;
			}

			return agentScore;
		}
	}
}
