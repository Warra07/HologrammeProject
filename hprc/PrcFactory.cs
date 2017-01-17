using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hprc
{
    /*
     * COUCHE Metier
     * Classe Factory : envoie des differents processus de l'application en utilisant des singleton afin de ne pas dupliquer
     * les processus
     */
    public class PrcFactory
    {
        private static Dictionary<string, Object> prc = new Dictionary<string, Object>();

        public static Object getProcess(string name)
        {
            Object temp;
            switch (name)
            {
                /*
                 * renvoyer une instance de type Prc_Texte
                 */
                case "texte" :
                    if (!(prc.TryGetValue(name,out temp)))
                        {
                        temp = new Prc_Text();
                        prc.Add(name, temp);
                       }
                    break;

                    /*
                     * renvoyer une instance de type Prc_Error
                     */
                case "error":
                    
                        if (!(prc.TryGetValue(name, out temp)))
                        {
                            temp = new Prc_Error();
                            prc.Add(name, temp);
                        }
                        break;

               default :
                        return null;
                        break;
                    }
            return temp;
                    }
            }

        }

    

