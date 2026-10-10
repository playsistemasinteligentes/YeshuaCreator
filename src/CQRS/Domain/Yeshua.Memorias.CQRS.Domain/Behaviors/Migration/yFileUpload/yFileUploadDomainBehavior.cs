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
    public static partial class yFileUploadDomainBehavior
    {
        public static DomainBehaviorResult Apply(IyFileUploadEntity yfileupload, DomainOperationContext context)
        {
            PrepareCustom(yfileupload, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(yfileupload, context, result.Errors);
            ValidateCustom(yfileupload, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(yfileupload, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IyFileUploadEntity yfileupload, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => yfileupload.isValidInsert(),
                DomainOperation.Alteracao => yfileupload.isValidUpdate(),
                DomainOperation.Remocao => yfileupload.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(yfileupload.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IyFileUploadEntity yfileupload, DomainOperationContext context);
        static partial void ValidateCustom(IyFileUploadEntity yfileupload, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IyFileUploadEntity yfileupload, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration