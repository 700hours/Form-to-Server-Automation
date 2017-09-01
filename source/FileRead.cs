using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Timers;

namespace FileRead
{
    class Core
    {
        public static string
            logname,
            servqueuename,
            sidname,
            spname,
            spdlname,
            resourcetxt,
            sysramoutexe,
            makeservername,
            fileservexe,
            Logname,
            ramlimit,
            serverID = "default",
            oldserverID = "default";
        private static System.Timers.Timer systimer;
        public static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[0] == "-ramlimit")
                {
                    ramlimit = args[1];
                }
                if (args[2] == "-logname")
                {
                    logname = args[3];
                }
                if (args[4] == "-queuename")
                {
                    servqueuename = args[5];
                }
                if (args[6] == "-paramsname")
                {
                    spname = args[7];
                }
                if (args[8] == "-idname")
                {
                    sidname = args[9];
                }
                if (args[10] == "-resourcetxtname")
                {
                    resourcetxt = args[11];
                }
                if (args[12] == "-sysresourcexe")
                {
                    sysramoutexe = args[13];
                }
                if (args[14] == "-updatename")
                {
                    makeservername = args[15];
                }
                if (args[16] == "-servelogname")
                {
                    Logname = args[17];
                }
                if (args[18] == "-fileservexe")
                {
                    fileservexe = args[19];
                }
                if (args[20] == "-paramsdlname")
                {
                    spdlname = args[21];
                }
            }
            if (!File.Exists(sidname))
            {
                File.WriteAllText(sidname, "default");
            }
            if (!File.Exists(logname))
            {
                File.WriteAllText(logname, "");
            }
            systimer = new Timer(15000); // 15 seconds
            systimer.Elapsed += new ElapsedEventHandler(Read);
            systimer.Start();
            Console.ReadKey();
        }
        public static void Read(object source, ElapsedEventArgs e)
        {
            serverID = File.ReadAllText(sidname);
            Console.WriteLine("Current ID: " + serverID + " Old ID: " + oldserverID);
			GC.Collect();
            if (serverID != oldserverID && serverID != "default" && serverID != "")
            {
                string text = "";
                var file = Path.ChangeExtension(spdlname, ".txt");
				if (File.Exists(file))
                {
                    File.Delete(file);
                }
                File.Move(spdlname, file);
                using (StreamReader sr = new StreamReader(file))
                {
                    string[] lines = sr.ReadToEnd().Split(';');
                    for (int i = 0; i < lines.Length; i++)
                    {
                        text += lines[i] + Environment.NewLine;
                    }
                }
				File.WriteAllText(spname, "");
                File.AppendAllText(spname, text);
                Console.WriteLine("Server process queued with server name: " + serverID);
                File.AppendAllText(logname, Environment.NewLine + DateTime.Now.ToString("HH:mm:ss tt") + ": " + "Server process queued with server name " + serverID);
                oldserverID = serverID;
                ProcessStartInfo servqueued = new ProcessStartInfo();
                servqueued.Arguments = ramlimit + " " + spname + " " + sidname + " " + resourcetxt + " " + sysramoutexe + " " + makeservername + " " + Logname + " " + servqueuename;
                servqueued.FileName = fileservexe;
                servqueued.WindowStyle = ProcessWindowStyle.Normal;
                servqueued.CreateNoWindow = false;
                Process queue;
                queue = Process.Start(servqueued);
            }
        }
    }
}