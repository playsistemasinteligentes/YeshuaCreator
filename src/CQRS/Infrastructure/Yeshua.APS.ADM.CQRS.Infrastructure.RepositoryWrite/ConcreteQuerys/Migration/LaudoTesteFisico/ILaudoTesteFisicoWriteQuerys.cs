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

    public interface ILaudoTesteFisicoQueryWrite 
     {
        public QueryModel InserirLaudoTesteFisicoQuery(ILaudoTesteFisicoEntity LaudoTesteFisico);
        public QueryModel UpdateLaudoTesteFisicoQuery(ILaudoTesteFisicoEntity LaudoTesteFisico);
        QueryModel UpdateLTF_ID(int id, int value);
        QueryModel UpdateLTF_EMISSAO(int id, DateTime value);
        QueryModel UpdateLTF_VALOR(int id, Decimal value);
        QueryModel UpdateLTF_OBS(int id, string value);
        QueryModel UpdateLTF_STATUS(int id, string value);
        QueryModel UpdateORD_ID(int id, string value);
        QueryModel UpdateROT_PRO_ID(int id, string value);
        QueryModel UpdateFPR_SEQ_REPETICAO(int id, int value);
        QueryModel UpdateUSE_ID(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteLaudoTesteFisicoQuery(ILaudoTesteFisicoEntity LaudoTesteFisico);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration