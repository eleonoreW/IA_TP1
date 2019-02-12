namespace IA_TP1
{
	class Capteur
	{
		public int[,] CapterEnvironement()
		{
			return Environment.grid.Clone() as int[,];
		}
		public int CapterPerformance()
		{
			return Environment.performanceAgent;
		}
	}
}
