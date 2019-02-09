using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace IA_TP1
{
	class Program
	{
		static void Main(string[] args)
		{
			Environment env = new Environment(100);
			new Thread(env.Run).Start();

			Affichage aff = new Affichage(50);
			new Thread(aff.Run).Start();

			Agent age = new Agent();
			new Thread(age.Run).Start();

			//Thread.Sleep(60000);


			//env.alive = false;
			//aff.alive = false;
			//age.alive = false;

			Console.ReadKey();
		}
	}
}
