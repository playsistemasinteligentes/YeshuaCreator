using Dominio;
using Dominio.Migration;

namespace AppClinicas;

[Migration(000010)]
public sealed class M000010 : MigrationBase
{
    public override void Up()
    {
        RequirePeriodAccess("PSI", "clinica.access", "Acesso a Clinica");
        ChargeSagaStep("PsychologySessionInsight", "audioTranscriptRequested", "clinica.transcription", "Transcricao de audio",
            UsagePurchaseModel.Period | UsagePurchaseModel.Credits);
    }
}
