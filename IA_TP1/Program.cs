using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace IA_TP1
{
	class Program
	{
		public static Object _lock = new Object();

		static void Main(string[] args)
		{
			Environment envt = new Environment();
			Thread th_envt = new Thread(envt.Run);
			th_envt.Start();

			//TestEnvoi t = new TestEnvoi();
			//Thread tt = new Thread(t.Generate);
			//tt.Start();

			Thread.Sleep(10000);


			envt.alive = false;
			//t.alive = false;

			Console.WriteLine("Agent pos : (" + envt.agentPosI + "," + envt.agentPosJ + ")");
			Console.WriteLine("Agent score : " + envt.agentScore);

			Console.ReadKey();
		}
	}
}
