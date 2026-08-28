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
    public static partial class ClpMedicoesDomainBehavior
    {
        public static DomainBehaviorResult Apply(IClpMedicoesEntity clpmedicoes, DomainOperationContext context)
        {
            PrepareCustom(clpmedicoes, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(clpmedicoes, context, result.Errors);
            ValidateCustom(clpmedicoes, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(clpmedicoes, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IClpMedicoesEntity clpmedicoes, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => clpmedicoes.isValidInsert(),
                DomainOperation.Alteracao => clpmedicoes.isValidUpdate(),
                DomainOperation.Remocao => clpmedicoes.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(clpmedicoes.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IClpMedicoesEntity clpmedicoes, DomainOperationContext context);
        static partial void ValidateCustom(IClpMedicoesEntity clpmedicoes, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IClpMedicoesEntity clpmedicoes, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration