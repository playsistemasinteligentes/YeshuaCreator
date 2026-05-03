using Command.Saga;
using Dominio.Saga;
using Dominio.Patterns.Saga;

namespace Command.Receivers
{
    public partial class ReportEndProntuaryRequestedHandler
    {
        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            // TODO: publicar na outbox text.summarize.outbox
            // com o texto transcrito da sessão
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            // TODO: aplicar prontuário e relatório na sessão
            // payload contém o JSON com prontuario e relatorio
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers