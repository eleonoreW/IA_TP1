using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_TP1
{
	class NodeAStar : Node
	{
		public NodeAStar(Node p, int[,] m, int i, int j, Action a) : base(p, m, i, j, a)
		{

		}

		public static List<Node> AStarSearch(Node n)
		{
			return null;
		}
	}
}
