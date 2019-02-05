//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;

//namespace IA_TP1
//{
//	class TestEnvoi
//	{
//		Queue<Action> sequence;
//		public bool alive;

//		public TestEnvoi()
//		{
//			alive = true;
//			sequence = new Queue<Action>();
//		}

//		public void Generate()
//		{
//			Random r = new Random();
//			while (alive)
//			{
//				double rand = r.NextDouble();
//				if (rand < 1 / (double)7)
//				{
//					sequence.Clear();
//					sequence.Enqueue(Action.HAUT);
//				}
//				else if (rand >= 1 / (double)7 && rand < 2 / (double)7)
//				{
//					sequence.Clear();
//					sequence.Enqueue(Action.BAS);
//				}
//				else if (rand >= 2 / (double)7 && rand < 3 / (double)7)
//				{
//					sequence.Clear();
//					sequence.Enqueue(Action.GAUCHE);
//				}
//				else if (rand >= 3 / (double)7 && rand < 4 / (double)7)
//				{
//					sequence.Clear();
//					sequence.Enqueue(Action.DROITE);
//				}
//				else if (rand >= 4 / (double)7 && rand < 5 / (double)7)
//				{
//					sequence.Clear();
//					sequence.Enqueue(Action.ASPIRER);
//				}
//				else if (rand >= 5 / (double)7 && rand < 6 / (double)7)
//				{
//					sequence.Clear();
//					sequence.Enqueue(Action.RAMASSER);
//				}
//				else
//				{
//					sequence.Clear();
//					sequence.Enqueue(Action.ATTENDRE);
//				}

//				lock (Program._lock)
//				{
//					Environment.agentActions = sequence;
//				}


//				Thread.Sleep(500);
//			}
//		}
//	}
//}
