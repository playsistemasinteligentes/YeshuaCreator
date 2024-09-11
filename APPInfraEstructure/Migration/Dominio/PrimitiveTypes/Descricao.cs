using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Dominio.TiposPrimitivos
{
    public struct Descricao
    {
        public readonly string _value;
        private Descricao(string value)
        {
            _value = value;
        }
        //private Descricao(string value) => _value = value;
        public override string ToString() => _value;
        public static implicit operator Descricao(string value) => new Descricao(value);
        public static implicit operator Descricao(Column value) => Parce(value);
        public static implicit operator Descricao(Entity value) => Parce(value);

        public static Descricao Parce(Column value)
        {
            return new Descricao(value.Name);
            throw new ArgumentException(Message.CpfInvalido);
        }
        public static Descricao Parce(Entity value)
        {
            return new Descricao(normalise(value.EntityName));
            throw new ArgumentException(Message.CpfInvalido);
        }

        public static string normalise(string value)
        {
            return AddSpacesBeforeUpperCase(value);
        }
        public string Normalize(string value)
        {
            return AddSpacesBeforeUpperCase(value);
        }

        public static string AddSpacesBeforeUpperCase(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(input[0]); // Adiciona o primeiro caractere sem alteração

            for (int i = 1; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (char.IsUpper(currentChar))
                {
                    sb.Append(' '); // Adiciona um espaço antes de uma letra maiúscula
                }

                sb.Append(currentChar);
            }

            return sb.ToString();
        }
    }
}
