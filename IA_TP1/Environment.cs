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

		private int[,] grid; // Pieces du manoir (10 x 10)

		public int agentPosI; // Position de l'agent dans la grille horizontalement
		public int agentPosJ; // Position de l'agent dans la grille verticalement
		public int agentScore; // Performance réelle de l'agent
		public static Queue<Action> agentActions; // Séquence d'actions de l'agent

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

			agentPosI = 4;
			agentPosJ = 4;
			agentScore = 0;
			agentActions = new Queue<Action>();
			agentActions.Enqueue(Action.DROITE);
		}

		public void Run()
		{
			Random r = new Random();
			while (alive)
			{
				// Génération de poussière et de bijoux
				GeneratePoussiere(r);
				GenerateBijoux(r);

				// ##### TEST ##### \\
				Array actions = Enum.GetValues(typeof(Action));
				Action randAction = (Action)actions.GetValue(r.Next(actions.Length));
				agentActions.Enqueue(randAction);
				// ################ \\

				// Traitement des actions de l'agent
				lock (Program._lock)
				{
					if (agentActions.Count > 0)
					{
						Action current = agentActions.Dequeue();
						Console.WriteLine(current);
						ProcessAction(current);
					}
				}

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

		private void ProcessAction(Action a)
		{
			switch (a)
			{
				case Action.HAUT:
					agentScore--;
					if (agentPosJ > 0)
						agentPosJ--;
					break;
				case Action.BAS:
					agentScore--;
					if (agentPosJ < 9)
						agentPosJ++;
					break;
				case Action.GAUCHE:
					agentScore--;
					if (agentPosI > 0)
						agentPosI--;
					break;
				case Action.DROITE:
					agentScore--;
					if (agentPosI < 9)
						agentPosI++;
					break;
				case Action.ASPIRER:
					agentScore--;
					agentScore += Rules.gainAspirer(grid[agentPosI, agentPosJ]);
					// MODIFIER L'ENVIRONNEMENT 
					break;
				case Action.RAMASSER:
					agentScore--;
					agentScore += Rules.gainRamasser(grid[agentPosI, agentPosJ]);
					// MODIFIER L'ENVIRONNEMENT 
					break;
				case Action.ATTENDRE:
					break;
			}
		}

		private void PrintEnvironment()
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
