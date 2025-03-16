using Comandos.Pateners.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Patterns.Command
{
    public struct SearchFKCommand : ICommand
    {
        public string searchFK { get; set; }
    }
}
