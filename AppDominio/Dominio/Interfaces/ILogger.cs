using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface ILogger
    {
        void Info(string message);
        void Command(string commandName, string traceId, string fase, long? durationMs = null);
        void Error(string commandName, string traceId, Exception ex);
    }
}