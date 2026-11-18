namespace Dominio.Commercial.Central;

public sealed record CommercialOffer(string Code, string Title, string Application, string Resource,
    string Model, decimal PriceCredits, int Months, decimal Units, bool GrantsApplicationAccess = false);

public static class CommercialOffers
{
    public static readonly IReadOnlyList<CommercialOffer> All = Array.AsReadOnly(new[]
    {
        new CommercialOffer("clinica-periodo", "Clinica por periodo", "Clinica", "clinica.access", "period", 100m, 1, 0m, true),
        new CommercialOffer("transcricao-periodo", "Transcricao por periodo", "Clinica", "clinica.transcription", "period", 50m, 1, 0m),
        new CommercialOffer("transcricao-creditos", "Pacote de 10 transcricoes", "Clinica", "clinica.transcription", "credits", 20m, 0, 10m)
    });

    public static DateTime ExtendPeriod(DateTime? currentEnd, DateTime utcNow, int months)
    {
        if (months is < 1 or > 36) throw new ArgumentOutOfRangeException(nameof(months));
        return (currentEnd > utcNow ? currentEnd.Value : utcNow).AddMonths(months);
    }
}
