using System.Globalization;
namespace Clinica.Atendimentos;

public static class CalendarioConsultas
{
    public const int MaximoOcorrencias = 260;
    private static readonly TimeZoneInfo Zona = TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");
    public static DateTime Local(string value)
    {
        if (!DateTime.TryParseExact(value, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture,
            DateTimeStyles.None, out var local) || Zona.IsInvalidTime(local) || Zona.IsAmbiguousTime(local))
            throw new ArgumentException("Informe data e hora válidas no fuso America/Sao_Paulo.");
        return DateTime.SpecifyKind(local, DateTimeKind.Unspecified);
    }
    public static DateTime Utc(string value) => TimeZoneInfo.ConvertTimeToUtc(Local(value), Zona);
    public static string TextoLocal(DateTime utc) => TimeZoneInfo.ConvertTimeFromUtc(DateTime.SpecifyKind(utc, DateTimeKind.Utc), Zona)
        .ToString("yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
    public static IReadOnlyList<(DateTime Inicio, DateTime Fim)> Expandir(string inicio, string fim, int intervaloDias, string dataFinal)
    {
        if (intervaloDias is not (7 or 14)) throw new ArgumentException("Escolha recorrência semanal ou quinzenal.");
        var start = Local(inicio); var end = Local(fim);
        if (end <= start || end - start > TimeSpan.FromHours(8))
            throw new ArgumentException("Informe um intervalo válido de até oito horas.");
        if (!DateTime.TryParseExact(dataFinal, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var final) || final < start.Date)
            throw new ArgumentException("Informe uma data final igual ou posterior à primeira consulta.");
        var count = (final - start.Date).Days / intervaloDias + 1;
        if (count > MaximoOcorrencias) throw new ArgumentException($"A prévia aceita até {MaximoOcorrencias} ocorrências.");
        var result = new List<(DateTime, DateTime)>(count);
        for (var i = 0; i < count; i++)
        {
            var a = start.AddDays(i * intervaloDias); var b = end.AddDays(i * intervaloDias);
            if (Zona.IsInvalidTime(a) || Zona.IsAmbiguousTime(a) || Zona.IsInvalidTime(b) || Zona.IsAmbiguousTime(b))
                throw new ArgumentException("A série contém um horário inválido ou ambíguo no fuso America/Sao_Paulo.");
            result.Add((TimeZoneInfo.ConvertTimeToUtc(a, Zona), TimeZoneInfo.ConvertTimeToUtc(b, Zona)));
        }
        return result;
    }
    public static bool Sobrepoe(DateTime inicio, DateTime fim, DateTime outroInicio, DateTime outroFim) => inicio < outroFim && fim > outroInicio;
}
