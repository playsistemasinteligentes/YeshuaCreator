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
    public static partial class InformacoesComplementaresDomainBehavior
    {
        public static DomainBehaviorResult Apply(IInformacoesComplementaresEntity informacoescomplementares, DomainOperationContext context)
        {
            PrepareCustom(informacoescomplementares, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(informacoescomplementares, context, result.Errors);
            ValidateCustom(informacoescomplementares, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(informacoescomplementares, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IInformacoesComplementaresEntity informacoescomplementares, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => informacoescomplementares.isValidInsert(),
                DomainOperation.Alteracao => informacoescomplementares.isValidUpdate(),
                DomainOperation.Remocao => informacoescomplementares.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(informacoescomplementares.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IInformacoesComplementaresEntity informacoescomplementares, DomainOperationContext context);
        static partial void ValidateCustom(IInformacoesComplementaresEntity informacoescomplementares, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IInformacoesComplementaresEntity informacoescomplementares, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration