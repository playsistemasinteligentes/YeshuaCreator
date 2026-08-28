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

    public interface IOrderTrackQueryWrite 
     {
        public QueryModel InserirOrderTrackQuery(IOrderTrackEntity OrderTrack);
        public QueryModel UpdateOrderTrackQuery(IOrderTrackEntity OrderTrack);
        QueryModel UpdateOTK_ID(int id, int value);
        QueryModel UpdateOTK_SEQUENCIA(int id, Decimal value);
        QueryModel UpdateOTK_VERSSAO(int id, int value);
        QueryModel UpdateORD_ID(int id, string value);
        QueryModel UpdateOTK_EVENTO(int id, string value);
        QueryModel UpdateOTK_DATA_NECESSIDADE_DE(int id, DateTime value);
        QueryModel UpdateOTK_DATA_NECESSIDADE_ATE(int id, DateTime value);
        QueryModel UpdateOTK_DATA_PREVISTA(int id, DateTime value);
        QueryModel UpdateOTK_DATA_REALIZADA(int id, DateTime value);
        QueryModel UpdateFPR_ID(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteOrderTrackQuery(IOrderTrackEntity OrderTrack);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration