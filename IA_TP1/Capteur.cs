using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_TP1
{
    class Capteur
    {
        public static void capterEnvironement(Agent agent) {
            agent.setCroyance(Environment.getGrid());
        }
    }
}
