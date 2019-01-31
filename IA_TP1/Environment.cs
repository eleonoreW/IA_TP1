using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace IA_TP1
{
	class Environment
	{
		public bool run;
		public int counterPoussiere = 0;
		public int counterBijoux = 0;

		private int[,] grid;

		public static List<string> actions;

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
			run = true;
			actions = new List<string>();
		}

		public void Generate()
		{
			Random r = new Random();
			while (run)
			{
				// Génération poussière
				if (r.NextDouble() < 0.1)
				{
					int randI = r.Next(0, 10);
					int randJ = r.Next(0, 10);
					if (grid[randI, randJ] == 0 || grid[randI, randJ] == 2)
						grid[randI, randJ] += 1;

					counterPoussiere++;
					//PrintEnvironment();
				}

				// Génération bijoux
				if (r.NextDouble() < 0.1)
				{
					int randI = r.Next(0, 10);
					int randJ = r.Next(0, 10);
					if (grid[randI, randJ] == 0 || grid[randI, randJ] == 1)
						grid[randI, randJ] += 2;

					counterBijoux++;
					//PrintEnvironment();
				}


				lock (Program._lock)
				{
					for (int i = 0; i < actions.Count; i++)
					{
						Console.Write(actions[i] + " ");
					}
					Console.WriteLine();
				}


				Thread.Sleep(100);
			}
		}

		public void PrintEnvironment()
		{
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					Console.Write(grid[i, j] + " ");
				}
				Console.WriteLine();
			}
			Console.WriteLine("\n");
		}
	}
}
