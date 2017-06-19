using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public interface ILogger
    {
        void Error(string message);
        void Trace(string message);
        void Info(string message);
        void Warn(string message);
        void Debug(string message);
        void Fatal(string message);
    }
}
