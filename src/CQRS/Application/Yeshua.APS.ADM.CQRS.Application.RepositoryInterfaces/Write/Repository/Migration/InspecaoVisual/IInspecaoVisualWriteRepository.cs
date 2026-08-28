// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration
// </yeshua>

using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IInspecaoVisualWriteRepository
    {
        void Insert(IInspecaoVisualEntity inspecaovisual);
        void Update(IInspecaoVisualEntity inspecaovisual);
        void Delete(IInspecaoVisualEntity inspecaovisual);
        void UpdateIPV_VALOR(int ipv_id, string value);
        void UpdateIPV_ID_OPERADOR(int ipv_id, int value);
        void UpdateIPV_ID_LIBERACAO(int ipv_id, int value);
        void UpdateIPV_OBS(int ipv_id, string value);
        void UpdateIPV_DATA_COLETA(int ipv_id, DateTime value);
        void UpdateIPV_DATA_AVAL(int ipv_id, DateTime value);
        void UpdateTIV_ID(int ipv_id, int value);
        void UpdateTURN_ID(int ipv_id, string value);
        void UpdateTURM_ID(int ipv_id, string value);
        void UpdateORD_ID(int ipv_id, string value);
        void UpdateROT_PRO_ID(int ipv_id, string value);
        void UpdateROT_MAQ_ID(int ipv_id, string value);
        void UpdateROT_SEQ_TRANSFORMACAO(int ipv_id, int value);
        void UpdateFPR_SEQ_REPETICAO(int ipv_id, int value);
        void UpdateIPV_STATUS_LIBERACAO(int ipv_id, string value);
        void UpdateIPV_VALOR_MEDIDA(int ipv_id, Decimal value);
        void UpdateTenantID(int ipv_id, int value);
        void UpdateDeleted(int ipv_id, bool value);
        void UpdateChanged(int ipv_id, DateTime value);
        void UpdateUserId(int ipv_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration