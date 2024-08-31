using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Pateners.Command
{
    public class State
    {
        public State(int statusCode, string statusMessage, object data)
        {
            StatusCode = statusCode;
            StatusMessage = statusMessage;
            Data = data;
        }

        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public object Data { get; set; }

    }
}
