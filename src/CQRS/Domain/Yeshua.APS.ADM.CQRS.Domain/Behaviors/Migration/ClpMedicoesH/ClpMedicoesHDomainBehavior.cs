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
    public static partial class ClpMedicoesHDomainBehavior
    {
        public static DomainBehaviorResult Apply(IClpMedicoesHEntity clpmedicoesh, DomainOperationContext context)
        {
            PrepareCustom(clpmedicoesh, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(clpmedicoesh, context, result.Errors);
            ValidateCustom(clpmedicoesh, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(clpmedicoesh, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IClpMedicoesHEntity clpmedicoesh, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => clpmedicoesh.isValidInsert(),
                DomainOperation.Alteracao => clpmedicoesh.isValidUpdate(),
                DomainOperation.Remocao => clpmedicoesh.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(clpmedicoesh.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IClpMedicoesHEntity clpmedicoesh, DomainOperationContext context);
        static partial void ValidateCustom(IClpMedicoesHEntity clpmedicoesh, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IClpMedicoesHEntity clpmedicoesh, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration