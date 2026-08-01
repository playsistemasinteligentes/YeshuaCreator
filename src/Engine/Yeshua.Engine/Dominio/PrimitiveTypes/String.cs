using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Dominio.TiposPrimitivos
{
    public struct String {
        private readonly string _value;

        private String (string value)
        {
            _value = value;   
        }
        public static implicit operator String(string value) => new String(value); 
        public override string ToString() => _value;

    }
}
