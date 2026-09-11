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
    public static partial class EntradaFiscalContingenciaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IEntradaFiscalContingenciaEntity entradafiscalcontingencia, DomainOperationContext context)
        {
            PrepareCustom(entradafiscalcontingencia, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(entradafiscalcontingencia, context, result.Errors);
            ValidateCustom(entradafiscalcontingencia, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(entradafiscalcontingencia, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IEntradaFiscalContingenciaEntity entradafiscalcontingencia, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => entradafiscalcontingencia.isValidInsert(),
                DomainOperation.Alteracao => entradafiscalcontingencia.isValidUpdate(),
                DomainOperation.Remocao => entradafiscalcontingencia.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(entradafiscalcontingencia.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IEntradaFiscalContingenciaEntity entradafiscalcontingencia, DomainOperationContext context);
        static partial void ValidateCustom(IEntradaFiscalContingenciaEntity entradafiscalcontingencia, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IEntradaFiscalContingenciaEntity entradafiscalcontingencia, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration