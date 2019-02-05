using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_TP1
{
    class Effecteur
    {
        public int faire(Action a, int i, int j)
        {
            return Environment.ProcessAction(a, i, j);
        }
        /*notifier l'environnement de l'action effectuée - action
                                                         - position i,j */
                                  

    }
}
