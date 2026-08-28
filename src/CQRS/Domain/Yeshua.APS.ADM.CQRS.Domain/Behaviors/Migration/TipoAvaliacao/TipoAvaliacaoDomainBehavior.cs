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
    public static partial class TipoAvaliacaoDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITipoAvaliacaoEntity tipoavaliacao, DomainOperationContext context)
        {
            PrepareCustom(tipoavaliacao, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(tipoavaliacao, context, result.Errors);
            ValidateCustom(tipoavaliacao, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(tipoavaliacao, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITipoAvaliacaoEntity tipoavaliacao, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => tipoavaliacao.isValidInsert(),
                DomainOperation.Alteracao => tipoavaliacao.isValidUpdate(),
                DomainOperation.Remocao => tipoavaliacao.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(tipoavaliacao.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITipoAvaliacaoEntity tipoavaliacao, DomainOperationContext context);
        static partial void ValidateCustom(ITipoAvaliacaoEntity tipoavaliacao, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITipoAvaliacaoEntity tipoavaliacao, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration