using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Patterns.Command
{
    public class State<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<string> MessageList { get; set; }
        public T Data { get; set; }
        public State(int statusCode, List<string> menssages, T data, bool propagation = true)
        {
            StatusCode = statusCode;
            MessageList = menssages;
            Message = menssages.ElementAt(0);
            Data = data;
            if (propagation)
                EnsureSuccess();
        }

        public State(int statusCode, string statusMessage, T data, bool propagation = true)
        {
            StatusCode = statusCode;
            Message = statusMessage;
            Data = data;
            if (propagation)
                EnsureSuccess();
        }

        public State(int statusCode, Exception e, T data, bool propagation = true)
        {
            StatusCode = statusCode;
            bool debug = true;
            if (debug)
                Message = e.Message;
            Data = data;
            if (propagation)
                EnsureSuccess();
        }
        private void EnsureSuccess()
        {
            if ((int)StatusCode >= 400)
                throw new ReceiverException<T>(this);
        }
    }
}
