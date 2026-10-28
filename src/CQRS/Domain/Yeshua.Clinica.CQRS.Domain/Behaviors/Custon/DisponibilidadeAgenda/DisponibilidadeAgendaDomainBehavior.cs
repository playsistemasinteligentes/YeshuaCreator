// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
// </yeshua>

using Dominio.Entitys;
using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Behaviors
{
    public static partial class DisponibilidadeAgendaDomainBehavior
    {
        static partial void ValidateCustom(IDisponibilidadeAgendaEntity entity, DomainOperationContext context, List<string> errors)
        {
            if (!ValidacaoCadastro.Escrita(context)) return;
            if (entity.ProfissionalId.GetValueOrDefault()<=0) errors.Add("Selecione o profissional deste horário.");
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
