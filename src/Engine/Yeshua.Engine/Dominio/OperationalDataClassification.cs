namespace Dominio;

public enum OperationalDataClassification
{
    Public,
    Internal,
    Confidential,
    Restricted,
    NeverCapture
}

public static class OperationalDataClassificationConvention
{
    private static readonly string[] NeverCaptureNames =
    [
        "password",
        "senha",
        "secret",
        "segredo",
        "token",
        "authorization",
        "cookie",
        "connectionstring",
        "privatekey",
        "chaveprivada",
        "pfx",
        "certificatebytes",
        "certificadobytes",
        "rawxml",
        "xmlintegral",
        "rawpayload",
        "payloadbruto"
    ];

    private static readonly string[] ConfidentialNames =
    [
        "cpf",
        "cnpj",
        "documento",
        "email",
        "telefone",
        "celular",
        "fone",
        "endereco",
        "logradouro",
        "cep",
        "placa",
        "nome"
    ];

    public static OperationalDataClassification Classify(Column column)
    {
        if (column.OperationalClassification is { } declared)
            return declared;

        if (column.IsPassword || column.IsUserEncryptedField || Matches(column.Name, NeverCaptureNames))
            return OperationalDataClassification.NeverCapture;

        if (Matches(column.Name, ConfidentialNames))
            return OperationalDataClassification.Confidential;

        return OperationalDataClassification.Internal;
    }

    private static bool Matches(string name, IEnumerable<string> fragments)
    {
        foreach (var fragment in fragments)
        {
            if (name.Contains(fragment, StringComparison.OrdinalIgnoreCase))
                return true;
        }

        return false;
    }
}
