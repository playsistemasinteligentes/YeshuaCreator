// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface ICorridasOnduladeiraEstudoQueryWrite 
     {
        public QueryModel InserirCorridasOnduladeiraEstudoQuery(ICorridasOnduladeiraEstudoEntity CorridasOnduladeiraEstudo);
        public QueryModel UpdateCorridasOnduladeiraEstudoQuery(ICorridasOnduladeiraEstudoEntity CorridasOnduladeiraEstudo);
        QueryModel UpdateBOL_ID(int id, string value);
        QueryModel UpdateBOL_ID_ORIGEM(int id, string value);
        QueryModel UpdatePRO_LARGURA_PECA(int id, Decimal value);
        QueryModel UpdatePRO_LARGURA_PECA_PROGRAMADO(int id, Decimal value);
        QueryModel UpdatePRO_COMPRIMENTO_PECA(int id, Decimal value);
        QueryModel UpdatePRO_COMPRIMENTO_PECA_PROGRAMADO(int id, Decimal value);
        QueryModel UpdatePRO_UTILIZOU_REFILE_OBRIGATORIO(int id, Decimal value);
        QueryModel UpdatePRO_VINCOS_RECALCULADOS(int id, string value);
        QueryModel UpdateCOR_SOLVER(int id, string value);
        QueryModel UpdateCOR_GRAMATURA_PAPEIS_PROGRAMADOS(int id, Decimal value);
        QueryModel UpdateCOR_CUSTO_PAPEIS_PROGRAMADOS(int id, Decimal value);
        QueryModel UpdateCOR_GRAMATURA_RESINA_PROGRAMADOS(int id, Decimal value);
        QueryModel UpdateCOR_CUSTO_RESINA_PROGRAMADOS(int id, Decimal value);
        QueryModel UpdateCOR_TOLERANCIA_MENOS(int id, Decimal value);
        QueryModel UpdateCOR_TOLERANCIA_MAIS(int id, Decimal value);
        QueryModel UpdateCOR_PILHAS_POR_PALETE(int id, int value);
        QueryModel UpdateCOR_M_LINEAR_REALIZADO(int id, Decimal value);
        QueryModel UpdatePRO_ID_PALETE(int id, string value);
        QueryModel UpdateCOR_STATUS_PALETE(int id, string value);
        QueryModel UpdateCOR_GRUPO_PRODUTIVO(int id, Decimal value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteCorridasOnduladeiraEstudoQuery(ICorridasOnduladeiraEstudoEntity CorridasOnduladeiraEstudo);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration