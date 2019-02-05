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
			Environment env = new Environment(100);
			new Thread(env.Run).Start();

			Affichage aff = new Affichage(100);
			new Thread(aff.Run).Start();

			Agent a = new Agent();

			Thread.Sleep(10000);


			env.alive = false;
			aff.alive = false;

			Console.ReadKey();
		}
	}
}
