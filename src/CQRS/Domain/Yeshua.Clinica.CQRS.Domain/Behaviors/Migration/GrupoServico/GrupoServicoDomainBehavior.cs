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
    public static partial class GrupoServicoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IGrupoServicoEntity gruposervico, DomainOperationContext context)
        {
            PrepareCustom(gruposervico, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(gruposervico, context, result.Errors);
            ValidateCustom(gruposervico, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(gruposervico, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IGrupoServicoEntity gruposervico, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => gruposervico.isValidInsert(),
                DomainOperation.Alteracao => gruposervico.isValidUpdate(),
                DomainOperation.Remocao => gruposervico.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(gruposervico.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IGrupoServicoEntity gruposervico, DomainOperationContext context);
        static partial void ValidateCustom(IGrupoServicoEntity gruposervico, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IGrupoServicoEntity gruposervico, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration