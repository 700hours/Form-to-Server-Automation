using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Timers;

namespace FileServe
{
    class Core
    {
        public static string
			logpath,
			queuepath,
            resourcetxt,
            ramoutput,
            makeserverpath,
            spname,
            sidname,
            serverID = "default";
        public static int
			logrammsg = 0,
            ramlimit = 1600,
            ram = 4096;
		public static ulong 
			physicalram;
        private static System.Timers.Timer 
			systimer, 
			systimer2;
        public static void Main(string[] args)
        {
			int.TryParse(args[0], out ramlimit);
			spname = args[1];
            sidname = args[2];
			resourcetxt = args[3];	
			ramoutput = args[4];
			makeserverpath = args[5];
			logpath = args[6];
			queuepath = args[7];
			physicalram = GetTotalMemoryInBytes() / 1024 / 1024;
		/*	using (StreamReader sr = new StreamReader(sidname))
			{
				serverID = sr.ReadToEnd();
				string text = "Processing serverID: " + serverID;
				Console.WriteLine(text);
				File.AppendAllText(logpath, Environment.NewLine + DateTime.Now.ToString("HH:mm:ss tt") + " " + text);
			}	*/
			systimer2 = new Timer(1000); 
            systimer2.Elapsed += new ElapsedEventHandler(ReadRAMmaybeStart);
            systimer2.Start();
			Console.ReadKey();
        }
        public static void ReadRAMmaybeStart(object source, ElapsedEventArgs e)
        {
			ProcessStartInfo ramdisplay = new ProcessStartInfo();
			ramdisplay.Arguments = "";
			ramdisplay.FileName = ramoutput;
			ramdisplay.WindowStyle = ProcessWindowStyle.Normal;
			ramdisplay.CreateNoWindow = false;
			Process ramout;
			ramout = Process.Start(ramdisplay);
			using (StreamReader sr = new StreamReader(resourcetxt))
			{
				ram = Convert.ToInt32(sr.ReadToEnd());
			}
			if(logrammsg == 1)
			{
				string text = "RAM below floor: " + ram + "MBs";
				Console.WriteLine(text);
				File.AppendAllText(logpath, Environment.NewLine + DateTime.Now.ToString("HH:mm:ss tt") + " " + text);
				logrammsg = 2;
			}
		/*	using (StreamReader sr = new StreamReader(sidname))
            {
                serverID = sr.ReadToEnd();
            }	*/
			if(ram <= ramlimit)
			{
				File.WriteAllText(queuepath, "Queue: Yes");
				Console.ReadKey();
				systimer = new Timer(10000); 
				systimer.Elapsed += new ElapsedEventHandler(ReadRAMmaybeStart);
				systimer.Start();
				if(logrammsg == 0) logrammsg = 1;
				return;
			}
			else
			{
				File.WriteAllText(queuepath, "Queue: No");
				string text = "Successful, starting server: " + serverID;
				Console.WriteLine(text);
				File.AppendAllText(logpath, Environment.NewLine + DateTime.Now.ToString("HH:mm:ss tt") + " " + text);
				if(logrammsg > 0) 
				{	
					logrammsg = 0;
				}
				ProcessStartInfo createserver = new ProcessStartInfo();
                createserver.Arguments = "";
                createserver.FileName = makeserverpath;
                createserver.WindowStyle = ProcessWindowStyle.Normal;
                createserver.CreateNoWindow = false;
				Process update;
				update = Process.Start(createserver);
			}
			Environment.Exit(0);
        }
        private static ulong GetTotalMemoryInBytes()
        {
            return new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
        }
    }
}