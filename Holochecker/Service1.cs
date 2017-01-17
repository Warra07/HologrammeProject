using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;



/* classe du service Hologramme contenant la methode de lancement du service */
namespace HoloChecker
{
    public partial class Service1 : ServiceBase
    {


        PerformanceCheck check;
        public Service1()
        {

            check = new PerformanceCheck();
            InitializeComponent();
        }

        /* Methode principal du service executant la methode Update du verificateur d performance toutes les
         * 30 secondes */
        protected override void OnStart(string[] args)
        {
            //Le service s'effectue en boucle
            while (true)
            {
                //appele de la methode update de la classe performance check
                check.update();
                //attende  de 30 seconde avant un nouvau check
                System.Threading.Thread.Sleep(30000);
            }
    }

        protected override void OnStop()
        {
        }

    }
}