
using System.ComponentModel.DataAnnotations;

namespace Dominio.TiposPrimitivos
{
    public struct DataHora
    {
        private readonly DateTime _value;
        private DataHora(DateTime value) => _value = value;
        public static implicit operator DataHora(DateTime value) => new DataHora(value);
        public override string ToString() => _value.ToString("O");
    }
}
