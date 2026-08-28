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

    public interface IBoletimEstudoQueryWrite 
     {
        public QueryModel InserirBoletimEstudoQuery(IBoletimEstudoEntity BoletimEstudo);
        public QueryModel UpdateBoletimEstudoQuery(IBoletimEstudoEntity BoletimEstudo);
        QueryModel UpdateBOL_ID(int id, string value);
        QueryModel UpdateBOL_ID_ORIGEM(int id, string value);
        QueryModel UpdateBOL_SOLVER(int id, string value);
        QueryModel UpdateBOL_INTEGRACAO(int id, string value);
        QueryModel UpdateBOL_SEQUENCIA(int id, Decimal value);
        QueryModel UpdateGRP_PAP_GRAMATURA_PROGRAMADO(int id, Decimal value);
        QueryModel UpdateGRP_ID_PROGRAMADO(int id, string value);
        QueryModel UpdateGRP_PAPEL1_PROGRAMADO(int id, string value);
        QueryModel UpdateGRP_PAPEL2_PROGRAMADO(int id, string value);
        QueryModel UpdateGRP_PAPEL3_PROGRAMADO(int id, string value);
        QueryModel UpdateGRP_PAPEL4_PROGRAMADO(int id, string value);
        QueryModel UpdateGRP_PAPEL5_PROGRAMADO(int id, string value);
        QueryModel UpdateBOL_STATUS_INTERFACE(int id, string value);
        QueryModel UpdateBOL_TIPO(int id, string value);
        QueryModel UpdateBOL_FORMATO(int id, int value);
        QueryModel UpdateBOL_GRAMATURA_PAPEIS_PROGRAMADOS(int id, Decimal value);
        QueryModel UpdateBOL_GRAMATURA_PAPEIS_REALIZADO(int id, Decimal value);
        QueryModel UpdateBOL_CUSTO_PAPEIS_PROGRAMADOS(int id, Decimal value);
        QueryModel UpdateBOL_CUSTO_PAPEIS_REALIZADO(int id, Decimal value);
        QueryModel UpdateBOL_GRAMATURA_RESINA_PROGRAMADOS(int id, Decimal value);
        QueryModel UpdateBOL_CUSTO_RESINA_PROGRAMADOS(int id, Decimal value);
        QueryModel UpdateBOL_REFILE_OBRIGATORIO(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteBoletimEstudoQuery(IBoletimEstudoEntity BoletimEstudo);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration