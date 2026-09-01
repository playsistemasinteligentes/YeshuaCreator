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
    public partial interface IRotaPontosMapaWriteRepository
    {
        void Insert(IRotaPontosMapaEntity rotapontosmapa);
        void Update(IRotaPontosMapaEntity rotapontosmapa);
        void Delete(IRotaPontosMapaEntity rotapontosmapa);
        void UpdateROT_ID(int id, string value);
        void UpdatePON_ID_DESTINO(int id, string value);
        void UpdatePON_ID_ORIGEM(int id, string value);
        void UpdateROT_CUSTO_TOTAL(int id, Decimal value);
        void UpdatePON_ID_ROTEIRO(int id, string value);
        void UpdateROT_ORDEM_ROTEIRO(int id, int value);
        void UpdateROT_TIPO(int id, string value);
        void UpdateROT_DISTANCIA(int id, Decimal value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration