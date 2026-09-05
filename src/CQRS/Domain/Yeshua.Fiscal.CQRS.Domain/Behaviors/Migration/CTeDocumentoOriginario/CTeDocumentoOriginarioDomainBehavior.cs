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
    public static partial class CTeDocumentoOriginarioDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICTeDocumentoOriginarioEntity ctedocumentooriginario, DomainOperationContext context)
        {
            PrepareCustom(ctedocumentooriginario, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(ctedocumentooriginario, context, result.Errors);
            ValidateCustom(ctedocumentooriginario, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(ctedocumentooriginario, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICTeDocumentoOriginarioEntity ctedocumentooriginario, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => ctedocumentooriginario.isValidInsert(),
                DomainOperation.Alteracao => ctedocumentooriginario.isValidUpdate(),
                DomainOperation.Remocao => ctedocumentooriginario.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(ctedocumentooriginario.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICTeDocumentoOriginarioEntity ctedocumentooriginario, DomainOperationContext context);
        static partial void ValidateCustom(ICTeDocumentoOriginarioEntity ctedocumentooriginario, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICTeDocumentoOriginarioEntity ctedocumentooriginario, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration