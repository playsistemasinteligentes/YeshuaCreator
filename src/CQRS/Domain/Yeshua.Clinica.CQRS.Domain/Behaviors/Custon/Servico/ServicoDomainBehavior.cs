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
    public static partial class ServicoDomainBehavior
    {
        static partial void PrepareCustom(IServicoEntity entity, DomainOperationContext context)
        {
            if(context.Operation==DomainOperation.Registro && entity.ModeloConsulta.GetValueOrDefault()==0)
                entity.ModeloConsulta=Clinica.Modelos.ModelosConsulta.PsicologiaCompleta;
        }
        static partial void ValidateCustom(IServicoEntity entity, DomainOperationContext context, List<string> errors)
        {
            if(context.Operation is DomainOperation.Registro or DomainOperation.Alteracao &&
                !Clinica.Modelos.ModelosConsulta.Suporta(entity.ModeloConsulta.GetValueOrDefault()))
                errors.Add("Escolha um modelo de consulta disponível.");
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
