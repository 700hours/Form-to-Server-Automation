//reference: http://vivekcek.wordpress.com/2009/10/22/how-to-get-cpu-and-memory-usage-c-net/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace SystemResourceOutput
{
    class Core
    {
    //  private static PerformanceCounter cpuCounter;
        private static PerformanceCounter ramCounter;
        public static void Main()
        {
    //      InitialiseCPUCounter();
            InitializeRAMCounter();
            Output();
        }
    /*  private static void InitialiseCPUCounter()
        {
            cpuCounter = new PerformanceCounter(
            "Processor",
            "% Processor Time",
            "_Total",
            true
            );
        }   */
        private static void InitializeRAMCounter()
        {
            ramCounter = new PerformanceCounter("Memory", "Available MBytes", true);
        }
        private static void Output()
        {
            string ram = Convert.ToInt32(ramCounter.NextValue()).ToString();
            string path = System.Environment.GetEnvironmentVariable("USERPROFILE");
            if (!Directory.Exists(String.Concat(path, "\\desktop\\TerrariaServer\\filebin\\sysresources.cmd")))
            {
                Directory.CreateDirectory(String.Concat(path, "\\desktop\\TerrariaServer\\filebin"));
                using (StreamWriter sw = File.CreateText(String.Concat(path, "\\desktop\\TerrariaServer\\filebin\\sysresources.cmd"))) { }
            }
			using (StreamWriter sw = File.CreateText(String.Concat(path, "\\desktop\\TerrariaServer\\filebin\\ramcheck.txt"))) 
			{ 
				sw.WriteLine(ram);
			}
            File.AppendAllText(String.Concat(path, "\\desktop\\TerrariaServer\\filebin\\sysresources.cmd"), "set ram=" + ram + Environment.NewLine);
            Environment.Exit(0);
        }
    }
}