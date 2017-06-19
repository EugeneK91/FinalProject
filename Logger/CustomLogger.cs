using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLogger = NLog.Logger;

namespace Logger
{
    public sealed class CustomLogger: ILogger
    {
        private static readonly NLogger Nlogger = LogManager.GetCurrentClassLogger();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static CustomLogger() { }

        private CustomLogger() { }

        public static CustomLogger GetCurrentClassLogger { get; } = new CustomLogger();


        public void Error(string message)
        {
            Nlogger.Error(message);
        }

        public void Trace(string message)
        {
            Nlogger.Trace(message);
        }

        public void Info(string message)
        {
            Nlogger.Info(message);
        }

        public void Warn(string message)
        {
            Nlogger.Warn(message);
        }

        public void Debug(string message)
        {
            Nlogger.Debug(message);
        }

        public void Fatal(string message)
        {
            Nlogger.Fatal(message);
        }
    }
}
