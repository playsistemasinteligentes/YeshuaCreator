// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
// </yeshua>

using Dominio.Entitys;
using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Behaviors
{
    public static partial class ConfiguracoesDomainBehavior
    {
        public static DomainBehaviorResult Apply(IConfiguracoesEntity configuracoes, DomainOperationContext context)
        {
            PrepareCustom(configuracoes, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(configuracoes, context, result.Errors);
            ValidateCustom(configuracoes, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(configuracoes, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IConfiguracoesEntity configuracoes, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => configuracoes.isValidInsert(),
                DomainOperation.Alteracao => configuracoes.isValidUpdate(),
                DomainOperation.Remocao => configuracoes.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(configuracoes.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IConfiguracoesEntity configuracoes, DomainOperationContext context);
        static partial void ValidateCustom(IConfiguracoesEntity configuracoes, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IConfiguracoesEntity configuracoes, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration