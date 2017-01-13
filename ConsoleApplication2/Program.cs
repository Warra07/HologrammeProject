using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hprc;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            hprc.IPrc_Text test = (hprc.IPrc_Text)hprc.PrcFactory.getProcess("texte");
            hprc.Prc_Error testa = new Prc_Error();
            hprc.ErrorManager testo = new ErrorManager(testa);
            testo.errorReset();

        }
    }
}
