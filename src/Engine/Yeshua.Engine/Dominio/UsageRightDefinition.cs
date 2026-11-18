namespace Dominio;

[Flags]
public enum UsagePurchaseModel { Period = 1, Credits = 2 }

public sealed record UsageRightDefinition(string Key, string Title, UsagePurchaseModel Models,
    string Module = "", string Saga = "", string Step = "", decimal Units = 1)
{
    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(Key) || Key.Length > 100 ||
            Key.Any(character => !char.IsAsciiLetterOrDigit(character) && character is not ('.' or '-' or '_')))
            throw new InvalidOperationException("Informe uma chave estavel de direito de uso.");
        if (Models == 0 || (Models & ~(UsagePurchaseModel.Period | UsagePurchaseModel.Credits)) != 0 || Units <= 0 || decimal.Round(Units, 4) != Units)
            throw new InvalidOperationException("Modelo ou quantidade de direito de uso invalido.");
        if (string.IsNullOrWhiteSpace(Module) == string.IsNullOrWhiteSpace(Saga) ||
            (!string.IsNullOrWhiteSpace(Saga) && string.IsNullOrWhiteSpace(Step)))
            throw new InvalidOperationException("Vincule o direito a um modulo ou a um step de saga.");
        if (!string.IsNullOrWhiteSpace(Module) && Models != UsagePurchaseModel.Period)
            throw new InvalidOperationException("Acesso a modulo exige contratacao por periodo.");
    }
}
