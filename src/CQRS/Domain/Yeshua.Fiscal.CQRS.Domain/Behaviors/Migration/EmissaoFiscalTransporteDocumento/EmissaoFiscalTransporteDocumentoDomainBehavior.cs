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
    public static partial class EmissaoFiscalTransporteDocumentoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IEmissaoFiscalTransporteDocumentoEntity emissaofiscaltransportedocumento, DomainOperationContext context)
        {
            PrepareCustom(emissaofiscaltransportedocumento, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(emissaofiscaltransportedocumento, context, result.Errors);
            ValidateCustom(emissaofiscaltransportedocumento, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(emissaofiscaltransportedocumento, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IEmissaoFiscalTransporteDocumentoEntity emissaofiscaltransportedocumento, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => emissaofiscaltransportedocumento.isValidInsert(),
                DomainOperation.Alteracao => emissaofiscaltransportedocumento.isValidUpdate(),
                DomainOperation.Remocao => emissaofiscaltransportedocumento.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(emissaofiscaltransportedocumento.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IEmissaoFiscalTransporteDocumentoEntity emissaofiscaltransportedocumento, DomainOperationContext context);
        static partial void ValidateCustom(IEmissaoFiscalTransporteDocumentoEntity emissaofiscaltransportedocumento, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IEmissaoFiscalTransporteDocumentoEntity emissaofiscaltransportedocumento, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration