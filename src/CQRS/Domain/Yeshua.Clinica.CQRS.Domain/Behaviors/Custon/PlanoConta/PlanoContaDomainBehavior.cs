// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
// </yeshua>

using Dominio.Entitys;
using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Behaviors
{
    public static partial class PlanoContaDomainBehavior
    {
        static partial void PrepareCustom(IPlanoContaEntity entity, DomainOperationContext context)
        {
            if (!ValidacaoCadastro.Escrita(context)) return;
            entity.Nome=entity.Nome?.Trim()??""; entity.Codigo=entity.Codigo?.Trim()??"";
        }
        static partial void ValidateCustom(IPlanoContaEntity entity, DomainOperationContext context, List<string> errors)
        {
            if (!ValidacaoCadastro.Escrita(context)) return;
            ValidacaoCadastro.Texto(entity.Nome,"Nome da conta",150,errors);
            ValidacaoCadastro.Texto(entity.Codigo,"Código da conta",20,errors);
            ValidacaoCadastro.Opcao(entity.Tipo,1,4,"Tipo da conta",errors);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
