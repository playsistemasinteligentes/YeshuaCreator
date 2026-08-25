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
    public static partial class ServicoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IServicoEntity servico, DomainOperationContext context)
        {
            PrepareCustom(servico, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(servico, context, result.Errors);
            ValidateCustom(servico, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(servico, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IServicoEntity servico, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => servico.isValidInsert(),
                DomainOperation.Alteracao => servico.isValidUpdate(),
                DomainOperation.Remocao => servico.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(servico.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IServicoEntity servico, DomainOperationContext context);
        static partial void ValidateCustom(IServicoEntity servico, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IServicoEntity servico, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration