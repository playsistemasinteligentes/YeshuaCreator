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
    public static partial class DocumentoFiscalDomainBehavior
    {
        public static DomainBehaviorResult Apply(IDocumentoFiscalEntity documentofiscal, DomainOperationContext context)
        {
            PrepareCustom(documentofiscal, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(documentofiscal, context, result.Errors);
            ValidateCustom(documentofiscal, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(documentofiscal, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IDocumentoFiscalEntity documentofiscal, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => documentofiscal.isValidInsert(),
                DomainOperation.Alteracao => documentofiscal.isValidUpdate(),
                DomainOperation.Remocao => documentofiscal.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(documentofiscal.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IDocumentoFiscalEntity documentofiscal, DomainOperationContext context);
        static partial void ValidateCustom(IDocumentoFiscalEntity documentofiscal, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IDocumentoFiscalEntity documentofiscal, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration