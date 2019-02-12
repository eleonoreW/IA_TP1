﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace IA_TP1
{
	class Agent
	{
		public bool alive; // Contrôle de l'execution du thread

		public static int perf; // Performance de l'agent
		private int desir; // Gagner des points : faire une action rentable
		public static int posI;
		public static int posJ;
		public static int[,] croyance; // L'environnement qu'il peut observer
		private Queue<Action> intentions; // Listes d'actions que l'agent va effectuer
		private Capteur capteur;
		private Effecteur effecteur;
		private bool informe; // Utilise l'algorithme de recherche informe ?

		public Agent(bool informe_)
		{
			alive = true;

			// Initialisation
			perf = 0;
			desir = 0;
			intentions = new Queue<Action>();
			effecteur = new Effecteur();
			capteur = new Capteur();

			// On positionne l'agent au centre du manoir
			posI = 4;
			posJ = 4;

			informe = informe_;
		}

		public void Run()
		{
			while (alive) {
				ObserverEnvironnement();
				ChooseAction();
				if (intentions.Count > 0) {
					Act();
				}
			}
		}

		private void RemoveObjectsOnActualPosition()
		{
			croyance[posI, posJ] = 0;
		}


		private void ObserverEnvironnement()
		{
			croyance = capteur.CapterEnvironement();
			perf = capteur.CapterPerformance();
		}

		private void ChooseAction()
		{
			if (IsEnvironnementEmpty()) {
				intentions.Enqueue(Action.ATTENDRE);
			} else {
				Node n;
				if (informe) // Exploration informee
{
					n = new NodeAStar(null, croyance, posI, posJ, Action.ATTENDRE);
				} else // Exploration non informee
  {
					n = new NodeUCS(null, croyance, posI, posJ, Action.ATTENDRE);
				}

				// On recupere la meilleure liste d'action et on la definit comme nos intensions
				List<Action> actions = Exploration(n);
				if (actions != null) {
					for (int i = actions.Count - 1; i >= 0; i--) {
						intentions.Enqueue(actions[i]);
					}
				}
			}
		}

		private void Act()
		{
			while (intentions.Count > 0) {
				Action currentAction = intentions.Dequeue();
				effecteur.faire(currentAction, posI, posJ);
			}
		}


		private List<Action> Exploration(Node root)
		{
			List<Node> visited = new List<Node>();
			List<Node> frontiere = new List<Node> { root };

			while (true) {
				if (frontiere.Count == 0) {
					return null;
				}

				Node n = frontiere[0];
				frontiere.RemoveAt(0);
				// On ne reexplore pas les noeuds deja visites
				while (visited.Contains(n)) {
					n = frontiere[0];
					frontiere.RemoveAt(0);
				}

				visited.Add(n);


				// Si n est solution
				if (n.cost < desir) {
					// On recupere la liste d'action en remontant la branche de l'arbre de decision
					List<Action> actions = new List<Action>();
					Node current = n;
					while (current != null) {
						actions.Add(current.action);
						current = current.parent;
					}
					return actions;
				}

				// Expansion
				if (n.depth < Rules.maxSearchDepth) {
					if (informe) {
						// Exploration AStar
						frontiere.AddRange(NodeAStar.AStarSearch(n));
						// Tri des noeuds par cout croissant
						frontiere.Sort((x, y) => x.Eval().CompareTo(y.Eval()));
					} else {
						// Exploration Uniform Cost Search (UCS)
						frontiere.AddRange(NodeUCS.UCSearch(n));
						// Tri des noeuds par cout croissant
						frontiere.Sort((x, y) => x.Eval().CompareTo(y.Eval()));
					}
				} else {
					return null;
				}
			}
		}


		private bool IsEnvironnementEmpty()
		{
			for (int i = 0; i < Rules.width; i = i + 1) {
				for (int j = 0; j < Rules.height; j = j + 1) {
					if (croyance[i, j] != 0) {
						return false;
					}
				}
			}

			return true;
		}

	}
}
