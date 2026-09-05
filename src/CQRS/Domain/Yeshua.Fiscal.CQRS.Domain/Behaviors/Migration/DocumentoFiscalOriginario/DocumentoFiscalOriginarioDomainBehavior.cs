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
    public static partial class DocumentoFiscalOriginarioDomainBehavior
    {
        public static DomainBehaviorResult Apply(IDocumentoFiscalOriginarioEntity documentofiscaloriginario, DomainOperationContext context)
        {
            PrepareCustom(documentofiscaloriginario, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(documentofiscaloriginario, context, result.Errors);
            ValidateCustom(documentofiscaloriginario, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(documentofiscaloriginario, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IDocumentoFiscalOriginarioEntity documentofiscaloriginario, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => documentofiscaloriginario.isValidInsert(),
                DomainOperation.Alteracao => documentofiscaloriginario.isValidUpdate(),
                DomainOperation.Remocao => documentofiscaloriginario.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(documentofiscaloriginario.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IDocumentoFiscalOriginarioEntity documentofiscaloriginario, DomainOperationContext context);
        static partial void ValidateCustom(IDocumentoFiscalOriginarioEntity documentofiscaloriginario, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IDocumentoFiscalOriginarioEntity documentofiscaloriginario, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration