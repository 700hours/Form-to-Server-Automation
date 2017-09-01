using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Timers;

namespace FileStream
{
    class Core
    {
        public static string
            locality,
			logpath,
			queuepath,
			serverIDpath,
            spname,
            sidname,
			tshockpath,
			tshockcmd,
            serverID = "default",
            oldserverID = "default",
			queuedornot; // 10 seconds
		public static int updatetime = 10000;
        private static System.Timers.Timer systimer;
        public static void Main(string[] args)
        {
			int.TryParse(args[0], out updatetime);
			logpath = args[1];
			queuepath = args[2];
            serverIDpath = args[3];
			spname = args[4];
            sidname = args[5];
			locality = args[6];
			tshockpath = args[7];
			tshockcmd = args[8];
            if(!File.Exists(logpath))
            {
				File.WriteAllText(logpath, "");
            }
			if(!File.Exists(queuepath))
            {
				File.WriteAllText(queuepath, "Queue: No");
				File.AppendAllText(logpath, Environment.NewLine + DateTime.Now.ToString("HH:mm:ss tt") + " Wrote that there are is no queue");
            }
			using (StreamReader sr = new StreamReader(serverIDpath + sidname))
			{
				serverID = sr.ReadToEnd();
				string text = "Current serverID: " + serverID;
				Console.WriteLine(text);
				File.AppendAllText(logpath, DateTime.Now.ToString("HH:mm:ss tt") + " " + text);
			}
            systimer = new Timer((double)updatetime); 
            systimer.Elapsed += new ElapsedEventHandler(DownloadID);
            systimer.Start();
            Console.ReadKey();
        }
        public static void DownloadID(object source, ElapsedEventArgs e)
        {
			using (StreamReader sr = new StreamReader(queuepath))
			{
				queuedornot = sr.ReadToEnd();
			}
			if(queuedornot == "Queue: No")
			{
				Console.WriteLine(".");
				WebClient ID = new WebClient();
				ID.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadParams);
				ID.DownloadFileAsync(new Uri(locality + spname), spname);
			}
			else
			{
				string text = "Server process queued";
				Console.WriteLine(text);
			}
        }
        public static void DownloadParams(object source, AsyncCompletedEventArgs e)
        {
            WebClient param = new WebClient();
            param.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadTShockID);
            param.DownloadFileAsync(new Uri(locality + sidname), sidname);
        }
		public static void DownloadTShockID(object source, AsyncCompletedEventArgs e)
        {
            WebClient param = new WebClient();
            param.DownloadFileCompleted += new AsyncCompletedEventHandler(IdentifyMaybeStart);
            param.DownloadFileAsync(new Uri(tshockpath + tshockcmd), tshockcmd);
        }
        public static void IdentifyMaybeStart(object source, AsyncCompletedEventArgs e)
        {
			Console.WriteLine("Download complete.");
            using (StreamReader sr = new StreamReader(serverIDpath + sidname))
            {
                serverID = sr.ReadToEnd();
                Console.WriteLine("Comparing ID's.. " + serverID + "/" + oldserverID);
            }
			GC.Collect();
			if (serverID != oldserverID && serverID != "" && serverID != "default")
			{
				oldserverID = serverID;
				string text = "Server request being made: " + serverID;
				Console.WriteLine(text);
				File.AppendAllText(logpath, Environment.NewLine + DateTime.Now.ToString("HH:mm:ss tt") + " " + text);
			}
        }
    }
}