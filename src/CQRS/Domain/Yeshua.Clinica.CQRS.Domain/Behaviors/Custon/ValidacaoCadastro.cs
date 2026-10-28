using Dominio.Patterns.Domain;

namespace Dominio.Behaviors;

internal static class ValidacaoCadastro
{
    internal static bool Escrita(DomainOperationContext context) =>
        context.Operation is DomainOperation.Registro or DomainOperation.Alteracao;

    internal static void Texto(string? value, string label, int max, List<string> errors)
    {
        if (value?.Length > max) errors.Add($"{label} deve ter no máximo {max} caracteres.");
        if (!string.IsNullOrEmpty(value) && string.IsNullOrWhiteSpace(value))
            errors.Add($"{label} não pode conter apenas espaços.");
    }

    internal static void Telefone(string? value, string label, int max, List<string> errors)
    {
        if (string.IsNullOrEmpty(value)) return;
        var digits = 0;
        var invalid = false;
        foreach (var c in value)
        {
            if (char.IsAsciiDigit(c)) digits++;
            else if (c is not (' ' or '+' or '-' or '(' or ')' or '.')) invalid = true;
        }
        if (value.Length > max || digits is < 8 or > 15 || invalid)
            errors.Add($"{label}: informe um número válido, com DDD quando houver.");
    }

    internal static void Opcao(int? value, int min, int max, string label, List<string> errors)
    {
        if (value.HasValue && (value < min || value > max)) errors.Add($"Selecione uma opção válida em {label}.");
    }

    internal static void Referencia(int? value, string label, List<string> errors)
    {
        if (value.HasValue && value <= 0) errors.Add($"Selecione {label} pela pesquisa ou deixe o campo vazio.");
    }

    internal static void Valor(decimal value, string label, List<string> errors)
    {
        if (value < 0 || value > 99999999.99m || decimal.Round(value, 2) != value)
            errors.Add($"{label} deve estar entre 0 e 99.999.999,99, com no máximo duas casas decimais.");
    }
}
