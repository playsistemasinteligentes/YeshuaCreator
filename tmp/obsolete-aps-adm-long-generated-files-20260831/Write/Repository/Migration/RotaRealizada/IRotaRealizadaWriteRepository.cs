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
    public partial interface IRotaRealizadaWriteRepository
    {
        void Insert(IRotaRealizadaEntity rotarealizada);
        void Update(IRotaRealizadaEntity rotarealizada);
        void Delete(IRotaRealizadaEntity rotarealizada);
        void UpdateCAR_ID(int rot_id, string value);
        void UpdateROT_DATA_HORA(int rot_id, DateTime value);
        void UpdateROT_LAT(int rot_id, Decimal value);
        void UpdateROT_LONG(int rot_id, Decimal value);
        void UpdateTenantID(int rot_id, int value);
        void UpdateDeleted(int rot_id, bool value);
        void UpdateChanged(int rot_id, DateTime value);
        void UpdateUserId(int rot_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration