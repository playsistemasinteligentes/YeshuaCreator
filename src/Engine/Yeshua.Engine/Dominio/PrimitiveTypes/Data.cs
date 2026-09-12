
using System.ComponentModel.DataAnnotations;

namespace Dominio.TiposPrimitivos
{
    public struct Data
    {
        private readonly DateOnly _value;
        private Data(DateOnly value) => _value = value;
        public static implicit operator Data(DateOnly value) => new Data(value);
        public override string ToString() => _value.ToString();
    }
}
