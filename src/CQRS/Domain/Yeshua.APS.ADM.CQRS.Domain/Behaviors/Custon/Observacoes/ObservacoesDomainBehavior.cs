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
using Dominio.Entitys.Custon.Observacoes;
using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Behaviors
{
    public static partial class ObservacoesDomainBehavior
    {
        static partial void PrepareCustom(IObservacoesEntity observacoes, DomainOperationContext context)
        {
            ObservacoesBusinessRules.Prepare(observacoes, context);
        }

        static partial void ValidateCustom(IObservacoesEntity observacoes, DomainOperationContext context, List<string> errors)
        {
            ObservacoesBusinessRules.Validate(observacoes, context, errors);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
