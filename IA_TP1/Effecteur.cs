namespace IA_TP1
{
    class Effecteur
    {
        public int faire(Action a, int i, int j)
        {
			// Notifier l'environnement de l'action effectuée - action a la position i,j
			return Environment.ProcessAction(a, i, j);
        }
    }
}
