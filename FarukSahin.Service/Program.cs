using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FarukSahin.Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            if(Debugger.IsAttached)
            {
                Console.Title = "Faruk Sahin Server Info Service";
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(String.Format("[!]{0} Servis Başlatıldı!",DateTime.Now));
                Starter.Start();
                Console.ReadKey();
            }
            else
            {
                Starter _starter = new Starter();
            }
        }
    }
}
