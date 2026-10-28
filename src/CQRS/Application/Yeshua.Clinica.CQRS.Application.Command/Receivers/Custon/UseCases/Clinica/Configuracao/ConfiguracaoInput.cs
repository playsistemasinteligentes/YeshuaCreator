using Clinica.Atendimentos;
using System.Security.Cryptography;
using System.Text;
namespace Command.Receivers.UseCase;
internal static class ConfiguracaoInput
{
    public static string Hash(params string[] values)
    {
        var text=new StringBuilder();
        foreach(var value in values)text.Append(value.Length).Append(':').Append(value);
        return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(text.ToString())));
    }
    public static void ExigirId(int id)
    {if(id<0)throw new AtendimentoException("Escolha um cadastro válido.");}
}
