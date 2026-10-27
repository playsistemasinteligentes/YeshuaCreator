using Dominio.Entitys;
using Dominio.Patterns.Domain;
namespace Dominio.Behaviors;
public static partial class ProfissionalDomainBehavior
{
    static partial void ValidateCustom(IProfissionalEntity entity,DomainOperationContext context,List<string> errors)
    { if(context.EntryPoint==DomainEntryPoint.Crud && context.Operation==DomainOperation.Registro && entity.UsuarioAcessoId.HasValue)errors.Add("Configure o vínculo de acesso pela ação administrativa."); }
}
