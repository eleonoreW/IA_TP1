using System;
using System.Collections.Generic;

namespace IA_TP1
{
	class Agent
	{
		public bool alive; // Contrôle de l'execution du thread

		private int perf;
		private int desir; // gagner des points : faire une action rentable (score > 0)
		public static int posI;
		public static int posJ;
		private int[,] croyance; // L'environnement qu'il peut observer
		private Queue<Action> intentions; // listes d'actions que l'agent va effectuer
		private Capteur capteur;
		private Effecteur effecteur;
		private bool informe;

		public Agent()
		{
			alive = true;

			perf = 0;
			desir = 0;
			SetPosition(4, 4);
			intentions = new Queue<Action>();
			effecteur = new Effecteur();
			capteur = new Capteur();
			croyance = capteur.capterEnvironement();

			informe = true;
		}

		public void Run()
		{
			while (alive)
			{
				ObserverEnvironnement();
				ChooseAction();
				if (intentions.Count > 0)
					Act();
			}
		}

		public void SetPosition(int i, int j)
		{
			posI = i;
			posJ = j;
		}

		private void RemoveObjectsOnActualPosition()
		{
			croyance[posI, posJ] = 0;
		}


		private void ObserverEnvironnement()
		{
			croyance = capteur.capterEnvironement();
		}

		private void ChooseAction()
		{
			if (IsEnvironnementEmpty())
			{
				intentions.Enqueue(Action.ATTENDRE);
			}
			else
			{
				Node n;
				if (informe) // Exploration informee
					n = new NodeAStar(null, croyance, posI, posJ, Action.ATTENDRE);
				else // Exploration non informee
					n = new NodeUCS(null, croyance, posI, posJ, Action.ATTENDRE);

				List<Action> actions = Exploration(n);
				if (actions != null)
					for (int i = actions.Count - 1; i >= 0; i--)
						intentions.Enqueue(actions[i]);
			}
		}

		private void Act()
		{
			while (intentions.Count > 0)
			{
				Action currentAction = intentions.Dequeue();
				switch (currentAction)
				{
					case Action.HAUT:
						perf++;
						if (posJ > 0)
							posJ--;
						break;
					case Action.BAS:
						perf++;
						if (posJ < Rules.height - 1)
							posJ++;
						break;
					case Action.GAUCHE:
						perf++;
						if (posI > 0)
							posI--;
						break;
					case Action.DROITE:
						perf++;
						if (posI < Rules.width - 1)
							posI++;
						break;
					case Action.ASPIRER:
						perf++;
						perf -= effecteur.faire(currentAction, posI, posJ);
						RemoveObjectsOnActualPosition();
						break;
					case Action.RAMASSER:
						perf++;
						perf -= effecteur.faire(currentAction, posI, posJ);
						RemoveObjectsOnActualPosition();
						break;
					case Action.ATTENDRE:
					default:
						break;
				}
			}
		}


		private List<Action> Exploration(Node root)
		{
			List<Node> visited = new List<Node>();
			List<Node> frontiere = new List<Node> { root };

			while (true)
			{
				if (frontiere.Count == 0)
					return null;

				Node n = frontiere[0];
				frontiere.RemoveAt(0);
				while (visited.Contains(n))
				{
					n = frontiere[0];
					frontiere.RemoveAt(0);
				}

				visited.Add(n);


				// AFFICHAGE DEBUG
				//for (int j = 0; j < n.map.GetLength(1); j++)
				//{
				//	for (int i = 0; i < n.map.GetLength(0); i++)
				//	{
				//		if (n.agentPosI == i && n.agentPosJ == j)
				//			Console.Write("A ");
				//		else
				//			Console.Write(n.map[i, j] + " ");
				//	}
				//	Console.WriteLine();
				//}
				//Console.WriteLine();
				//NodeAStar nn = (NodeAStar)n;
				//Console.WriteLine(nn.depth + " : " + nn.action + " (" + nn.agentPosI + "," + nn.agentPosJ + ") => " + nn.cost + " + " + nn.costH + " = " + nn.Eval());
				//Console.WriteLine("\n");


				// Si n est solution
				if (n.cost < desir)
				{
					List<Action> actions = new List<Action>();
					Node node = n;
					while (node != null)
					{
						actions.Add(node.action);
						node = node.parent;
					}
					return actions;
				}

				// Expansion
				if (n.depth < 7)
					if (informe)
					{
						frontiere.AddRange(NodeAStar.AStarSearch(n));
						frontiere.Sort((x, y) => x.Eval().CompareTo(y.Eval()));
					}
					else
					{
						frontiere.AddRange(NodeUCS.UCSearch(n));
						frontiere.Sort((x, y) => x.Eval().CompareTo(y.Eval()));
					}
				else
					return null;
			}
		}


		private bool IsEnvironnementEmpty()
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
