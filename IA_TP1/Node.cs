using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_TP1
{
	class Node
	{
		public Node parent;
		public int[,] map;
		public int agentPosI;
		public int agentPosJ;
		public Action action;
		public int cost;
		public int depth;

		public Node(Node parent_, int[,] map_, int agentPosI_, int agentPosJ_, Action action_)
		{
			parent = parent_;
			map = map_;
			agentPosI = agentPosI_;
			agentPosJ = agentPosJ_;
			action = action_;

			if (parent == null)
			{
				cost = 0;
				depth = 0;
			}
			else
			{
				depth = parent.depth + 1;
				cost = parent.cost - 1;
				if (action == Action.ASPIRER)
				{
					cost += Rules.gainAspirer(map[agentPosI, agentPosJ]);
					
					// On enlève la poussière et le bijou de la carte
					map[agentPosI, agentPosJ] = 0;
				}
				else if (action == Action.RAMASSER)
				{
					cost += Rules.gainRamasser(map[agentPosI, agentPosJ]);
					
					// On enlève la poussière et le bijou de la carte
					map[agentPosI, agentPosJ] = 0;
				}
			}
		}

		public bool NodeWithPoussiere()
		{
			return (map[agentPosI, agentPosJ] == 1 || map[agentPosI, agentPosJ] == 3);
		}

		public bool NodeWithBijou()
		{
			return (map[agentPosI, agentPosJ] == 2 || map[agentPosI, agentPosJ] == 3);
		}
	}
}
