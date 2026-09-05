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
    public static partial class MDFeDocumentoOriginarioDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMDFeDocumentoOriginarioEntity mdfedocumentooriginario, DomainOperationContext context)
        {
            PrepareCustom(mdfedocumentooriginario, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(mdfedocumentooriginario, context, result.Errors);
            ValidateCustom(mdfedocumentooriginario, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(mdfedocumentooriginario, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMDFeDocumentoOriginarioEntity mdfedocumentooriginario, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => mdfedocumentooriginario.isValidInsert(),
                DomainOperation.Alteracao => mdfedocumentooriginario.isValidUpdate(),
                DomainOperation.Remocao => mdfedocumentooriginario.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(mdfedocumentooriginario.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMDFeDocumentoOriginarioEntity mdfedocumentooriginario, DomainOperationContext context);
        static partial void ValidateCustom(IMDFeDocumentoOriginarioEntity mdfedocumentooriginario, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMDFeDocumentoOriginarioEntity mdfedocumentooriginario, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration