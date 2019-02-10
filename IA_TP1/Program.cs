using System;
using System.Threading;


namespace IA_TP1
{
	class Program
	{
		static void Main(string[] args)
		{
			// Environnement
			Environment env = new Environment(100);
			new Thread(env.Run).Start();

			// Affichage
			Affichage aff = new Affichage(50);
			new Thread(aff.Run).Start();

			// Agent
			Agent age = new Agent(true);
			new Thread(age.Run).Start();


			//Thread.Sleep(60000);

			//env.alive = false;
			//aff.alive = false;
			//age.alive = false;


			Console.ReadKey();
		}
	}
}
