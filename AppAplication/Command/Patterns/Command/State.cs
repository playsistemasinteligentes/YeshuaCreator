using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Pateners.Command
{
    public class State
    {
        public State(int statusCode, List<string> menssages, object data)
        {
            StatusCode = statusCode;
            MessageList = menssages;
            Message = menssages.ElementAt(0);
            Data = data;
        }

        public State(int statusCode, string statusMessage, object data)
        {
            StatusCode = statusCode;
            Message = statusMessage;
            Data = data;
        }

        public State(int statusCode, Exception e, object data)
        {
            StatusCode = statusCode;
            bool debug = true;
            if (debug)
                Message = e.Message;
            Data = data;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<string> MessageList { get; set; }
        public object Data { get; set; }
    }
}
