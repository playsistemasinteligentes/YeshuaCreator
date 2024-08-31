using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Dominio.TiposPrimitivos
{
    public struct Nome {
        public readonly string Value;
        private Nome(string value) => Value = value;
        public static implicit operator Nome(string value) => new Nome(value);
        
    }
}
