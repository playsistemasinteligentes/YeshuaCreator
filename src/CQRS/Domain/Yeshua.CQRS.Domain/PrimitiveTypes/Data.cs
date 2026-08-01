
using System.ComponentModel.DataAnnotations;

namespace Dominio.TiposPrimitivos
{
    public struct Data
    {
        private readonly DateOnly _value;
        private Data(DateOnly value) => new Data(value);
        public static implicit operator Data(DateOnly value) => new Data(value);
    }
}