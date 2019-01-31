using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace IA_TP1
{
	class TestEnvoi
	{
		List<string> sequence;
		public bool run;

		public TestEnvoi()
		{
			run = true;
			sequence = new List<string>();
		}

		public void Generate()
		{
			Random r = new Random();
			while (run)
			{
				double rand = r.NextDouble();
				if (rand < 0.25)
				{
					sequence.Clear();
					sequence.Add("G");
				}
				else if (rand >= 0.25 && rand < 0.5)
				{
					sequence.Clear();
					sequence.Add("D");
					sequence.Add("D");
				}
				else if (rand >= 0.5 && rand < 0.75)
				{
					sequence.Clear();
					sequence.Add("H");
					sequence.Add("H");
					sequence.Add("H");
				}
				else
				{
					sequence.Clear();
					sequence.Add("B");
					sequence.Add("B");
					sequence.Add("B");
					sequence.Add("B");
				}

				lock(Program._lock)
				{
					Environment.actions = sequence.ToList();
				}


				Thread.Sleep(500);
			}
		}
	}
}
