using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace IA_TP1
{
	class Affichage
	{
		public bool alive;
		private int frequency;

		public Affichage(int freq)
		{
			alive = true;
			frequency = freq;
		}

		public void Run()
		{
			while (alive)
			{
				PrintEnvironment();

				Thread.Sleep(frequency);
			}
		}

		private void PrintEnvironment()
		{
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					if (i == Agent.posI && j == Agent.posJ)
						Console.Write("X ");
					else
						Console.Write(Environment.grid[i, j] + " ");
				}
				Console.WriteLine();
			}
			Console.WriteLine("\n");
		}
	}
}
