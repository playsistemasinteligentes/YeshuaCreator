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
    public static partial class EnderecosDomainBehavior
    {
        public static DomainBehaviorResult Apply(IEnderecosEntity enderecos, DomainOperationContext context)
        {
            PrepareCustom(enderecos, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(enderecos, context, result.Errors);
            ValidateCustom(enderecos, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(enderecos, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IEnderecosEntity enderecos, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => enderecos.isValidInsert(),
                DomainOperation.Alteracao => enderecos.isValidUpdate(),
                DomainOperation.Remocao => enderecos.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(enderecos.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IEnderecosEntity enderecos, DomainOperationContext context);
        static partial void ValidateCustom(IEnderecosEntity enderecos, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IEnderecosEntity enderecos, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration