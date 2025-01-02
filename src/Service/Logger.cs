using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal class Logger
    {
        internal static Logger Instance;
        private const string LogFile = "log.txt";

        public static void Log(string message, bool isError = false)
        {
            if(Instance == null) {
                Instance = new Logger();
            }

            Instance._log(message, isError);
        }


        private void _log(string message, bool isError)
        {
            using (var writer = new StreamWriter(LogFile, true))
            {
                string logType = isError ? "ERROR" : "INFO";
                writer.WriteLine($"{logType} {DateTime.Now} - {message}");
                writer.Close();
            }
        }
    }
}
