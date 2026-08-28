using Dominio.Patterns.Domain;
using System.Security.Cryptography;
using System.Text;

namespace Dominio.Entitys.Custon.Usuario
{
    public static class UsuarioBusinessRules
    {
        public static void Prepare(IUsuarioEntity usuario, DomainOperationContext context)
        {
            if (context.Operation == DomainOperation.Registro && !string.IsNullOrEmpty(usuario.USE_SENHA))
            {
                usuario.USE_SENHA = ToSha1(usuario.USE_SENHA);
            }
        }

        private static string ToSha1(string value)
        {
            var hashData = SHA1.HashData(Encoding.ASCII.GetBytes(value));
            var builder = new StringBuilder(hashData.Length * 2);
            for (var index = 0; index < hashData.Length; index++)
            {
                builder.Append(hashData[index].ToString("X2"));
            }

            return builder.ToString();
        }
    }
}
