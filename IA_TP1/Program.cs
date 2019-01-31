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

			Thread th_envt = new Thread(envt.Generate);
			th_envt.Start();

			TestEnvoi t = new TestEnvoi();
			Thread tt = new Thread(t.Generate);
			tt.Start();

			Thread.Sleep(10000);


			envt.run = false;
			t.run = false;

			Console.WriteLine("Nb poussière : " + envt.counterPoussiere);
			Console.WriteLine("Nb bijoux : " + envt.counterBijoux);

			Console.ReadKey();
		}
	}
}
