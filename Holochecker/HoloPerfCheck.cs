using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using hprc;

/* Classe de verification ds performances de l'ordinateur */
namespace HoloChecker
{
    class PerformanceCheck
    {
        /* Decorateur du processus d'erreur permettant d'implementer les fonctionnalité de notification */
        ErrorManager prce;
         //Classe compteur permetant de récupérer les performance memoire
        public PerformanceCounter memCount;
        double cpuUsage;
        float ramUsage;
        /* constructeur */
        public PerformanceCheck()
        {


            
            prce = new ErrorManager((IPrc_Error)PrcFactory.getProcess("error"));
           
            memCount =
          new PerformanceCounter("Memory", "Available MBytes");
            update();


        }

        /* Methode permettant de récupérer les données du processeur */
        public static double GetCpuPerf()
        {         ManagementObject searcher = new ManagementObject("Win32_PerfFormattedData_PerfOS_Processor.Name='_Total'");
                searcher.Get();
            double a = double.Parse(searcher.Properties["PercentProcessorTime"].Value.ToString());     return a;
        }

        /* Methode permettant de notifié un changement de performance au niveau de la base de donnée ( ajout et suppression
         * des erreurs du à une modification de performance ) */
        public void update()
        {
            // Reinitialisation des erreurs avant un novueau check
            prce.errorReset();
            
            ramUsage = memCount.NextValue();
            cpuUsage = GetCpuPerf();

            if( ramUsage < 50)
            {
                //Notification erreur de Memoire en base d donnée
                prce.errorTrue(0003);
            }
            if(cpuUsage > 80)
            {
                //notification erreur processeur en base de donnée
                prce.errorTrue(0002);
            }
            
        }
    }
}