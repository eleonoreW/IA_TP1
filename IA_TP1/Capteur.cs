namespace IA_TP1
{
    class Capteur
    {
        public int[,] capterEnvironement() {
			return Environment.grid.Clone() as int[,];
		}
    }
}
