using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hprc
{
    public class PrcFactory
    {
        private static Dictionary<string, Object> prc = new Dictionary<string, Object>();

        public static Object getProcess(string name)
        {
            Object temp;
            switch (name)
            {
                case "texte" :
                    if (!(prc.TryGetValue(name,out temp)))
                        {
                        temp = new Prc_Text();
                        prc.Add(name, temp);
                       }
                    break;

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

    

