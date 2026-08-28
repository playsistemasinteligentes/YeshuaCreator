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
    public partial interface IMapaWriteRepository
    {
        void Insert(IMapaEntity mapa);
        void Update(IMapaEntity mapa);
        void Delete(IMapaEntity mapa);
        void UpdateMAP_ID(int id, int value);
        void UpdatePON_ID(int id, string value);
        void UpdatePON_ID_VIZINHO(int id, string value);
        void UpdateMAP_DISTANCIA(int id, Decimal value);
        void UpdateMAP_CUSTO_PEDAGIO_POR_EIXO(int id, Decimal value);
        void UpdateROD_ID(int id, int value);
        void UpdateMAP_ALTURA_ROD(int id, Decimal value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration