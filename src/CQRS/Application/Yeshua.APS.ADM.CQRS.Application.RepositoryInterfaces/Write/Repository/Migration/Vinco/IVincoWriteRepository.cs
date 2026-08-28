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
    public partial interface IVincoWriteRepository
    {
        void Insert(IVincoEntity vinco);
        void Update(IVincoEntity vinco);
        void Delete(IVincoEntity vinco);
        void UpdateVIN_DESCRICAO(int vin_id, string value);
        void UpdateVIN_ID_DESLOCAMENTO(int vin_id, string value);
        void UpdateTenantID(int vin_id, int value);
        void UpdateDeleted(int vin_id, bool value);
        void UpdateChanged(int vin_id, DateTime value);
        void UpdateUserId(int vin_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration