using System;
using System.Collections.Generic;


namespace IA_TP1
{
	class NodeUCS : Node
	{
		public NodeUCS(Node p, int[,] m, int i, int j, Action a) : base(p, m, i, j, a) { }

		public static List<Node> UCSearch(Node n)
		{
			// Récupérer tous les neouds réalisables a partir de l'etat actuel
			List<Node> neighbors = new List<Node>();

			// Haut
			if (n.agentPosJ > 0)
			{
				Node newNode = new NodeUCS(n, n.map, n.agentPosI, n.agentPosJ - 1, Action.HAUT);
				neighbors.Add(newNode);
			}

			// Bas
			if (n.agentPosJ < Rules.height - 1)
			{
				Node newNode = new NodeUCS(n, n.map, n.agentPosI, n.agentPosJ + 1, Action.BAS);
				neighbors.Add(newNode);
			}

			// Gauche
			if (n.agentPosI > 0)
			{
				Node newNode = new NodeUCS(n, n.map, n.agentPosI - 1, n.agentPosJ, Action.GAUCHE);
				neighbors.Add(newNode);
			}

			// Droite
			if (n.agentPosI < Rules.width - 1)
			{
				Node newNode = new NodeUCS(n, n.map, n.agentPosI + 1, n.agentPosJ, Action.DROITE);
				neighbors.Add(newNode);
			}

			// Aspirer
			if (n.NodeWithPoussiere(n.agentPosI, n.agentPosJ))
			{
				Node newNode = new NodeUCS(n, n.map, n.agentPosI, n.agentPosJ, Action.ASPIRER);
				neighbors.Add(newNode);
			}

			// Ramasser
			if (n.NodeWithBijou(n.agentPosI, n.agentPosJ))
			{
				Node newNode = new NodeUCS(n, n.map, n.agentPosI, n.agentPosJ, Action.RAMASSER);
				neighbors.Add(newNode);
			}

			return neighbors;
		}

		override public int Eval()
		{
			return cost;
		}
	}
}
