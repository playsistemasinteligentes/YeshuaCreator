using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.TiposPrimitivos
{
    public struct Cpf
    {
        private readonly string _value;
        private Cpf(string value)
        { 
            _value = value;
        }
        public override string ToString() => _value;
        public static implicit operator Cpf(string value) => Parce(value);
        public static implicit operator Cpf(long value) => Parce(value);

        public static Cpf Parce(string value)
        {
            if (TryParce(value, out var result))
            {
                return result;
            }
            throw new ArgumentException(Message.CpfInvalido);
        }
        public static Cpf Parce(long value)
        {
            if (TryParce(value.ToString(), out var result))
            {
                return result;
            }
            throw new ArgumentException(Message.CpfInvalido);
        }
        public static bool TryParce(string value, out Cpf cpf) { 
        
            cpf = new Cpf(value);
            return true;
        }


    }
}
