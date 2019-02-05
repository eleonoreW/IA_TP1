using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace IA_TP1
{
	class Environment
	{
		public bool alive; // Contrôle de l'execution du thread

		static private int[,] grid; // Pieces du manoir (10 x 10)

		public static Queue<Action> agentActions; // Séquence d'actions de l'agent /*Il ne faudrait pas stocker*/

		public Environment()
		{
			grid = new int[10, 10];
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					grid[i, j] = 0;
				}
			}

			alive = true;

			agentActions = new Queue<Action>();
		}

		public static int[,] getGrid()
		{
			return grid;
		}

		public void Run()
		{
			Random r = new Random();
			while (alive)
			{
				// Génération de poussière et de bijoux
				GeneratePoussiere(r);
				GenerateBijoux(r);

				Thread.Sleep(100);
			}
		}


		private void GeneratePoussiere(Random r)
		{
			if (r.NextDouble() < 0.1)
			{
				int randI = r.Next(0, 10);
				int randJ = r.Next(0, 10);
				if (grid[randI, randJ] == 0 || grid[randI, randJ] == 2)
					grid[randI, randJ] += 1;

				//PrintEnvironment();
			}
		}

		private void GenerateBijoux(Random r)
		{
			if (r.NextDouble() < 0.1)
			{
				int randI = r.Next(0, 10);
				int randJ = r.Next(0, 10);
				if (grid[randI, randJ] == 0 || grid[randI, randJ] == 1)
					grid[randI, randJ] += 2;

				//PrintEnvironment();
			}
		}

		static public int ProcessAction(Action a, int posI, int posJ)
		{
			int agentScore = 0;
			switch (a)
			{
				case Action.ASPIRER:
					agentScore += Rules.gainAspirer(grid[posI, posJ]);
					grid[posI, posJ] = 0;
					break;
				case Action.RAMASSER:
					agentScore += Rules.gainRamasser(grid[posI, posJ]);
					grid[posI, posJ] = 0;
					break;
				default:
					break;
			}
			PrintEnvironment(posI, posJ);

			return agentScore;
		}

		private void PrintEnvironment(int agentPosI, int agentPosJ)
		{
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					if (i == agentPosI && j == agentPosJ)
						Console.Write("X ");
					else
						Console.Write(grid[i, j] + " ");
				}
				Console.WriteLine();
			}
			Console.WriteLine("\n");
		}
	}
}
