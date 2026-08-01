using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IMessage
    {
        string Destination { get; set; }
        string Body { get; set; }
        string? Subject { get; set; }
        byte[]? Attachment { get; set; }
    }
}
