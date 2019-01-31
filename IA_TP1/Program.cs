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
			Environment e = new Environment();


			Thread test = new Thread(new ParameterizedThreadStart(e.Generate));
			test.Start();
			Thread.Sleep(10000);

			e._run = false;

			Thread.Sleep(100);

			Console.WriteLine("Nb poussière : " + e._counterPoussiere);
			Console.WriteLine("Nb bijoux : " + e._counterBijoux);

			Console.ReadKey();
		}
	}
}
