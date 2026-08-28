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
    public static partial class ConsultasDomainBehavior
    {
        public static DomainBehaviorResult Apply(IConsultasEntity consultas, DomainOperationContext context)
        {
            PrepareCustom(consultas, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(consultas, context, result.Errors);
            ValidateCustom(consultas, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(consultas, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IConsultasEntity consultas, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => consultas.isValidInsert(),
                DomainOperation.Alteracao => consultas.isValidUpdate(),
                DomainOperation.Remocao => consultas.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(consultas.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IConsultasEntity consultas, DomainOperationContext context);
        static partial void ValidateCustom(IConsultasEntity consultas, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IConsultasEntity consultas, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration