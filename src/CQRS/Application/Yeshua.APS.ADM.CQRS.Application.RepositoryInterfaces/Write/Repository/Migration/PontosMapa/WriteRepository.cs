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
    public partial interface IPontosMapaWriteRepository
    {
        void Insert(IPontosMapaEntity pontosmapa);
        void Update(IPontosMapaEntity pontosmapa);
        void Delete(IPontosMapaEntity pontosmapa);
        void UpdatePON_DESCRICAO(string pon_id, string value);
        void UpdatePON_TIPO(string pon_id, string value);
        void UpdatePON_LATITUDE(string pon_id, Decimal value);
        void UpdatePON_LONGITUDE(string pon_id, Decimal value);
        void UpdatePON_DISTANCIA_KM(string pon_id, Decimal value);
        void UpdateTenantID(string pon_id, int value);
        void UpdateDeleted(string pon_id, bool value);
        void UpdateChanged(string pon_id, DateTime value);
        void UpdateUserId(string pon_id, int value);
        void UpdateMUN_ID(string pon_id, string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration