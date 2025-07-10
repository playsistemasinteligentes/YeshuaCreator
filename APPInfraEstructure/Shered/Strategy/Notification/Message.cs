using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shered.Strategy.Notification
{
    public class Message : IMessage
    {
        public string Destination { get; set; }
        public string Body { get; set; }
        public string? Subject { get; set; } = null;
        public byte[]? Attachment { get; set; } = null;
    }
}
