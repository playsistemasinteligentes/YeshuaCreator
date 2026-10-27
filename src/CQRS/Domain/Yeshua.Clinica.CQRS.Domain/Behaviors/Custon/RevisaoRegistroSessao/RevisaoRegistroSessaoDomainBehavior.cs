using Dominio.Entitys;
using Dominio.Patterns.Domain;
namespace Dominio.Behaviors;
public static partial class RevisaoRegistroSessaoDomainBehavior
{
    static partial void ValidateCustom(IRevisaoRegistroSessaoEntity entity,DomainOperationContext context,List<string> errors)
    { if(context.EntryPoint==DomainEntryPoint.Crud)errors.Add("Utilize o painel Atendimentos para preservar autorização, versão e revisão do registro."); }
}
