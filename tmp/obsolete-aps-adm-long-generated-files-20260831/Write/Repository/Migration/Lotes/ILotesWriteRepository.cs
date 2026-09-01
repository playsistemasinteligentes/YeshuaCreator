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
    public partial interface ILotesWriteRepository
    {
        void Insert(ILotesEntity lotes);
        void Update(ILotesEntity lotes);
        void Delete(ILotesEntity lotes);
        void UpdateMOV_LOTE(int id, string value);
        void UpdateMOV_SUB_LOTE(int id, string value);
        void UpdateLOT_LARGURA(int id, Decimal value);
        void UpdateLOT_COMPRIMENTO(int id, Decimal value);
        void UpdateLOT_DIAMETRO(int id, Decimal value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration